using Lab11.DAL.EF;
using Lab11.Model.Attributes;
using Lab11.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Expression = System.Linq.Expressions.Expression;

namespace Lab11.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             using (var context = new ApplicationDbContext())
            {
                var invoices = context.Invoices
                    .Include(x => x.InvoiceItems)
                    .ToList();
                SetGrid(invoices, dg_Invoices);
                cb_filterbyProperties.ItemsSource = GetFilterByProperties<Invoice>();
                cb_filterbyProperties.Items.Refresh();
            }
        }

        private void SetGrid<T>(IList<T> list, DataGrid dataGrid) where T : new()
        {
            dataGrid.Columns.Clear();
            Type type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                if (prop.GetCustomAttribute<HideAttribute>() == null)
                {
                    dataGrid.Columns.Add(new DataGridTextColumn() { Header = prop.Name, Binding = new Binding(prop.Name) });
                }
            }
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
        }

        private void B_addInvoiceWindowShow_Click(object sender, RoutedEventArgs e)
        {
            AddInvoiceWindow invoiceWindow = new AddInvoiceWindow();
            if (invoiceWindow.ShowDialog() == true && invoiceWindow.Invoice != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Invoices.Add(invoiceWindow.Invoice);
                    context.SaveChanges();
                    SetGrid(context.Invoices.Include(x => x.InvoiceItems).ToList(), dg_Invoices);
                }
            }
        }

        private void B_removeInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Invoices.SelectedItem != null && dg_Invoices.SelectedItem is Invoice invoice)
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Set<Invoice>().Attach(invoice);
                    context.InvoiceItems.RemoveRange(invoice.InvoiceItems);
                    context.Invoices.Remove(invoice);
                    context.SaveChanges();
                    SetGrid(context.Invoices.Include(x => x.InvoiceItems).ToList(), dg_Invoices);
                    //var invoiceDb = context.Invoices.FirstOrDefault(x => x.Id == invoice.Id);
                    //if (invoiceDb != null)
                    //{
                    //    context.InvoiceItems.RemoveRange(context.InvoiceItems.Where(x => x.InvoiceId == invoice.Id));
                    //    context.SaveChanges();
                    //    //context.Entry(invoice).State = EntityState.Deleted;
                    //    context.Invoices.Remove(invoiceDb);
                    //    context.SaveChanges();
                    //    SetGrid(context.Invoices.Include(x => x.InvoiceItems).ToList(), dg_Invoices);
                    //}
                }
            }
        }

        private void B_addInvoiceItemWindowShow_Click(object sender, RoutedEventArgs e)
        {
            if (dg_Invoices.SelectedItem is Invoice invoiceItem)
            {
                AddInvoiceItemsWindow addInvoiceItemsWindow = new AddInvoiceItemsWindow(invoiceItem);
                if (addInvoiceItemsWindow.ShowDialog() == true && addInvoiceItemsWindow.InvoiceItem != null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        context.InvoiceItems.Add(addInvoiceItemsWindow.InvoiceItem);
                        context.SaveChanges();
                        SetGrid(context.Invoices.Include(x => x.InvoiceItems).ToList(), dg_Invoices);
                    }
                }
            }
        }

        private IList<string> GetFilterByProperties<T>()
        {
            Type type = typeof(T);
            var list = type
                .GetProperties()
                .Where(p => p.GetCustomAttribute<HideAttribute>() == null && p.GetCustomAttribute<NotMappedAttribute>() == null)
                .Select(x => x.Name)
                .ToList();
            return list;
        }

        private void Tb_filterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cb_filterbyProperties.SelectedItem != null && cb_filterbyProperties.SelectedItem is string item)
            {
                Expression body = Expression.Constant(true);
                var parameter = Expression.Parameter(typeof(Invoice), "in");
                var member = Expression.Property(parameter, item);
                var constant = Expression.Constant(tb_filterValue.Text);
                var toStringValue = Expression.Call(member, typeof(object).GetMethod("ToString"));
                var method = typeof(string).GetMethods().Single(x => x.Name == "Contains" && x.GetParameters().Length == 1 && x?.GetParameters()?.FirstOrDefault()?.ParameterType == typeof(string));//("Contains");
                var expression = Expression.Call(toStringValue, method, constant);
                body = Expression.AndAlso(body, expression);
                Expression <Func<Invoice, bool>> filterExpression  = Expression.Lambda<Func<Invoice, bool>>(body, parameter);
                using (var context = new ApplicationDbContext())
                {
                    var filteredInvoices = context.Invoices
                        .Include(x=>x.InvoiceItems)
                        .Where(filterExpression)
                        .ToList();
                    SetGrid(filteredInvoices,dg_Invoices);
                }
            }
        }


    }
}


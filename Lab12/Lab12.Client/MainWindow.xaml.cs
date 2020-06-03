using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Lab12.Utilities.Attributes;
using Lab12.Utilities.Utils;
using Lab12.Utilities.VMs;

namespace Lab12.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<MessageVm> _messages;
        public MainWindow()
        {
            InitializeComponent();
            _messages = new List<MessageVm>();
        }
        private static void SetGrid<T>(IList<T> list, DataGrid dataGrid) where T : new()
        {
            dataGrid.Columns.Clear();
            Type type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                if (prop.GetCustomAttribute<HideAttribute>() == null)
                    dataGrid.Columns.Add(new DataGridTextColumn() { Header = prop.Name, Binding = new Binding(prop.Name) });
            }
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
        }
        private void B_connectDownload_Click(object sender, RoutedEventArgs e)
        {
            ConnectAndDownload();
        }
        private void DG_Messages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DG_Messages.SelectedItem != null && DG_Messages.SelectedItem is MessageVm message)
            {
                SetGrid(message.Attachments, DG_ATTACHMENTS);
            }
        }

        private void ConnectAndDownload()
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ip);
                    _messages.Clear();
                }
                catch (SocketException)
                {
                    MessageBox.Show("Unable to connect to server.");
                    return;
                }
                var data = new byte[1024 * 1024];
                server.Receive(data);
                _messages = data.Deserialize<List<MessageVm>>().ToList();
                var fileBytes = new byte[1024 * 1024];
                server.Receive(fileBytes);
                File.WriteAllBytes(@"./attachment1.bin", fileBytes);
                fileBytes = new byte[1024 * 1024 * 10];
                server.Receive(fileBytes);
                File.WriteAllBytes(@"./attachment2.bin", fileBytes);
                SetGrid(_messages, DG_Messages);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
     
    }
}

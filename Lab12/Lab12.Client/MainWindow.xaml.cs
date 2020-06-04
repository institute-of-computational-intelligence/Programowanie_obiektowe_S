using Lab12.Server.Utilities.Attributes;
using Lab12.Server.Utilities.Utils;
using Lab12.Server.Utilities.VMs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab12.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<MessageVm> messageList;

        public MainWindow()
        {
            InitializeComponent();

            messageList = new List<MessageVm>();
        }

        private static void UpdateGrid<T>(IList<T> list, DataGrid grid) where T: new()
        {
            grid.Columns.Clear();

            Type type = typeof(T);

            foreach(var property in type.GetProperties())
            {
                if (property.GetCustomAttribute<HideAttribute>() == null)
                {
                    grid.Columns.Add(new DataGridTextColumn()
                    {
                        Header = property.Name,
                        Binding = new Binding(property.Name)
                    });
                }

                grid.AutoGenerateColumns = false;
                grid.ItemsSource = list;
                grid.Items.Refresh();
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IPEndPoint ipAddr = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                Socket clientTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    clientTCP.Connect(ipAddr);
                    messageList.Clear();
                } catch (Exception excp)
                {
                    MessageBox.Show("Failed to connect to server: " + excp.Message);
                    return;
                }

                var serverData = new byte[1024 * 1024];
                clientTCP.Receive(serverData);

                messageList = serverData.Deserialize<List<MessageVm>>().ToList();

                var attachmentsData = new byte[8 * 1024];
                clientTCP.Receive(attachmentsData);

                File.WriteAllBytes(@"./AttachmentA.bin", attachmentsData);
                attachmentsData = new byte[32 * 512];
                clientTCP.Receive(attachmentsData);

                File.WriteAllBytes(@"./AttachmentB.bin", attachmentsData);
                UpdateGrid(messageList, dgMessages);

                clientTCP.Shutdown(SocketShutdown.Both);
                clientTCP.Close();
            } catch (Exception excp)
            {
                MessageBox.Show(excp.ToString());
            }
        }

        private void dgMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMessages.SelectedItem != null && dgMessages.SelectedItem is MessageVm msg)
            {
                UpdateGrid(msg.Attachments, dgAttachments);
            }
        }
    }
}

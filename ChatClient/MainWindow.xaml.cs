using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , ChatClient.ServiceChat.IService_ChatCallback
    {
        bool isConntected = false;
        ServiceChat.Service_ChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void ConectUser()
        {
            if(!isConntected)
            {
                client = new ServiceChat.Service_ChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                bConnDiscon.Content = "Disconnect";
                isConntected = true;
            }
        }

        void DisconnectUser()
        {
            if (isConntected)
            {
                client.Disconnect(ID);
                client = null;
                tbUserName.IsEnabled = true;
                bConnDiscon.Content = "Connect";
                isConntected = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConntected)
            {
                DisconnectUser();
            }
            else
            {
                ConectUser();
            }
        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
           lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count-1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMsg(tbMessage.Text, ID);
                    tbMessage.Text = String.Empty;
                }
              
            }
        }
    }
}

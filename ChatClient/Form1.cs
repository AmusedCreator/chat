using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClient.ServiceChat;


namespace ChatClient
{
    public partial class Form1 : Form, IServiceChatCallback
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;

        public Form1()
        {
            InitializeComponent();
        }

        void UpdateUsers()
        {
            if (client != null)
            {
                string[] users = client.GetUsers();
                UsersList.Items.Clear();
                UsersList.Items.AddRange(users);
            }
        }
        
        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                
                ID = client.Connect(NameBox.Text);
                NameBox.Enabled = false;
                isConnected = true;
                UpdateUsers();
            }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                NameBox.Enabled = true;
                isConnected = false;
                UpdateUsers();

            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
                Button.Text = "Connect";
                Button.BackColor = Color.Green;
            }
            else
            {
                ConnectUser();
                Button.Text = "Disconnect";
                Button.BackColor = Color.Maroon;
            }
        }

        public void MsgCallback(string message)
        {
            ChatBox.Items.Add(message);
            ChatBox.SelectedIndex = ChatBox.Items.Count - 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectUser();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.SendMsg(MessageBox.Text, ID);
                    
                MessageBox.Text = "";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}



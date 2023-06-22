using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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

        
        async Task UpdateUsers()
        {
            while (true)
            {
                if (client != null)
                {
                    if(client.GetUsers().Length != UsersList.Items.Count)
                    {
                        string[] users = client.GetUsers();
                        UsersList.Items.Clear();
                        UsersList.Items.AddRange(users);
                    }
                }
                await Task.Delay(1000);
            }
        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                
                tokenSource2 = new CancellationTokenSource();
                Task.Run(UpdateUsers, tokenSource2.Token);

                ID = client.Connect(NameBox.Text);
                NameBox.Enabled = false;
                isConnected = true;
            }
        }

        CancellationTokenSource tokenSource2;
        void DisconnectUser()
        {
            if (isConnected)
            {
                // UpdateUsers();
                client.Disconnect(ID);
                client = null;
                NameBox.Enabled = true;
                isConnected = false;
                tokenSource2.Cancel();
                UsersList.Items.Clear();
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

        // private void button2_Click(object sender, EventArgs e)
        // {
        //     if (client != null)
        //     {
        //         client[currClient].PlayHangman();
        //     }
        // }

        // private static TextBox _boba;
        // public static TextBox GetMessageBox
        // {
        //     get => _boba;
        // }
        // private void button2_Click_1(object sender, EventArgs e)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}
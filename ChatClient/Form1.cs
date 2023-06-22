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
        CancellationTokenSource tokenSource2;

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

                bool uniqueNickname = true;
                for (int i = 0; i < client.GetUsers().Length; i++)
                {
                        if (client.GetUsers()[i].Equals(NameBox.Text)) { uniqueNickname = false; break; }
                }

                if (uniqueNickname)
                {
                    ID = client.Connect(NameBox.Text);
                    NameBox.Enabled = false;
                    isConnected = true;
                    
                    Button.Text = "Disconnect";
                    Button.BackColor = Color.Maroon;
                    MsgCallback("|" + DateTime.Now.ToShortTimeString() + "| <Console> You have succesfully connected");
                }

                else
                {
                    MsgCallback("This nickname is already in use. Try another one.");
                }
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
                MsgCallback("|" + DateTime.Now.ToShortTimeString() + "| <Console> You have succesfully disconnected");

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
﻿namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameBox = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.ListBox();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.UsersList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameBox.Location = new System.Drawing.Point(23, 15);
            this.NameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(460, 30);
            this.NameBox.TabIndex = 0;
            this.NameBox.Text = "Имя пользователя";
            // 
            // ChatBox
            // 
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.ItemHeight = 16;
            this.ChatBox.Location = new System.Drawing.Point(239, 53);
            this.ChatBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(809, 356);
            this.ChatBox.TabIndex = 2;
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(23, 421);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(891, 117);
            this.MessageBox.TabIndex = 3;
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.Color.Green;
            this.Button.Location = new System.Drawing.Point(492, 15);
            this.Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(159, 32);
            this.Button.TabIndex = 5;
            this.Button.Text = "Connect";
            this.Button.UseVisualStyleBackColor = false;
            this.Button.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.BackgroundImage = global::ChatClient.Properties.Resources.free_icon_right_arrow_724954;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(948, 441);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 71);
            this.button1.TabIndex = 6;
            this.button1.Text = "\r\n\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UsersList
            // 
            this.UsersList.FormattingEnabled = true;
            this.UsersList.ItemHeight = 16;
            this.UsersList.Location = new System.Drawing.Point(23, 54);
            this.UsersList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(207, 356);
            this.UsersList.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(923, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Play Hangman";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.UsersList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.NameBox);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox UsersList;
        
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.ListBox ChatBox;
        private System.Windows.Forms.TextBox MessageBox;

        private System.Windows.Forms.Button Button;

        private System.Windows.Forms.TextBox NameBox;

        #endregion

        private System.Windows.Forms.Button button2;
    }
}
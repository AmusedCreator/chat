namespace ChatClient
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
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameBox.Location = new System.Drawing.Point(442, 12);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(346, 26);
            this.NameBox.TabIndex = 0;
            this.NameBox.Text = "Имя пользователя";
            // 
            // ChatBox
            // 
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.Location = new System.Drawing.Point(17, 43);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(770, 290);
            this.ChatBox.TabIndex = 2;
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(17, 342);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(769, 96);
            this.MessageBox.TabIndex = 3;
            this.MessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_KeyDown);
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.Color.Green;
            this.Button.Location = new System.Drawing.Point(317, 12);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(119, 26);
            this.Button.TabIndex = 5;
            this.Button.Text = "Connect";
            this.Button.UseVisualStyleBackColor = false;
            this.Button.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.NameBox);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox ChatBox;
        private System.Windows.Forms.TextBox MessageBox;

        private System.Windows.Forms.Button Button;

        private System.Windows.Forms.TextBox NameBox;

        #endregion
    }
}
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
            this.label1 = new System.Windows.Forms.Label();
            this.inputServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputUsername = new System.Windows.Forms.TextBox();
            this.outputConnectedClients = new System.Windows.Forms.TreeView();
            this.outputServerStatus = new System.Windows.Forms.Label();
            this.outputChatDispalyBox = new System.Windows.Forms.TextBox();
            this.inputClient = new System.Windows.Forms.TextBox();
            this.inputSendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name";
            // 
            // inputServerName
            // 
            this.inputServerName.Location = new System.Drawing.Point(13, 30);
            this.inputServerName.Name = "inputServerName";
            this.inputServerName.Size = new System.Drawing.Size(100, 20);
            this.inputServerName.TabIndex = 1;
            this.inputServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputServerName_KeyDown);
            this.inputServerName.Leave += new System.EventHandler(this.inputServerName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // inputUsername
            // 
            this.inputUsername.Location = new System.Drawing.Point(13, 74);
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.Size = new System.Drawing.Size(100, 20);
            this.inputUsername.TabIndex = 3;
            // 
            // outputConnectedClients
            // 
            this.outputConnectedClients.Location = new System.Drawing.Point(13, 101);
            this.outputConnectedClients.Name = "outputConnectedClients";
            this.outputConnectedClients.Size = new System.Drawing.Size(100, 147);
            this.outputConnectedClients.TabIndex = 4;
            // 
            // outputServerStatus
            // 
            this.outputServerStatus.AutoSize = true;
            this.outputServerStatus.Location = new System.Drawing.Point(120, 13);
            this.outputServerStatus.Name = "outputServerStatus";
            this.outputServerStatus.Size = new System.Drawing.Size(35, 13);
            this.outputServerStatus.TabIndex = 5;
            this.outputServerStatus.Text = "label3";
            // 
            // outputChatDispalyBox
            // 
            this.outputChatDispalyBox.Location = new System.Drawing.Point(120, 30);
            this.outputChatDispalyBox.Multiline = true;
            this.outputChatDispalyBox.Name = "outputChatDispalyBox";
            this.outputChatDispalyBox.Size = new System.Drawing.Size(193, 176);
            this.outputChatDispalyBox.TabIndex = 6;
            // 
            // inputClient
            // 
            this.inputClient.Location = new System.Drawing.Point(120, 213);
            this.inputClient.Multiline = true;
            this.inputClient.Name = "inputClient";
            this.inputClient.Size = new System.Drawing.Size(124, 35);
            this.inputClient.TabIndex = 7;
            // 
            // inputSendButton
            // 
            this.inputSendButton.Location = new System.Drawing.Point(250, 213);
            this.inputSendButton.Name = "inputSendButton";
            this.inputSendButton.Size = new System.Drawing.Size(63, 23);
            this.inputSendButton.TabIndex = 8;
            this.inputSendButton.Text = "Send";
            this.inputSendButton.UseVisualStyleBackColor = true;
            this.inputSendButton.Click += new System.EventHandler(this.inputSendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 339);
            this.Controls.Add(this.inputSendButton);
            this.Controls.Add(this.inputClient);
            this.Controls.Add(this.outputChatDispalyBox);
            this.Controls.Add(this.outputServerStatus);
            this.Controls.Add(this.outputConnectedClients);
            this.Controls.Add(this.inputUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputServerName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ChatClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputUsername;
        private System.Windows.Forms.TreeView outputConnectedClients;
        private System.Windows.Forms.Label outputServerStatus;
        private System.Windows.Forms.TextBox outputChatDispalyBox;
        private System.Windows.Forms.TextBox inputClient;
        private System.Windows.Forms.Button inputSendButton;
    }
}


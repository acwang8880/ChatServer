using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();

        // private string serverStatus = "Not connected ...";
        private string serverName;


        public Form1()
        {
            InitializeComponent();
            this.outputServerStatus.Text = "Client Socket Program - ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");

        }

        private void msg(string v)
        {
            outputChatDispalyBox.Text = outputChatDispalyBox.Text + Environment.NewLine + " >> " + v;
        }

        private void inputServerName_Leave(object sender, EventArgs e)
        {
            if (inputServerName.Text.Equals(""))
            {
                // what happens when no server specified
                MessageBox.Show("No server specified");
            }
            else
            {
                serverName = inputServerName.Text;
                MessageBox.Show("Servername: " + serverName);
            }

            //MessageBox.Show("sender: " + sender.ToString() + "\n" + "e: " + e.ToString());
            
        }

        private void inputServerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    inputServerName_Leave(inputServerName, e);
                    clientSocket.Connect(serverName, 8888);
                    outputServerStatus.Text += "Server Connected ...";
                }
                catch (Exception s)
                {
                    MessageBox.Show(s.ToString());
                }
            }
        }

        private void inputSendButton_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();

            //convert input String to something server can understand
            byte[] outStream = Encoding.ASCII.GetBytes(inputClient.Text + "$");

            //give the server the good stuff
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            //read from server
            byte[] inStream = new byte[65537];
            serverStream.Read(inStream, 0, (int) clientSocket.ReceiveBufferSize);

            //display in chat window
            string returndata = Encoding.ASCII.GetString(inStream);
            msg(returndata);

            //clean input box
            inputClient.Text = "";
            inputClient.Focus();
        }
    }
}

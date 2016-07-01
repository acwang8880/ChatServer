using System;
using System.Collections;
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
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        // private string serverStatus = "Not connected ...";
        private string serverName;


        public Form1()
        {
            InitializeComponent();
            this.outputServerStatus.Text = "Client Socket Program - ";
            ToolTip tooltip1 = new ToolTip();
            // Set up the delays for the ToolTip.
            tooltip1.AutoPopDelay = 5000;
            tooltip1.InitialDelay = 1000;
            tooltip1.ReshowDelay = 10;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tooltip1.ShowAlways = true;
            tooltip1.SetToolTip(this.inputServerName, "Press ENTER to confirm");


//-->>Delete after Debugging completed            
            this.inputServerName.Text = "127.0.0.1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void msg()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            else
            {
                outputChatDispalyBox.Text = outputChatDispalyBox.Text + Environment.NewLine + " >> " + readData;
            }
        }

        //assigns server name
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
            }

            //MessageBox.Show("sender: " + sender.ToString() + "\n" + "e: " + e.ToString());
            
        }

        //entering Server Name
        private void inputServerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    inputServerName_Leave(inputServerName, e);
                    clientSocket.Connect(serverName, 8888);
                    outputServerStatus.Text += "Server Connected ...";
                    serverStream = clientSocket.GetStream();

                    //read from server
                    byte[] inStream = new byte[65537];
                    serverStream.Read(inStream, 0, (int) clientSocket.ReceiveBufferSize);

                    //display in chat window
                    string returndata = Encoding.ASCII.GetString(inStream);
                    readData = "" + returndata;
                    msg();
                }
                catch (Exception s)
                {
                    MessageBox.Show(s.ToString());
                }
            }
        }

        private void inputSendButton_Click(object sender, EventArgs e)
        {
            readData = "Connected to Server ...";
            msg();
            //convert input String to something server can understand
            byte[] outStream = Encoding.ASCII.GetBytes(inputClient.Text + "$");

            //give the server the good stuff
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            //clean input box
            inputClient.Text = "";
            inputClient.Focus();
        }
    }
}

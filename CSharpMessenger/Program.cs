using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace CSharpMessenger
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        static void Main(string[] args)
        { 
            //our server
            TcpListener serverSocketListener = new TcpListener(8888);
            int counter = 0;

            //our client
            TcpClient clientSocket = default(TcpClient);

            //initiate server
            serverSocketListener.Start();
            Console.WriteLine("  >> Server initiated");
            counter = 0;
            
            while (true)
            {
                counter += 1;

                //check if client connected to server
                clientSocket = serverSocketListener.AcceptTcpClient();
                Console.WriteLine("  >> " + "Client No: " + Convert.ToString(counter) + " connection accepted.");

                //create buffer for storing client info
                byte[] bytesFrom = new byte[65537];
                string dataFromClient = null;

                NetworkStream networkStream = clientSocket.GetStream();

                //get data from network stream
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);

                //interpret client data
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                //create hashtable of clients
                clientsList.Add(dataFromClient, clientSocket);
                
                //broadcast to all clients
                broadcast(dataFromClient + " Joined ", dataFromClient, false);

                Console.WriteLine(dataFromClient + " Joined ", dataFromClient);
                handleClient client = new handleClient();
                client.startClient(clientSocket, dataFromClient, clientsList);
            }
            //clean up everything
            clientSocket.Close();
            serverSocketListener.Stop();
            Console.WriteLine("  >> Exiting client and server");
            Console.ReadLine();
        }

        //broadcast server's messages to everyone on the server
        public static void broadcast(string message, string username, bool flag)
        {
            foreach (DictionaryEntry item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient) item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                //first time sending message?
                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(username + " :" + message);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(message);
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        } //end broadcast
    } // end Main class

    public class handleClient
    {
        TcpClient clientSocket;
        string clientNum;
        Hashtable listOfClients;
        
        public void startClient(TcpClient clientIn, string num, Hashtable allClients)
        {
            this.clientSocket = clientIn;
            this.clientNum = num;
            this.listOfClients = allClients;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }
        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[65537];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string requestCountString = null;
            //requestCount = 0;

            while (true)
            {
                try
                {
                    requestCount += 1;
                    NetworkStream networkStream = clientSocket.GetStream();

                    //get data from network stream
                    networkStream.Read(bytesFrom, 0, (int) clientSocket.ReceiveBufferSize);

                    //interpret client data
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    //display client data
                    Console.WriteLine("  >> Data recieved from Client " + clientNum + ": " + dataFromClient);
                    requestCountString = Convert.ToString(requestCount);

                    Program.broadcast(dataFromClient, clientNum, true);

                    //write to network stream and clean up
                    sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();

                    Console.WriteLine("  >> " + serverResponse);

                }
                catch (Exception e)
                {
                    Console.WriteLine("  >> " + e.ToString());
                }
            }
        }
    }
}

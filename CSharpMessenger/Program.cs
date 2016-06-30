using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace CSharpMessenger
{
    class Program
    {
        static void Main(string[] args)
        {

            //our server
            TcpListener serverSocketListener = new TcpListener(8888);
            int requestCount = 0;

            //our client
            TcpClient clientSocket = default(TcpClient);

            //initiate server
            serverSocketListener.Start();
            Console.WriteLine("  >> Server initiated");

            //check if client connected to server
            clientSocket = serverSocketListener.AcceptTcpClient();
            Console.WriteLine("  >> Accepted connection from client");
            requestCount = 0;


            while (true)
            {
                try
                {
                    requestCount += 1;
                    NetworkStream networkStream = clientSocket.GetStream();

                    //get data from network stream
                    byte[] bytesFrom = new byte[65537];
                    Console.WriteLine("Buffer size: " + clientSocket.ReceiveBufferSize);
                    networkStream.Read(bytesFrom, 0, (int) clientSocket.ReceiveBufferSize);
                    

                    //interpret client data
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    //display client data
                    Console.WriteLine("  >> Data recieved from Client - " + dataFromClient);
                    string serverResponse = "Last Message from Client " + dataFromClient;

                    //write to network stream and clean up
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();

                    Console.WriteLine("  >> " + serverResponse);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            //clean up everything
            clientSocket.Close();
            serverSocketListener.Stop();
            Console.WriteLine("  >> Exiting client and server");
            Console.ReadLine();
        }
    }
}

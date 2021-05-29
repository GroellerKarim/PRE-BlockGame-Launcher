using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientLauncher
{
    class ClientTest
    {
        static void Main(string[] args)
        {
            Send("127.0.0.1", new Datapackage("Login", new List<object>()));
        }

        public static Datapackage Send(string ip, Datapackage message)
        {
            try
            {
                int port = 2200;
                TcpClient client = new TcpClient(ip, port);

                NetworkStream stream = client.GetStream();
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, message);
                Console.WriteLine("Sent Data");

                Datapackage response = (Datapackage)formatter.Deserialize(stream);

                stream.Close();
                client.Close();

                return response;
            }

            catch (Exception e)
            {

                throw e;
            }
        }

        private Datapackage SendMessage(Datapackage package)
        {
            return null;
        }
    }
}

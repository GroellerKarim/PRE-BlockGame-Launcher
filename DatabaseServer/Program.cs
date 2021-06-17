using System;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using DatabaseServer.Models;
using DatabaseServer.Infrastructure;

namespace DatabaseServer
{
    class Program
    {  
        // Figure out how to send serialized objects
        public static void Main(string[] args)
        {
            Server server = new Server("127.0.0.1", 2200);  
            //kk xd
        }
    }   

    class Server
    {
        TcpListener server = null;
        BinaryFormatter formatter = new BinaryFormatter();
        DatabaseContext db;
        
        public Server(string ip, int port)
        {
            StartDB();
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            StartListening();
        }

        public void StartDB()
        {
            db = new DatabaseContext();
            db.Database.EnsureCreated();
        }

        public void StartListening()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected.");

                    Thread t = new Thread(new ParameterizedThreadStart(HandleDevice));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }

        public void HandleDevice(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string imei = String.Empty;

            string data = null;
            Byte[] bytes = new Byte[1024];
            int i;
            try
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                Datapackage package = (Datapackage)formatter.Deserialize(stream);

                Datapackage response = HandleRequest(package);

                formatter.Serialize(stream, response);

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }

        private Datapackage HandleRequest(Datapackage d)
        {
            Datapackage resp = null;
            //List<Object> data = d.Data;

            switch (d.RequestType)
            {
                case "Login":
                    resp = new Datapackage(LoginRequest(d.User).ToString(), d.User);
                    break;  
                case "Register":
                    resp = new Datapackage(RegisterRequest(d.User).ToString(), d.User);
                    break;
                default:
                    break;
            }

            return resp;
        }

        private bool LoginRequest(User u)
        {

            Tuple<bool, User> doesExist = DoesUserExist(u);

            if(doesExist.Item1 == true)
            {
                if (u.Equals(doesExist.Item2))
                {
                    Console.WriteLine("User exists: " + u.Name);
                    return true;
                }
            }

            return false;
        }

        public bool RegisterRequest(User u)
        {
            if (!DoesUserExist(u).Item1)
            {
                db.User.Add(u);
                db.SaveChanges();

                Console.WriteLine("New User added: " + u.Name);
                return true;
            }

            return false;
        }

        public Tuple<bool, User> DoesUserExist(User u)
        {

            List<User> userlist = (from c in db.User
                                   where c.Name == u.Name
                                   select c).ToList();

            if(userlist.Count != 0)
            {
                return new Tuple<bool, User>(true, userlist.First());
            }

            return new Tuple<bool, User>(false, null);
        }


    }

}

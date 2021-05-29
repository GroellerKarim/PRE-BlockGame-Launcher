﻿using System;
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

            Console.WriteLine("hello db");

            User u = (from c in db.User
                     where c.Name == "admin"
                     select c).ToList<User>().First<User>();
            Console.WriteLine(u.Name);

            db.SaveChanges();
            
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
                    resp = new Datapackage("Got response", d.User);
                    Console.WriteLine("worked");
                    break;
                case "Register":

                    break;
                default:
                    break;
            }

            return resp;
        }

        private bool DoesUserExist(User u)
        {
            
            return false;
        }
    }

}
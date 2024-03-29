﻿using BlockGameLauncher.Domain.Interfaces;
using DatabaseServer.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BlockGameLauncher.Services
{
    public class ConnectionService: IConnectionService
    {

        private static readonly string IP_ADDRESS = "127.0.0.1";
        private static readonly int PORT = 2200;

        public  Datapackage Send(Datapackage message)
        {
            try
            {
                TcpClient client = new TcpClient(IP_ADDRESS, PORT);

                NetworkStream stream = client.GetStream();
                BinaryFormatter formatter = new BinaryFormatter();

                                                                                                                                    #pragma warning disable SYSLIB0011;
                formatter.Serialize(stream, message);

                Datapackage response = (Datapackage)formatter.Deserialize(stream);

                stream.Close();
                client.Close();

                return response;
            }

            catch (Exception e)
            {
                return null;
            }
        }
    }
}

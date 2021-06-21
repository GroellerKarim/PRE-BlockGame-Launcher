using BlockGameLauncher.Domain.Interfaces;
using DatabaseServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockGameLauncher.Services
{
    public class ProcessingService : IProcessingService
    {
        public ConnectionService Connection { get; set; }
        public ProcessingService()
        {
            Connection = new ConnectionService();
        }

        public Tuple<bool, Datapackage> SendUserData(string username, string password)
        {
            string request = "Login";
            User user = new User(username, password);

            Datapackage resp = Connection.Send(new Datapackage(request, user));

            if (resp.RequestType.Equals("True"))
            {
                return new Tuple<bool, Datapackage>(true, resp);
            }

            return new Tuple<bool, Datapackage>(false, resp);
        }

        public bool SendRegistrationData(string username, string password)
        {
            string request = "register";
            User user = new User(username, password);
            Datapackage resp = Connection.Send(new Datapackage(request, user));

            if (resp.RequestType.Equals("True"))
            {
                return true;
            }

            return false;
        }

    }
}

using DatabaseServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockGameLauncher.Services
{
    public class ProcessingService
    {
        public static Tuple<Boolean, Datapackage> HandleLogin(String username, String password)
        {
            string request = "Login";
            User user = new User(username, password);

            Datapackage resp = ConncectionService.Send(new Datapackage(request, user));

            if (resp.RequestType.Equals("True"))
            {
                return new Tuple<Boolean, Datapackage>(true, resp);
            }

            return new Tuple<Boolean, Datapackage>(false, resp);
        }

    }
}

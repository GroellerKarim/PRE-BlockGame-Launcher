using BlockGameLauncher.Services;
using DatabaseServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGameLauncher.Domain.Interfaces
{
    public interface IProcessingService
    {
        public ConnectionService Connection { get; set; }

        Tuple<bool, Datapackage> SendUserData(string username, string password);

        bool SendRegistrationData(string username, string password);

    }
}

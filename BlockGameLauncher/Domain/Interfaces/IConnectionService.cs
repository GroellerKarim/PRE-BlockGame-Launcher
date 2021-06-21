using DatabaseServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockGameLauncher.Domain.Interfaces
{
    public interface IConnectionService
    {

        Datapackage Send(Datapackage message);
    }
}

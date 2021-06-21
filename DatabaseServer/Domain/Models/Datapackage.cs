using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseServer.Models
{
    [Serializable]
    public class Datapackage
    {
        public string RequestType { get; set; }
        public User User { get; set; }
        public PatchNotes Patch { get; set; }

        public Datapackage(string type, User u)
        {
            this.RequestType = type;
            this.User = u;
        }

        public Datapackage(string type, PatchNotes patch)
        {
            this.RequestType = type;
            this.Patch = patch;
        }
    }
}

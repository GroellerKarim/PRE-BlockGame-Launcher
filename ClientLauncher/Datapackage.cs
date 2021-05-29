using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLauncher
{
    [Serializable]
    public class Datapackage
    {
        // Dummy package for now
        public String RequestType { get; set; }
        public List<Object> Data { get; set; }

        public Datapackage(String type, List<Object> list)
        {
            this.RequestType = type;
            this.Data = list;
        }
    }
}

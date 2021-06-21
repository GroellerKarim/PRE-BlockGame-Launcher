using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseServer.Models
{
    [Serializable]
    public class PatchNotes
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Changes { get; set; }

        public PatchNotes(string title, string version, DateTime releaseDate, List<string> changes)
        {
            this.Title = title;
            this.Title = version;
            this.ReleaseDate = releaseDate;
            this.Changes = changes;
        }
    }
}

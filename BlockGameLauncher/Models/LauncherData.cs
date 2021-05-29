using DatabaseServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockGameLauncher.Models
{
    public class LauncherData
    {
        public User ApprovedUser { get; set; }
        public PatchNotes Patch { get; set; }
        
    }
}

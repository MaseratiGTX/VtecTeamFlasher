using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAndServerCommons.DataClasses;

namespace VtecTeamFlasher.Helpers
{
    public static class Session
    {
        public static User CurrentUser { get; set; }
    }
}

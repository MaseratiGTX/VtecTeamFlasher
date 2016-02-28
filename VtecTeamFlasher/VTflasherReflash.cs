using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Statuses;
using Commons.Helpers;
using Commons.Serialization.Binary;
using VtecTeamFlasher.Helpers;

namespace VtecTeamFlasher
{
    public partial class VTFlasher : Form
    {
        private void changePCMModules(string moduleName)
        {
            var moduleList = XMLHelper.LoadPCMFlashModules();
            foreach (var module in moduleList)
            {
                if ("  " + module.Key == moduleName)
                {
                    WinAPIHelper.SendMessage(pcmComboBoxModules, 0x014F/*CB_SHOWDROPDOWN*/, 1, "");
                    WinAPIHelper.SendMessage(pcmComboBoxModules, 0x014E/*CB_SETCURSEL*/, module.Value, "");
                    WinAPIHelper.SendMessage(pcmComboBoxModules, 0x0201/*WM_LBUTTONDOWN*/, 0, "-1");
                    WinAPIHelper.SendMessage(pcmComboBoxModules, 0x0202/*WM_LBUTTONUP*/, 0, "-1");
                    WinAPIHelper.SendMessage(pcmComboBoxModules, 0x014F/*CB_SHOWDROPDOWN*/, 0, "0");
                    WinAPIHelper.SendMessage(pcmComboBoxModules, WinAPIHelper.CB_SETCURSEL, module.Value, "");
                    return;
                }
            }
            WinAPIHelper.SendMessage(pcmComboBoxModules, 0x014F/*CB_SHOWDROPDOWN*/, 1, "");
            WinAPIHelper.SendMessage(pcmComboBoxModules, 0x014E/*CB_SETCURSEL*/, 1, "");
            WinAPIHelper.SendMessage(pcmComboBoxModules, 0x0201/*WM_LBUTTONDOWN*/, 0, "-1");
            WinAPIHelper.SendMessage(pcmComboBoxModules, 0x0202/*WM_LBUTTONUP*/, 0, "-1");
            WinAPIHelper.SendMessage(pcmComboBoxModules, 0x014F/*CB_SHOWDROPDOWN*/, 0, "0");
            WinAPIHelper.SendMessage(pcmComboBoxModules, WinAPIHelper.CB_SETCURSEL, 1, "");
        }

        private void loadCbModules()
        {
            var moduleList = XMLHelper.LoadPCMFlashModules();
            foreach (var module in moduleList)
            {
                var spaces = "";
                if (module.Value == -1) spaces = " ";
                if (module.Value > 0) spaces = "  ";
                cbModules.Items.Add(spaces+module.Key);
            }
        }

    }
}

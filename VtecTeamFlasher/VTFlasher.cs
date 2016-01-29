using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VtecTeamFlasher
{
    public partial class VTFlasher : Form
    {
        private IntPtr pcmMainWindow;
        private Process pcmProcess;
        StringBuilder ssb = new StringBuilder(256, 256);
        private List<IntPtr> pcmChildren; 

        public VTFlasher()
        {
            InitializeComponent();
        }

        private void VTFlasher_Load(object sender, EventArgs e)
        {
            var info = new ProcessStartInfo
                           {
                               FileName = AppDomain.CurrentDomain.BaseDirectory + "\\PcmFlasher\\pcmflash.exe",
                               UseShellExecute = true,
                              // WindowStyle = ProcessWindowStyle.Hidden
                           };
            pcmProcess = Process.Start(info);
            pcmProcess.WaitForInputIdle();

            pcmMainWindow = WinAPIHelper.FindWindowByCaption(IntPtr.Zero, "PCMflash");

            WinAPIHelper.SetParent(pcmProcess.MainWindowHandle, this.Handle);

            pcmChildren = GetChildWindows(pcmMainWindow);

            var cb = WinAPIHelper.FindWindowEx(pcmMainWindow, IntPtr.Zero, "ComboBox", null);
            var cbAdapters = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[0], null, null);
            if (cbAdapters != IntPtr.Zero)
            {
                var count = WinAPIHelper.SendMessage(cbAdapters, WinAPIHelper.CB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
                for (int i = 0; i < (int)count; i++)
                {
                    if (WinAPIHelper.SendMessage(cbAdapters, WinAPIHelper.CB_GETLBTEXT, i, ssb) != (IntPtr)(-1))
                    {
                        cbAdapter.Items.Add(ssb.ToString());

                    }
                }
                var pcmSelectedIndex = (int) WinAPIHelper.SendMessage(cbAdapters, WinAPIHelper.CB_GETCURSEL, IntPtr.Zero,IntPtr.Zero);
                if (pcmSelectedIndex != -1)
                    WinAPIHelper.SendMessage(cbAdapters, WinAPIHelper.CB_GETLBTEXT, pcmSelectedIndex,ssb);
                cbAdapter.SelectedText = !String.IsNullOrEmpty(ssb.ToString()) ? ssb.ToString(): "";
            }
            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (pcmMainWindow != IntPtr.Zero)
            {
                var btnSelectFile = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[4], null, null);
                WinAPIHelper.SendMessage(btnSelectFile, WinAPIHelper.BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
            }
        }

        private void VTFlasher_FormClosing(object sender, FormClosingEventArgs e)
        {
            pcmProcess.Kill();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (pcmMainWindow != IntPtr.Zero)
            {
                var btnPcmExit = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[23], null, null);
                WinAPIHelper.SendMessage(btnPcmExit, WinAPIHelper.BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
            }
            Environment.Exit(0);
        }

        private void cbAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbAdapters = WinAPIHelper.FindWindowEx(pcmMainWindow, IntPtr.Zero, "ComboBox", null);
            if (cbAdapters != IntPtr.Zero)
            {
                WinAPIHelper.SendMessage(cbAdapters, WinAPIHelper.CB_SETCURSEL,cbAdapter.SelectedIndex ,"");
            }
        }


        private static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                var childProc = new WinAPIHelper.EnumWindowProc(EnumWindow);
                WinAPIHelper.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="handle">Handle of the next window</param>
        /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
        /// <returns>True to continue the enumeration, false to bail</returns>
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            var list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }


    }
}

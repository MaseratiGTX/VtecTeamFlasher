using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VtecTeamFlasher
{
    public partial class VTFlasher : Form
    {
        private IntPtr pcmMainWindow;
       // private IntPtr btnPcmSettings = IntPtr.Zero;
        private Process pcmProcess;
        StringBuilder ssb = new StringBuilder(256, 256);

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
                               WindowStyle = ProcessWindowStyle.Hidden
                           };
            pcmProcess = Process.Start(info);

            Thread.Sleep(1000);
            WinAPIHelper.SetParent(pcmProcess.MainWindowHandle, this.Handle);
            pcmMainWindow = WinAPIHelper.FindWindow(null, "PCMflash");


            var cbAdapters = WinAPIHelper.FindWindowEx(pcmMainWindow, IntPtr.Zero, "ComboBox", null);
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
                //cbAdapter.SelectedIndex = (int) WinAPIHelper.SendMessage(cbAdapters, WinAPIHelper.CB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
            }
            //ShowWindow(process.MainWindowHandle, SW_SHOWMAXIMIZED);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            string text = null; 
            if (pcmMainWindow != IntPtr.Zero)
            {
                var btnPcmSettings = WinAPIHelper.FindWindowEx(pcmMainWindow, IntPtr.Zero, "Button", "Настройки");
                WinAPIHelper.SendMessage(btnPcmSettings, WinAPIHelper.BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
            }

            
            //Thread.Sleep(500);
            //var settindsWindow = WinAPIHelper.FindWindow(null, "Настройки");

            //while (settindsWindow != IntPtr.Zero)
            //{
            //    Thread.Sleep(200);
                
            //}
            
            //WinAPIHelper.BringWindowToTop(this.Handle);
            //this.Select();
            
        }

        private void VTFlasher_FormClosing(object sender, FormClosingEventArgs e)
        {
            pcmProcess.Kill();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (pcmMainWindow != IntPtr.Zero)
            {
                var btnPcmExit = WinAPIHelper.FindWindowEx(pcmMainWindow, IntPtr.Zero, "Button", "Выход");
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
            //MessageBox.Show(cbAdapter.SelectedItem.ToString());
        }
    }
}

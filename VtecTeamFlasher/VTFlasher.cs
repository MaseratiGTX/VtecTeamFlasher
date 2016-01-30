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
        private List<IntPtr> pcmChildren;

        private IntPtr pcmComboBoxModules;
        private IntPtr pcmComboBoxAdapters;
        private IntPtr pcmTextBoxFilePath;
        private IntPtr pcmButtonExit;
        private IntPtr pcmButtonSettings;

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

            pcmComboBoxModules = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[6], null, null);
            pcmComboBoxAdapters = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[0], null, null);
            pcmTextBoxFilePath = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[14], null, null);
            pcmButtonExit = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[23], null, null);
            pcmButtonSettings = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[4], null, null);

            InitializeComboBoxControl(pcmComboBoxAdapters, cbAdapter);
            InitializeComboBoxControl(pcmComboBoxModules, cbModules);

        }

        private void InitializeComboBoxControl(IntPtr controlHandle, ComboBox comboBox)
        {
            var ssb = new StringBuilder(256, 256);

            if (controlHandle != IntPtr.Zero)
            {
                var count = WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
                for (int i = 0; i < (int)count; i++)
                {
                    if (WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETLBTEXT, i, ssb) != (IntPtr)(-1))
                    {
                        comboBox.Items.Add(ssb.ToString());

                    }
                }
                var pcmSelectedIndex = (int)WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
                if (pcmSelectedIndex != -1)
                    WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETLBTEXT, pcmSelectedIndex, ssb);
                comboBox.SelectedText = !String.IsNullOrEmpty(ssb.ToString()) ? ssb.ToString() : "";
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (pcmMainWindow != IntPtr.Zero)
                WinAPIHelper.SendMessage(pcmButtonSettings, WinAPIHelper.BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
        }

        private void VTFlasher_FormClosing(object sender, FormClosingEventArgs e)
        {
            pcmProcess.Kill();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (pcmMainWindow != IntPtr.Zero)
                WinAPIHelper.SendMessage(pcmButtonExit, WinAPIHelper.BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
            Environment.Exit(0);
        }

        private void cbAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pcmComboBoxAdapters != IntPtr.Zero)
            {
                WinAPIHelper.SendMessage(pcmComboBoxAdapters, WinAPIHelper.CB_SETCURSEL, cbAdapter.SelectedIndex, "");
            }
        }


        private void cbModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pcmComboBoxModules != IntPtr.Zero)
            {
                WinAPIHelper.SendMessage(pcmComboBoxModules, WinAPIHelper.CB_SETCURSEL, cbModules.SelectedIndex, "");
            }
        }

        private static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            var result = new List<IntPtr>();
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
            var gch = GCHandle.FromIntPtr(pointer);
            var list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }


        //SendMessage(textBox1.Handle, WM_SETTEXT, IntPtr.Zero,
        //      textBox1.Text + ", " + textBox1.Text);

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = "Файлы прошивки|*.bin|Все файлы|*.*" };

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            txtFilePath.Text = fileDialog.FileName;
            if (pcmTextBoxFilePath != IntPtr.Zero)
                WinAPIHelper.SendMessage(pcmTextBoxFilePath, WinAPIHelper.WM_SETTEXT, IntPtr.Zero, fileDialog.FileName);
        }

    }
}

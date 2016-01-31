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

using System.Windows.Forms;
using System.Windows.Threading;

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
        private IntPtr pcmKeyNumber;
        private IntPtr pcmTextBoxStatus;
        private IntPtr pcmButtonInitialize;
        private IntPtr pcmButtonIdentify;
        private IntPtr pcmButtonReadErrors;
        private IntPtr pcmButtonRestart;
        private IntPtr pcmButtonEraseErrors;
        private IntPtr pcmButtonRestartAdaptation;
        private IntPtr pcmButtonRead;
        private IntPtr pcmButtonWrite;
        private IntPtr pcmButtonCheckCorrectCS;

        private Thread txtStatusThread;
        private StringBuilder sb = new StringBuilder(1024, 90000);

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
                //CreateNoWindow = true,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
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
            pcmButtonExit = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[22], null, null);
            pcmButtonSettings = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[4], null, null);
            pcmKeyNumber = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[3], null, null);
            pcmTextBoxStatus = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[20], null, null);
            pcmButtonInitialize = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[10], null, null);
            pcmButtonIdentify = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[7], null, null);
            pcmButtonReadErrors = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[8], null, null);
            pcmButtonRestart = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[9], null, null);
            pcmButtonEraseErrors = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[11], null, null);
            pcmButtonRestartAdaptation = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[12], null, null);
            pcmButtonRead = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[17], null, null);
            pcmButtonWrite = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[18], null, null);
            pcmButtonCheckCorrectCS = WinAPIHelper.FindWindowEx(pcmMainWindow, pcmChildren[16], null, null);

            var b = new StringBuilder(256,256);
            var a = "123";
                    var ssb = new StringBuilder(256, 256);
                    var d = WinAPIHelper.SendMessage(pcmKeyNumber, WinAPIHelper.WM_GETTEXT, 0, ssb);
                        a = (ssb.ToString());
                    WinAPIHelper.GetWindowText(pcmKeyNumber, b, 100);

            InitializeComboBoxControl(pcmComboBoxAdapters, cbAdapter);
            InitializeComboBoxControl(pcmComboBoxModules, cbModules);
            SetButtonStatus();

            txtStatusThread = new Thread(() =>
                    {
                        while (true)
                        {
                            WinAPIHelper.SendMessage(pcmTextBoxStatus, WinAPIHelper.WM_GETTEXT, 10000, sb);
                            this.Invoke(()=>txtStatus.Text = sb.ToString());
                            Thread.Sleep(100);
                        }
                    });
            txtStatusThread.Start();
        }

        # region ComboBoxes
        private void InitializeComboBoxControl(IntPtr controlHandle, ComboBox comboBox)
        {
            var ssb = new StringBuilder(256, 256);

            if (controlHandle != IntPtr.Zero)
            {
                var count = WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
                for (int i = 0; i < (int)count; i++)
                {
                    if (WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETLBTEXT, i, ssb) != (IntPtr)(-1))
                        comboBox.Items.Add(ssb.ToString());
                }
                var pcmSelectedIndex = (int)WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
                if (pcmSelectedIndex != -1)
                    WinAPIHelper.SendMessage(controlHandle, WinAPIHelper.CB_GETLBTEXT, pcmSelectedIndex, ssb);
                comboBox.SelectedText = !String.IsNullOrEmpty(ssb.ToString()) ? ssb.ToString() : "";
            }
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
                SetButtonStatus();
            }
        }

        # endregion

        #region Buttons
        private void SetButtonStatus()
        {
            cbControlSum.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonCheckCorrectCS);
            btnInitialize.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonInitialize);
            btnIdentify.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonIdentify);
            btnReadErrors.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonReadErrors);
            btnRestart.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonRestart);
            btnEraseErrors.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonEraseErrors);
            btnResetAdaptation.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonRestartAdaptation);
            btnRead.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonRead);
            btnWrite.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonWrite);
            btnSettings.Enabled = WinAPIHelper.IsWindowEnabled(pcmButtonSettings);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonSettings);
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonIdentify);
        }

        private void btnReadErrors_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonReadErrors);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonRestart);
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonInitialize);
        }

        private void btnEraseErrors_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonEraseErrors);
        }

        private void btnResetAdaptation_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonRestartAdaptation);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonRead);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonWrite);
        }

        private void cbControlSum_CheckedChanged(object sender, EventArgs e)
        {
            ButtonClick(pcmButtonCheckCorrectCS);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ButtonClick(IntPtr button)
        {
            if (pcmMainWindow != IntPtr.Zero)
                WinAPIHelper.SendMessage(button, WinAPIHelper.BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
        }
        #endregion

        private void VTFlasher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pcmMainWindow != IntPtr.Zero)
                WinAPIHelper.SendMessage(pcmButtonExit, WinAPIHelper.BN_CLICKED, IntPtr.Zero, IntPtr.Zero);
            txtStatusThread.Abort();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Management;

namespace DisplaySwitcherCSharp
{
    public partial class Form1 : Form
    {


        //public bool boolTrayExit = false;
        private bool boolStartup = false;

        private int intCode1 = 0;
        private int intCode2 = 0;

        private bool boolWait = false;
        private DateTime dtWaitStart;
        private int intWaitSeconds = 10;
        private int intLastKeyboardCount;

        private Stopwatch stopWatch_StateChanged = new Stopwatch();
        private int intDebounceMS = 1000;


        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveRegistrySettings();
            MessageBox.Show("Settings saved.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveRegistrySettings()
        {
            try
            {
                RegistryKey regKey_RUN;
                regKey_RUN = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                RegistryKey appRegKey;
                appRegKey = Registry.CurrentUser.OpenSubKey("Software\\" + Application.ProductName, true);

                //Startup 
                appRegKey.SetValue("RunAtStartup", boolStartup, RegistryValueKind.DWord);

                //if boolStartup..., add executable path to the Run registry key
                if (boolStartup)
                {
                    regKey_RUN.SetValue(Application.ProductName, Application.ExecutablePath);
                }
                else
                {
                    regKey_RUN.DeleteValue(Application.ProductName);
                }



                if (intCode1 == 0) { intCode1 = 15; }
                if (intCode2 == 0) { intCode2 = 17; }


                if (TextBoxCode1.Text != intCode1.ToString()) { TextBoxCode1.Text = intCode1.ToString(); }
                if (TextBoxCode2.Text != intCode2.ToString()) { TextBoxCode2.Text = intCode2.ToString(); }

                //Save the Codes
                appRegKey.SetValue("Code1", intCode1, RegistryValueKind.DWord);
                appRegKey.SetValue("Code2", intCode2, RegistryValueKind.DWord);


                RunAtStartupToolStripMenuItemTRAY.Checked = boolStartup;


                regKey_RUN.Close();
                appRegKey.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption in SaveRegistrySettings()");
                Console.WriteLine(ex.Message);

            }
            
        }

        private void ButtonInput2_Click(object sender, EventArgs e)
        {
            int myNum = 0;
            Int32.TryParse(TextBoxCode2.Text, out myNum);
            if (myNum != 0) { SetDisplay(myNum); }
        }

        private void ButtonInput1_Click(object sender, EventArgs e)
        {
            int myNum = 0;
            Int32.TryParse(TextBoxCode1.Text, out myNum);
            if (myNum != 0) { SetDisplay(myNum); }
        }

        private void SetDisplay(int DisplayNum)
        {

            DisplayControl.DisplayControl dp = new DisplayControl.DisplayControl();


            DisplayControl.NativeStructures.PHYSICAL_MONITOR[] monitors = dp.getMonitors();

            if (monitors.Length < 1) { return; }

            IntPtr mainMonitor = monitors[0].hPhysicalMonitor;

            // 0x60 = Set Input

            bool success = DisplayControl.NativeMethods.SetVCPFeature(mainMonitor, 0x60, (uint)DisplayNum);

            dp.cleanupMonitors((uint)(monitors.Length), monitors);

            WriteToEventLog(Application.ProductName + "\n\nSending VCP Code:  " + DisplayNum.ToString());
        }

        private void WriteToEventLog(string sMessage)
        {
            EventLog ELog = new EventLog("Application");
            ELog.Source = "Application";
            //ELog.WriteEntry(sMessage);
            //ELog.WriteEntry(sMessage, EventLogEntryType.Information, 101);
            ELog.WriteEntry(sMessage, EventLogEntryType.Information);
        }

        private void TextBoxCode2_TextChanged(object sender, EventArgs e)
        {
            if (!IsNumeric(TextBoxCode2.Text))
            {
                MessageBox.Show("Invalid Code!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBoxCode2.Focus();
                TextBoxCode2.SelectAll();
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxCode1_TextChanged(object sender, EventArgs e)
        {
            if (!IsNumeric(TextBoxCode1.Text))
            {
                MessageBox.Show("Invalid Code!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBoxCode1.Focus();
                TextBoxCode1.SelectAll();
            }

        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void LabelKeyboardCount_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NotifyIcon1.Text = Application.ProductName;
            intLastKeyboardCount = GetKeyboardCount();
            LoadRegistrySettings();
        }

        private int GetKeyboardCount()
        {
            int count;
            string strQuery = "Select * from Win32_Keyboard";

            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(strQuery);
                
                ManagementObjectCollection collection = searcher.Get();
                count = collection.Count;
                LabelKeyboardCount.Text = "Keyboard count: " + count;
                if (count != intLastKeyboardCount )
                { 
                Console.WriteLine("Keyboards:");
                foreach (ManagementObject keyb in collection)
                {
                    Console.WriteLine(keyb.GetPropertyValue("Name").ToString());
                    //Console.WriteLine(keyb.GetPropertyValue("DeviceID").ToString());
                    //Console.WriteLine(keyb.GetPropertyValue("Status").ToString());
                    //Console.WriteLine(keyb.GetPropertyValue("PNPDeviceID").ToString());
                    Console.WriteLine(keyb.GetPropertyValue("Description").ToString());
                }
            }


        }
        catch (Exception ex)
        {
                count = -1;
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
            return count;
        }

        private void LoadRegistrySettings()
        {
            RegistryKey regKey_RUN;
            regKey_RUN = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            RegistryKey appRegKey;
            appRegKey = Registry.CurrentUser.OpenSubKey("Software\\" + Application.ProductName, true);

            if (appRegKey == null)
            {
                // Create the key
                Registry.CurrentUser.CreateSubKey("Software\\" + Application.ProductName);
                appRegKey = Registry.CurrentUser.OpenSubKey("Software\\" + Application.ProductName, true);
                if (appRegKey == null)
                {
                    regKey_RUN.Close();
                    return;
                }

                //Ask user if they want it to launch auto...
                if (MessageBox.Show("Launch " + Application.ProductName + " at Startup?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    boolStartup = true;
                }
                else
                {
                    boolStartup = false;
                }
            }
            else
            {
                //Load current Startup Value and set it in the interface
                boolStartup = (int)appRegKey.GetValue("RunAtStartup", 0) == 1 ? true : false;

                intCode1 = (int)appRegKey.GetValue("Code1", 15);
                intCode2 = (int)appRegKey.GetValue("Code2", 17);

                TextBoxCode1.Text = intCode1.ToString();
                TextBoxCode2.Text = intCode2.ToString();

            }

            regKey_RUN.Close();
            appRegKey.Close();

            SaveRegistrySettings();

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            else
            {
                ShowMe();
            }
        }

        private void ShowMe()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            if (this.Location.X < 0 || this.Location.Y < 0) { this.CenterToScreen(); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!boolTrayExit)
            //{
            //    if (MessageBox.Show("Are you sure you want to exit?\n\n(Click No to minimize to the Notification area)", "Exit " + Application.ProductName + "?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
            //    {
            //        e.Cancel = true;
            //        this.WindowState = FormWindowState.Minimized;
            //        return;
            //    }
            //}
        }

        private void RunAtStartupToolStripMenuItemTRAY_Click(object sender, EventArgs e)
        {
            boolStartup = RunAtStartupToolStripMenuItemTRAY.Checked;
            SaveRegistrySettings();
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //NotifyIcon1.ContextMenu = ContextMenuIcon;
        }
            if (e.Button == MouseButtons.Left)
            {
                ShowMe();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //boolTrayExit = true;
            Application.Exit();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (boolWait)
            {
                TimeSpan elapsedTime;
                elapsedTime = DateTime.Now.Subtract(dtWaitStart);
                if (elapsedTime.TotalSeconds < intWaitSeconds)
                {
                    return;
                }
                else
                {
                    boolWait = false;
                }
            }

            int intKeyboards = GetKeyboardCount();
            if (intKeyboards != intLastKeyboardCount)
            {
                //make sure it's really changed (debounce)

                if (stopWatch_StateChanged.IsRunning)
                {
                    if (stopWatch_StateChanged.ElapsedMilliseconds >= intDebounceMS)
                    {
                        if (intKeyboards == 0)
                        {
                            //no keyboards... switch to #2
                            boolWait = true;
                            dtWaitStart = DateTime.Now;
                            SetDisplay(intCode2);
                        }
                        else if (intKeyboards == 2) //mouse is a "keyboard" too
                        {
                            //keyboard present, switch to PC
                            boolWait = true;
                            dtWaitStart = DateTime.Now;
                            SetDisplay(intCode1);
                        }

                        intLastKeyboardCount = intKeyboards;

                        stopWatch_StateChanged.Reset();
                        Console.WriteLine("{0} OK SWITCH", DateTime.Now);
                    }
                    else
                    {
                        Console.WriteLine("{0} not ready...", DateTime.Now);
                    }
                }
                else
                {
                    stopWatch_StateChanged.Start();
                    Console.WriteLine("{0} Keyboard count changed from {1} to {2}", DateTime.Now, intLastKeyboardCount, intKeyboards);
                }
            }
            else
            {
                if (stopWatch_StateChanged.IsRunning)
                {
                    stopWatch_StateChanged.Reset();
                }
            }
         }
    }
}

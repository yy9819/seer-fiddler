using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using seer_fiddler.core;

namespace seer_fiddler
{
    public partial class FiddlerMainForm : Form
    {
        private FiddlerCaptureForm captureForm;
        private SeerFiddler seerfiddler;
        private delegate void CheckRunningWindowCallback();

        public FiddlerMainForm()
        {
            InitializeComponent();
            this.captureForm = new FiddlerCaptureForm();
            this.seerfiddler = new SeerFiddler(captureForm);
            this.ShowInTaskbar = false;
            TransparencyKey = System.Drawing.Color.White;
            this.InitSkinsPlan();
            //this.captureForm.Show(); 
            //this.captureForm.Hide(); 
        }

        private void miniSizeForm_Load(object sender, EventArgs e)
        {
            Win32Util.SetWindowLong(this.Handle);
            this.Size = System.Drawing.Size.Empty;
            new Thread(() => this.CheckRunningWindow()).Start();
            this.InitIniFile();
        }

        private void InitIniFile()
        {
            string iniFilePath = Directory.GetCurrentDirectory() + "\\bin\\ini\\";
            if(!Directory.Exists(iniFilePath)) Directory.CreateDirectory(iniFilePath);
            iniFilePath += "config.ini";
            if(!File.Exists(iniFilePath))File.Create(iniFilePath).Close();
            IniFile iniFile = new IniFile(iniFilePath);
            string result = iniFile.Read("config", "transparentPet");
            if (result == null  || (result != "0" && result != "1"))
            {
                iniFile.Write("config", "transparentPet", "1");
                Global.transparentDic["transparentPet"] = true;
            }
            else
            {
                Global.transparentDic["transparentPet"] = result == "1";
            }
            iniFile = new IniFile(iniFilePath);
            result = iniFile.Read("config", "transparentSkill");
            if (result == null  || (result != "0" && result != "1"))
            {
                iniFile.Write("config", "transparentSkill", "1");
                Global.transparentDic["transparentSkill"] = true;
            }
            else
            {
                Global.transparentDic["transparentSkill"] = result == "1";
            }
        }

        private void CheckRunningWindow()
        {

            while (true)
            {
                if (Win32Util.FindWindowByWindowName("啦啦啦赛尔号登录器") == IntPtr.Zero)
                {
                    CheckRunningWindowCallback callback = delegate ()
                    {
                        this.Close();
                    };
                    this.Invoke(callback);
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            int msgKey = Convert.ToInt16(textBox.Text);
            if (msgKey == 1)
            {
                this.captureForm.Show();
                Win32Util.SetWindowPos(this.captureForm.Handle);
            }else if(msgKey == 2)
            {
                this.InitIniFile();
            }
            else if(msgKey == 3)
            {
                this.InitSkinsPlan();
            }
            else if(msgKey == 4)
            {
                this.seerfiddler.UninstallCertificate();
                this.Dispose();
            }
        }
        private void InitSkinsPlan()
        {
            List<DBServise.PetSkinsReplacePlan> plans = DBServise.PetSkinsPlanTableSelectData("");
            if (plans != null)
            {
                Dictionary<int, int> planDic = new Dictionary<int, int>();
                foreach (DBServise.PetSkinsReplacePlan plan in plans)
                {
                    planDic.Add(plan.petId, plan.skinsId);
                }
                Global.petSkinsPlanDic = planDic;
            }
        }
    }
}

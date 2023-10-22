using System;
using System.Configuration;
using System.Collections.Generic;
using Fiddler;
using System.Threading;
using System.Net;
using System.IO;

namespace seer_fiddler.core
{
    public class SeerFiddler
    {
        /// <summary>
        /// 对需在字典里调用的beforeRquest方法设置一个通用格式委托方法
        /// </summary>
        /// <param name="session">请求session</param>
        private delegate void AnalyzeBeforeRequestMethod(Session session, string[] pathList);
        private static FiddlerCaptureForm form;
        private delegate void addResponseCallback();
        /// <summary>
        /// key:请求字符串
        /// value:需要执行的reques请求
        /// </summary>
        private static Dictionary<string, AnalyzeBeforeRequestMethod> beforeRequestDictionary = new Dictionary<string, AnalyzeBeforeRequestMethod>()
        {
            { "resource" , (session , path) => AnalyzeResouceRequestHandle(session , path) }
        };
        private static Dictionary<string, AnalyzeBeforeRequestMethod> resourceRequestDictionary = new Dictionary<string, AnalyzeBeforeRequestMethod>()
        {
            { "login" , (session , path) => AnalyzeLoginRequestHandle(session , path) }
        };


        private delegate void AnalyzeBeforeResponseMethod(Session session, string[] pathList);
        private static Dictionary<string, AnalyzeBeforeResponseMethod> beforeResponseDictionary = new Dictionary<string, AnalyzeBeforeResponseMethod>()
        {
            { "resource" , (session , path) => AnalyzeResouceResponseHandle(session , path) }
        };
        private static Dictionary<string, AnalyzeBeforeResponseMethod> resourceReponseDictionary = new Dictionary<string, AnalyzeBeforeResponseMethod>()
        {
            { "fightResource" , (session , path) => AnalyzeFightResourceResponseHandle(session , path) }
        };
        private static Dictionary<string, AnalyzeBeforeResponseMethod> fightResourceReponseDictionary = new Dictionary<string, AnalyzeBeforeResponseMethod>()
        {
            { "pet" , (session , path) => AnalyzePetFightResourceResponseHandle(session , path) },
            { "skill" , (session , path) => AnalyzeSkillFightResourceResponseHandle(session , path) },
        };


        //private static string[] requestBeforePathList; 

        public SeerFiddler(FiddlerCaptureForm mainForm)
        {
            form = mainForm;
            //EnsureRootCertificate();
            this.InstallCertificate();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
            {
                FiddlerApplication.Shutdown();

            };

            FiddlerApplication.Startup(4201, FiddlerCoreStartupFlags.ChainToUpstreamGateway | FiddlerCoreStartupFlags.DecryptSSL);

            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            FiddlerApplication.BeforeResponse += FiddlerApplication_BeforeResponse;
        }

        private void InstallCertificate()
        {
            //System.Configuration
           
            Console.WriteLine(ConfigurationManager.AppSettings["UrlCapture.Cert"]);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UrlCapture.Cert"]))
            {
                FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.key", ConfigurationManager.AppSettings["UrlCapture.key"]);
                FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.cert", ConfigurationManager.AppSettings["UrlCapture.Cert"]);
            }
            if (!CertMaker.rootCertExists())
            {
                if (CertMaker.createRootCert())
                {
                    while (!CertMaker.trustRootCert()) ;

                }
                Console.WriteLine(FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null));
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if(config.AppSettings.Settings["UrlCapture.Cert"] == null)
                {
                    config.AppSettings.Settings.Add("UrlCapture.Cert", FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.Cert", null));
                }
                else
                {
                    config.AppSettings.Settings["UrlCapture.Cert"].Value = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.cert", null);
                }
                if (config.AppSettings.Settings["UrlCapture.key"] == null)
                {
                    config.AppSettings.Settings.Add("UrlCapture.key", FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null));
                }
                else
                {
                    config.AppSettings.Settings["UrlCapture.key"].Value = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        public void UninstallCertificate()
        {
            if (CertMaker.rootCertExists()) CertMaker.removeFiddlerGeneratedCerts(true);
            Console.WriteLine(FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", null));
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["UrlCapture.Cert"].Value = null;
            config.AppSettings.Settings["UrlCapture.key"].Value = null;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #region
        /*=========================================request处理================================================*/
        private static void FiddlerApplication_BeforeRequest(Session session)
        {
            if (session.isHTTPS && session.host == "seer.61.com")
            {
                new Thread(() =>
                {
                    if (form.Visible)
                    {
                        addResponseCallback callback = delegate ()
                        {
                            form.AddResponse(session.PathAndQuery);
                        };
                        form.Invoke(callback);
                    }

                }).Start();

                if (session.PathAndQuery.Contains("mp3"))
                {
                    session.Abort();
                }
                else
                {
                    string[] requestBeforePathList = session.PathAndQuery.Split('.')[0].Split('/');
                    session.bBufferResponse = true;
                    if (beforeRequestDictionary.TryGetValue(requestBeforePathList[1], out AnalyzeBeforeRequestMethod analyzeBeforeRequestMethod))
                    {
                        analyzeBeforeRequestMethod(session, requestBeforePathList);
                    }
                }


                //Console.WriteLine(session.PathAndQuery);
            }

        }
        private static void AnalyzeResouceRequestHandle(Session session, string[] pathList)
        {
            if (resourceRequestDictionary.TryGetValue(pathList[2], out AnalyzeBeforeRequestMethod analyzeBeforeRequestMethod))
            {
                analyzeBeforeRequestMethod(session, pathList);
            }
        }
        private static void AnalyzeLoginRequestHandle(Session session, string[] pathList)
        {
            //Console.WriteLine(pathList[3]);
            switch (pathList[3])
            {
                case "ServerAdPanel1":
                    session.Abort();
                    break;
            }
            //if (session.PathAndQuery.Contains("ServerAdPanel1"))
            //{
            //    //session.state = SessionStates.Aborted;
            //    session.Abort();
            //}
        }
        #endregion
        #region
        /*=========================================response处理================================================*/
        private static void FiddlerApplication_BeforeResponse(Session session)
        {
            //Console.WriteLine($"{session.isTunnel}  {session.host == "seer.61.com"}  {BitConverter.ToString(session.ResponseBody)}");
            if (session.isHTTPS && session.host == "seer.61.com")
            {
                string[] responseBeforePathList = session.PathAndQuery.Split(".".ToCharArray())[0].Split('/');
                if (beforeResponseDictionary.TryGetValue(responseBeforePathList[1], out AnalyzeBeforeResponseMethod analyzeBeforeResponseMethod))
                {
                    analyzeBeforeResponseMethod(session, responseBeforePathList);
                }

                //Console.WriteLine(session.PathAndQuery);
            }
        }
        private static void AnalyzeResouceResponseHandle(Session session, string[] pathList)
        {
            if (resourceReponseDictionary.TryGetValue(pathList[2], out AnalyzeBeforeResponseMethod analyzeBeforeResponseMethod))
            {
                analyzeBeforeResponseMethod(session, pathList);
            }
        }
        private static void AnalyzeFightResourceResponseHandle(Session session, string[] pathList)
        {
            if (fightResourceReponseDictionary.TryGetValue(pathList[3], out AnalyzeBeforeResponseMethod analyzeBeforeResponseMethod))
            {
                analyzeBeforeResponseMethod(session, pathList);
            }
        }

        private static void AnalyzePetFightResourceResponseHandle(Session session, string[] pathList)
        {
            //Console.WriteLine(pathList[4]);
            if (session.PathAndQuery.Contains("?"))
            {
                int petId = Convert.ToInt32(pathList[5].Replace(".swf", ""));
                if (Global.petSkinsPlanDic.TryGetValue(petId, out int skinsId))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://seer.61.com/resource/fightResource/pet/swf/{skinsId}.swf");
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                byte[] buffer = new byte[4096];
                                int bytesRead;

                                while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    memoryStream.Write(buffer, 0, bytesRead);
                                }

                                byte[] content = memoryStream.ToArray();
                                session.ResponseBody = content;
                            }
                        }
                    }else if(petId > 1000 && Global.transparentDic["transparentPet"])
                    {
                        session.ResponseBody = Properties.Resources.pet;
                    }
                }
                else if (petId > 1000 && Global.transparentDic["transparentPet"])
                {
                    session.ResponseBody = Properties.Resources.pet;
                }
            }
        }
        private static void AnalyzeSkillFightResourceResponseHandle(Session session, string[] pathList)
        {
            if(Global.transparentDic["transparentSkill"]) session.ResponseBody = Properties.Resources.skill;
        }
        #endregion
    }
}

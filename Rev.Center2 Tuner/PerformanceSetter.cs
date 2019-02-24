using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Intel.Overclocking.SDK.Monitoring;
using Intel.Overclocking.SDK.Tuning;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Windows.Threading;
using MySettingDLL;

namespace Rev.Center2_Tuner
{
    class PerformanceSetter: ApplicationContext
    {
        string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        const string userRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center";
        const string keyName = userRoot + "\\" + "Rev.Center2.0";

        private int performance_mode;
        private MySetting MySetting = new MySetting();

        string temp = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static EventLog outlog = new EventLog();
        private DispatcherTimer Read_timer = new DispatcherTimer();
        private DispatcherTimer checkService = new DispatcherTimer();
        public ITuningLibrary SetTuning;
        public MonitorInfo InfoDevice;
        private Rev.Center2_Tuner.ServiceInfo serviceInfo;
        private TuningInfo tuningInfo;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(
          string section,
          string key,
          string def,
          StringBuilder retStr,
          int bufferSize,
          string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileSection(
          string lpAppName,
          byte[] lpszReturnBuffer,
          int bufferSize,
          string filePath);

        public List<ClientTuningControl> TuningControls { get; set; }

        public List<ServiceInfoData> ServiceInfo { get; set; }

        public List<ClientMonitor> MonitorControls { get; set; }


        public PerformanceSetter()
        {
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            InitializeComponent();
            }

        private void InitializeComponent()
        {
            if (Convert.ToInt32(Registry.GetValue(keyName, "ThrottleStop", 1)) == 1)
            {

                foreach (var process in Process.GetProcessesByName("ThrottleStop"))
                {
                    process.Kill();
                }
                Process.Start(path + "/Throttlestop/ThrottleStop.exe");
            }
            this.checkService.Interval = TimeSpan.FromMilliseconds(100.0);
            this.checkService.Tick += new EventHandler(this.checkService_Tick);
            this.checkService.Start();

        }
        private void SetPerf()
        {
            performance_mode = Convert.ToInt32(Registry.GetValue(keyName, "PerformanceMode", 0));
            switch (performance_mode)
            {
                case 1:
                    object data = (object)0;
                    WMIEC.WMIReadECRAM(1115UL, ref data);
                    if (((long)Convert.ToUInt64(data) & 1L) != 1L)
                        MySetting.SilentModeOnOff();
                    Set_TuningID(48U, Convert.ToDecimal(35)); //cpu boost 
                    Set_TuningID(47U, Convert.ToDecimal(35));
                    break;
                case 2:
                    data = (object)0;
                    WMIEC.WMIReadECRAM(1115UL, ref data);
                    if (((long)Convert.ToUInt64(data) & 1L) == 1L)
                        MySetting.SilentModeOnOff();
                    Set_TuningID(48U, Convert.ToDecimal(35)); //cpu boost 
                    Set_TuningID(47U, Convert.ToDecimal(35));
                    break;
                case 3:
                    data = (object)0;
                    WMIEC.WMIReadECRAM(1115UL, ref data);
                    if (((long)Convert.ToUInt64(data) & 1L) == 1L)
                        MySetting.SilentModeOnOff();
                    Set_TuningID(48U, Convert.ToDecimal(50)); //cpu boost 
                    Set_TuningID(47U, Convert.ToDecimal(70));
                    break;
            }
            Application.Exit();

        }


        private void checkService_Tick(object sender, EventArgs e)
        {
            if (new ServiceController()
            {
                ServiceName = "XTU3SERVICE"
            }.Status == ServiceControllerStatus.Running)
            {
                this.checkService.Stop();

                this.init_xtu();

            }
           // this.checkService.Interval = TimeSpan.FromSeconds(1.0);
        }
        private void init_xtu()
        {
            this.InitializeComponent();

            this.SetTuning = (ITuningLibrary)TuningLibrary.Instance;

            this.Loaded_xtu();
        }

        private void Loaded_xtu()
        {
            //string CPU_name;
           // this.serviceInfo = new Rev.Center2_Tuner.ServiceInfo();
            //this.ServiceInfo = this.serviceInfo.GetServiceInfoList();
            //CPU_name = (string)this.ServiceInfo[1].Data;

            this.tuningInfo = new TuningInfo();
            this.TuningControls = this.tuningInfo.GetAvailableControls();
            this.TuningControls.ForEach((Action<ClientTuningControl>)(data => { }));
            SetPerf();

        }

        private bool Set_TuningID(uint ID, Decimal value)
        {
            bool bRequiresReboot = this.TuningControls.Find((Predicate<ClientTuningControl>)(x => (int)x.Id == (int)ID)).RequiresReboot;
            return this.SetTuning.Tune(ID, value, bRequiresReboot);
        }


        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            //Here you can do stuff if the tray icon is doubleclicked
        }

        
    }
}

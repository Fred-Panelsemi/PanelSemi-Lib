using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Input;

namespace PanelSemiLib.ViewModel
{
    internal class MainProcess :  INotifyPropertyChanged
    {
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string PanelSemiLib_Version { get; }

        //Panelsemi_ColorAdjustment
        public ICommand CallColor { get; set; }
        public ICommand CallAIO {  get; set; }

        public ICommand CallPrimaryTool { get; set; }

        public ICommand CallFirmware { get; set; }
        public ICommand CallVersion { get; set; }
        public MainProcess() 
        {
            /* 撈出版本號　=> 由AssemblyInfo.cs中設定 */
            var asm = Assembly.GetExecutingAssembly();
            PanelSemiLib_Version = $"v{asm.GetName().Version}";

            CallColor = new RelayCommand(CallColor_Action);
            CallPrimaryTool = new RelayCommand(CallPrimaryTool_Action);
            CallFirmware = new DelegateCommand<string>(CallFirmware_Action);
            CallVersion = new RelayCommand(CallVersion_Action);
            CallAIO = new DelegateCommand<string>(CallAIO_Action);

            string dirPath = @"Lib_Exe\AIO_UI";
            if (Directory.Exists(dirPath))
            {
                Console.WriteLine("The directory {0} already exists.", dirPath);
            }
            else
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine("The directory {0} was created.", dirPath);
            }
            dirPath = @"Lib_Exe\ColorAdjustment";
            if (Directory.Exists(dirPath))
            {
                Console.WriteLine("The directory {0} already exists.", dirPath);
            }
            else
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine("The directory {0} was created.", dirPath);
            }
            dirPath = @"Lib_Exe\Splicing";
            if (Directory.Exists(dirPath))
            {
                Console.WriteLine("The directory {0} already exists.", dirPath);
            }
            else
            {
                Directory.CreateDirectory(dirPath);
                Console.WriteLine("The directory {0} was created.", dirPath);
            }
        }

        private void CallColor_Action()
        {
            System.Diagnostics.Process.Start(@"Lib_Exe\ColorAdjustment\Debug\PanelSemi_Coloradjustment.exe");
        }

        private void CallAIO_Action(string paRa)
        {
            
            System.Diagnostics.Process.Start($"Lib_Exe\\AIO_UI\\{paRa}\\AIO_UI.exe");
        }

        private void CallPrimaryTool_Action()
        {
            System.Diagnostics.Process.Start($"Lib_Exe\\PrimaryTool\\v0.0.1.9\\Primary.exe");
        }

        private void CallVersion_Action()
        {
            
            Process.Start("https://panelsemi.sharepoint.com/:x:/r/sites/TD60/Shared%20Documents/89%20Firmware%20%E7%89%88%E6%9C%AC%20List/%E6%A9%9F%E7%A8%AE%E7%94%A8%20code%20%E7%89%88%E6%9C%AC%E6%95%B4%E7%90%86.xlsx?d=wba71ea5220cb45f0be9ccfb69b084e59&csf=1&web=1&e=dG39lD");
        }

        private void CallFirmware_Action(string paRa)
        {
            switch(paRa)
            {
                case "ATG":
                    Process.Start("https://panelsemi.sharepoint.com/:f:/r/sites/TD60/Shared%20Documents/89%20Firmware%20%E7%89%88%E6%9C%AC%20List/ATG%20bin%20file?csf=1&web=1&e=zoMELM");
                    break;
                case "Flash":
                    Process.Start("https://panelsemi.sharepoint.com/:f:/r/sites/TD60/Shared%20Documents/89%20Firmware%20%E7%89%88%E6%9C%AC%20List/Flash%20bin%20file?csf=1&web=1&e=UnpDtA");
                    break;
                case "FPGA":
                    Process.Start("https://panelsemi.sharepoint.com/:f:/r/sites/TD60/Shared%20Documents/89%20Firmware%20%E7%89%88%E6%9C%AC%20List/FPGA%20bin%20file?csf=1&web=1&e=SoPpgu");
                    break;
                case "MCU":
                    Process.Start("https://panelsemi.sharepoint.com/:f:/r/sites/TD60/Shared%20Documents/89%20Firmware%20%E7%89%88%E6%9C%AC%20List/MCU%20hex%20file?csf=1&web=1&e=dPtpwE");
                    break;
                case "Scaler":
                    Process.Start("https://panelsemi.sharepoint.com/:f:/r/sites/TD60/Shared%20Documents/89%20Firmware%20%E7%89%88%E6%9C%AC%20List/Scaler%20hex%20file?csf=1&web=1&e=UB5phq");
                    break;
            }
        }
    }
}

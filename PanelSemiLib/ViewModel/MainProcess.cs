using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public MainProcess() 
        {
            /* 撈出版本號　=> 由AssemblyInfo.cs中設定 */
            var asm = Assembly.GetExecutingAssembly();
            PanelSemiLib_Version = $"v{asm.GetName().Version}";

            CallColor = new RelayCommand(CallColor_Action);
            CallPrimaryTool = new RelayCommand(CallPrimaryTool_Action);
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
    }
}

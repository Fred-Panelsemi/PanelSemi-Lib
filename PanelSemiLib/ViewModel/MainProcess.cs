using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PanelSemiLib.ViewModel
{
    internal class MainProcess
    {
        public string PanelSemiLib_Version { get; }

        //Panelsemi_ColorAdjustment
        public ICommand CallColor { get; set; }
        public MainProcess() 
        {
            /* 撈出版本號　=> 由AssemblyInfo.cs中設定 */
            var asm = Assembly.GetExecutingAssembly();
            PanelSemiLib_Version = $"v{asm.GetName().Version}";

            CallColor = new RelayCommand(CallColor_Action);
            
        }

        private void CallColor_Action()
        {

        }
    }
}

using GalaSoft.MvvmLight;
using ModularSynth.Modules;
using ModularSynth.Modules.Gates;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels.Browser
{
    public class ModuleBrowserViewModel : ViewModelBase
    {
        public ModuleBrowserViewModel()
        {
            //TOOD: do we do a messenger or something here to add modules??
            ButtonModule buttonModule = new ButtonModule("Test Button", "Just a test module with a button");
            Modules = new List<ModuleBase>();
            Modules.Add(buttonModule);
        }

        private List<ModuleBase> modules;
        public List<ModuleBase> Modules
        {
            get => modules;
            set
            {
                Set(ref modules, value);
            }
        }
    }
}

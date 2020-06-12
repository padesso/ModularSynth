using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ModularSynth.Modules;
using ModularSynth.Modules.Gates;
using ModularSynth.Services.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels.Browser
{
    public class ModuleBrowserViewModel : ViewModelBase
    {
        private IModuleService modServ;

        public ModuleBrowserViewModel(IModuleService moduleService)
        {
            modServ = moduleService;

            //TOOD: update module service so we have ability to load distinct modules as well as those in the rack
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

        private ModuleBase selectedModule;
        public ModuleBase SelectedModule
        {
            get => selectedModule;
            set
            {
                Set(ref selectedModule, value);
            }
        }
    }
}

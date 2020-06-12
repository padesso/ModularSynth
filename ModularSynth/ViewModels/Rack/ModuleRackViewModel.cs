using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ModularSynth.Modules;
using ModularSynth.Services.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels.Rack
{
    public class ModuleRackViewModel : ViewModelBase
    {
        private IModuleService modServ;

        public ModuleRackViewModel(IModuleService moduleService)
        {
            modServ = moduleService;
        }

        public List<ModuleBase> Modules
        {
            get => modServ.GetModules();
            //set
            //{
            //    Set(ref modules, value);
            //}
        }
    }
}

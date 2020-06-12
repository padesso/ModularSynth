using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ModularSynth.Modules;
using ModularSynth.Services.Modules;
using ModularSynth.Services.Rack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ModularSynth.ViewModels.Rack
{
    public class ModuleRackViewModel : ViewModelBase
    {
        private RackService rackServ;

        public ModuleRackViewModel(IRackService rackService)
        {
            rackServ = (RackService)rackService;
        }

        public ObservableCollection<ModuleBase> Modules
        {
            get => rackServ.Modules;
            set
            {
                Set(ref rackServ.Modules, value);
            }
        }
    }
}

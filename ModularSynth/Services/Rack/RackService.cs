using ModularSynth.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ModularSynth.Services.Rack
{
    public class RackService : IRackService
    {        
        public RackService()
        {
            Modules = new ObservableCollection<ModuleBase>();
        }

        public void AddModuleToRack(ModuleBase module)
        {
            Modules.Add(module);
        }

        public void RemoveModuleFromRack(ModuleBase module)
        {
            Modules.Remove(module);
        }

        public ObservableCollection<ModuleBase> Modules;
    }
}

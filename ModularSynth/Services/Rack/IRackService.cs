using ModularSynth.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.Services.Rack
{
    public interface IRackService
    {
        public void AddModuleToRack(ModuleBase module);
        public void RemoveModuleFromRack(ModuleBase module);
    }
}

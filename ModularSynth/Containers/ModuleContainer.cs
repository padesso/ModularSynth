using ModularSynth.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.Containers
{
    public class ModuleContainer
    {
        List<ModuleBase> Modules { get; set; }

        public ModuleContainer()
        {
            Modules = new List<ModuleBase>();
        }

        public bool AddModule(ModuleBase module)
        {
            //TODO: validate module

            Modules.Add(module);

            return true;
        }
    }
}

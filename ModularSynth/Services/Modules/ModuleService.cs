using ModularSynth.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.Services.Modules
{
    public class ModuleService : IModuleService
    {
        private List<ModuleBase> modules;

        public ModuleService()
        {
            //TODO: load from save
            modules = new List<ModuleBase>();
        }

        public void AddModule(ModuleBase module)
        {
            modules.Add(module);
        }

        public List<ModuleBase> GetModules()
        {
            return modules;
        }
    }
}

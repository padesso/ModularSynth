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
            //TODO: load from disk/web/etc for modules that are available
            modules = new List<ModuleBase>();
        }

        public List<ModuleBase> GetAvailableModules()
        {
            return modules;
        }
    }
}

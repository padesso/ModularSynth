using ModularSynth.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.Services.Modules
{
    public interface IModuleService
    {
        public List<ModuleBase> GetAvailableModules();
    }
}

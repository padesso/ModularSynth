using ModularSynth.Modules.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.Modules
{
    public abstract class ModuleBase
    {
        public List<Port> InputPorts;
        public List<Port> OutputPorts;
    }
}

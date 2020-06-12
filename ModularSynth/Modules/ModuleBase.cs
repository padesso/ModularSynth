using ModularSynth.Modules.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ModularSynth.Modules
{
    public abstract class ModuleBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Port> InputPorts;
        public List<Port> OutputPorts;
    }
}

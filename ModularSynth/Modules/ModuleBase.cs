using ModularSynth.Modules.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ModularSynth.Modules
{
    public abstract class ModuleBase
    {
        public string Name;
        public List<Port> InputPorts;
        public List<Port> OutputPorts;
        public abstract ListViewItem ListViewItem { get; }

    }
}

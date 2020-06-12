using ModularSynth.Controls;
using ModularSynth.Modules.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ModularSynth.Modules.Gates
{
    public class ButtonModule : ModuleBase
    {
        public ButtonModule(string name, string description)
        {
            Name = name;
            Description = description;
            InputPorts = new List<Components.Port>();
            OutputPorts = new List<Components.Port>();

            Port outputPort = new Port("Signal Out", Port.PortDirection.Out, Port.PortType.ControlVoltagePort);
            OutputPorts.Add(outputPort);
        }
    }
}

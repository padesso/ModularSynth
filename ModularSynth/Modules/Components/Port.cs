using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.Modules.Components
{
    public class Port
    {
        public enum PortType
        {
            ControlVoltagePort,
            AudioPort
        }

        public string Name { get; set; }
        public PortType Type { get; set; }
        
        public Port(string name, PortType portType)
        {

        }

        public Port()
        {
            Name = "Default";
            Type = PortType.ControlVoltagePort;
        }
    }
}

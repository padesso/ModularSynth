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

        public enum PortDirection
        {  
            In,
            Out        
        }

        public string Name { get; set; }
        public PortDirection Direction { get; set; }
        public PortType Type { get; set; }
        
        public Port(string name, PortDirection portDirection, PortType portType)
        {
            Name = name;
            Direction = portDirection;
            Type = portType;
        }

        public Port()
        {
            Name = "Default";
            Direction = PortDirection.Out;
            Type = PortType.ControlVoltagePort;
        }
    }
}

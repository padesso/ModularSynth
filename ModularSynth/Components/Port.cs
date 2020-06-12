using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.Components
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
        public float Value;

        public Port(string name, PortDirection portDirection, PortType portType, float initialValue = 0f)
        {
            Name = name;
            Direction = portDirection;
            Type = portType;
            Value = initialValue;
        }

        public Port()
        {
            Name = "Default";
            Direction = PortDirection.Out;
            Type = PortType.ControlVoltagePort;
            Value = 0f;
        }
    }
}

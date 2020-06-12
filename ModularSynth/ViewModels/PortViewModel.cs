using GalaSoft.MvvmLight;
using ModularSynth.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels
{
    public class PortViewModel : ViewModelBase
    {
        private Port port;

        public PortViewModel()
        {
            //TODO: Default port for now.
            port = new Port("Test Port", Port.PortDirection.Out, Port.PortType.ControlVoltagePort, 1.0f);
        }

        public float PortValue
        {
            get => port.Value;
            set
            {
                Set(ref port.Value, value);
            }
        }
    }
}

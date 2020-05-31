using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels
{
    public class PortViewModel : ViewModelBase
    {
        public PortViewModel()
        {
            PortValue = 0.5f;
        }

        private float portValue;
        public float PortValue
        {
            get => portValue;
            set
            {
                Set(ref portValue, value);
            }
        }
    }
}

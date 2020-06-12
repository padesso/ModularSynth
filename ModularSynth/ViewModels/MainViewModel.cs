using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Wpf;
using ModularSynth.Containers;
using ModularSynth.Modules;
using ModularSynth.Modules.Gates;
using NAudio.SoundFont;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModularSynth.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ModuleContainer moduleContainer;

        public MainViewModel()
        {
            moduleContainer = new ModuleContainer();
            Modules = new List<ModuleBase>();

            //TEST Modules
            ButtonModule buttonModule = new ButtonModule("Test Button");           
            AddModule(buttonModule);
        }

        private List<ModuleBase> modules;
        public List<ModuleBase> Modules
        {
            get => modules;
            set
            {
                Set(ref modules, value);
            }
        }

        private bool AddModule(ModuleBase module)
        {
            if(moduleContainer.AddModule(module))
            {
                //TODO: try to add module to UI but remove from module container if it fails to add and handle multiple items
                Modules.Add(module);
            }

            return true;
        }
    }
}

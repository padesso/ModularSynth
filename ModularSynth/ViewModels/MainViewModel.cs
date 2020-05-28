using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Wpf;
using ModularSynth.Containers;
using ModularSynth.Modules;
using ModularSynth.Modules.Gates;
using ModularSynth.WaveProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModularSynth.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private WaveOut waveOut;
        private WaveformWaveProvider waveformWaveProvider;

        private ModuleContainer moduleContainer;

        public MainViewModel()
        {
            moduleContainer = new ModuleContainer();
            Modules = new List<UserControl>();

            //TEST Modules
            ButtonModule buttonModule = new ButtonModule();           
            AddModule(buttonModule);

            StartStopWaveCommand = new RelayCommand(StartPauseWave);

            waveformWaveProvider = new WaveformWaveProvider(Waveform.Square); 
            waveformWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
            waveOut = new WaveOut();
            waveOut.Init(waveformWaveProvider);

            //Start values
            Frequency = 2;
            Amplitude = 2f;

            waveformWaveProvider.Frequency = Frequency;
            waveformWaveProvider.Amplitude = Amplitude;

            //Test Chart
            GenerateWave();
        }

        private List<UserControl> modules;
        public List<UserControl> Modules
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
                Modules.Add(module.UserControl);
            }

            return true;
        }

        private void GenerateWave()
        {
            //TODO: handle different types of waves and proper number of samples and all the hard stuff...

            WavePointSeriesCollection = new SeriesCollection();
            IChartValues waveValues = new ChartValues<float>();

            Random rand = new Random(DateTime.Now.Millisecond);

            int samples = 360;
            for(float sampleIndex = 0; sampleIndex <= samples; sampleIndex += 1)
            {
                float x_rad = (float)(sampleIndex * Math.PI / 180.0);

                //Sine
                //float x = (float)(Amplitude * Math.Sin(Frequency * x_rad));

                //Triangle
                //float x = (float)( (Math.Abs( ((Frequency * sampleIndex) % 4) - 2) - 1) * Amplitude);

                //Sawtooth
                //float x = (float)(-1 * ((Amplitude * 2) / Math.PI) * Math.Atan(1 / Math.Tan((x_rad * Math.PI / Frequency))));
                //float x = (float)(Amplitude * (Frequency * x_rad) % 1);

                //Square
                float x = (float)(Amplitude * Math.Sign(Math.Sin((2 * Math.PI * Frequency) * x_rad)));

                //Noize!
                //float x = (float)rand.NextDouble() * Amplitude;

                waveValues.Add(x);
            }

            WavePointSeriesCollection.Add(new LineSeries
            {
                Values = waveValues,
                LineSmoothness = 0.0, //0: straight lines, 1: really smooth lines
                PointGeometry = DefaultGeometries.None,
                PointForeground = Brushes.LightBlue
            });
        }

        private SeriesCollection wavePointSeriesCollection;
        public SeriesCollection WavePointSeriesCollection 
        {
            get => wavePointSeriesCollection;
            set
            {
                Set(ref wavePointSeriesCollection, value);
            }
        }

        public RelayCommand StartStopWaveCommand
        {
            get;
            private set;
        }

        private float frequency;
        public float Frequency
        {
            get => frequency;
            set
            {
                Set(ref frequency, value);
                waveformWaveProvider.Frequency = Frequency;
                GenerateWave();
            }
        }

        private float amplitude;
        public float Amplitude
        {
            get => amplitude;
            set
            {
                Set(ref amplitude, value);
                waveformWaveProvider.Amplitude = Amplitude;
                GenerateWave();
            }
        }

        private void StartPauseWave()
        {
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {     
                waveOut.Pause();
            }
            else
            {
                waveOut.Play();
            }
        }
    }
}

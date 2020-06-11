using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Wpf;
using ModularSynth.Containers;
using ModularSynth.Modules;
using ModularSynth.Modules.Gates;
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
        private WaveOut waveOut;

        private ModuleContainer moduleContainer;

        private SignalGenerator signalGenerator;

        public MainViewModel()
        {
            //SIGNAL GENERATOR TEST
            signalGenerator = new SignalGenerator(); //Leave default for now but add option to change...  maybe globally?
            signalGenerator.Frequency = Frequency;
            signalGenerator.Gain = Amplitude;
            signalGenerator.Type = SignalGeneratorType.Sin;

            //Wave player - TODO: move to mixer module or something
            waveOut = new WaveOut();
            waveOut.Init(signalGenerator);

            moduleContainer = new ModuleContainer();
            Modules = new List<ListViewItem>();

            //TEST Modules
            ButtonModule buttonModule = new ButtonModule();           
            AddModule(buttonModule);

            StartStopWaveCommand = new RelayCommand(StartPauseWave);

            //Start values
            Frequency = 440;
            Amplitude = 2f;

            //Test Chart
            RenderWave();
        }

        private bool wavePlaying;
        public bool WavePlaying
        {
            get => wavePlaying;
            set
            {
                Set(ref wavePlaying, value);
                StartPauseWave();
            }
        }

        private List<ListViewItem> modules;
        public List<ListViewItem> Modules
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
                Modules.Add(module.ListViewItem);
            }

            return true;
        }

        private IChartValues waveValues;

        private void RenderWave()
        {
            //TODO: handle different types of waves and proper number of samples and all the hard stuff...

            WavePointSeriesCollection = new SeriesCollection();
            if (waveValues == null)
            {
                waveValues = new ChartValues<float>();
            }
            else
            {
                waveValues.Clear();
            }

            Random rand = new Random(DateTime.Now.Millisecond);

            int samples = 360;
            for(float sampleIndex = 0; sampleIndex <= samples; sampleIndex++)
            {
                float x_rad = (float)(sampleIndex * Math.PI / 180.0);

                //Sine
                float y = (float)(Amplitude * Math.Sin(Frequency * x_rad));

                //Triangle
                //float x = (float)( (Math.Abs( ((Frequency * sampleIndex) % 4) - 2) - 1) * Amplitude);

                //Sawtooth
                //float x = (float)(-1 * ((Amplitude * 2) / Math.PI) * Math.Atan(1 / Math.Tan((x_rad * Math.PI / Frequency))));
                //float x = (float)(Amplitude * (Frequency * x_rad) % 1);

                //Square
                //float x = (float)(Amplitude * Math.Sign(Math.Sin((2 * Math.PI * Frequency) * x_rad)));

                //Noize!
                //float x = (float)rand.NextDouble() * Amplitude;

                waveValues.Add(y);
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
                signalGenerator.Frequency = Frequency;
                RenderWave();
            }
        }

        private float amplitude;
        public float Amplitude
        {
            get => amplitude;
            set
            {
                Set(ref amplitude, value);
                signalGenerator.Gain = Amplitude;
                RenderWave();
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

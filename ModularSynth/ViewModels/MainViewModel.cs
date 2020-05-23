using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Wpf;
using ModularSynth.WaveProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace ModularSynth.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private WaveOut waveOut;
        private SineWaveProvider32 sineWaveProvider;

        public MainViewModel()
        {
            StartStopSinCommand = new RelayCommand(StartStopSineWave);

            sineWaveProvider = new SineWaveProvider32(); //TODO: pass initial freq and amplitude to ctor?  
            sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
            waveOut = new WaveOut();
            waveOut.Init(sineWaveProvider);

            //Start values
            Frequency = 1000;
            Amplitude = 0.25f;

            sineWaveProvider.Frequency = Frequency;
            sineWaveProvider.Amplitude = Amplitude;

            //Test Chart
            WavePointSeriesCollection = new SeriesCollection();
            IChartValues sineValues = new ChartValues<float>();
            WavePointSeriesCollection.Add(new LineSeries
            {
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 0.5, //0: straight lines, 1: really smooth lines
                PointGeometry = DefaultGeometries.None,
                PointForeground = Brushes.LightBlue
            });
        }

        public SeriesCollection WavePointSeriesCollection { get; set; }

        public RelayCommand StartStopSinCommand
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
                sineWaveProvider.Frequency = Frequency;
            }
        }

        private float amplitude;
        public float Amplitude
        {
            get => amplitude;
            set
            {
                Set(ref amplitude, value);
                sineWaveProvider.Amplitude = Amplitude;
            }
        }

        private void StartStopSineWave()
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

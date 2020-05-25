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
            StartStopWaveCommand = new RelayCommand(StartPauseWave);

            sineWaveProvider = new SineWaveProvider32(); //TODO: pass initial freq and amplitude to ctor?  
            sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
            waveOut = new WaveOut();
            waveOut.Init(sineWaveProvider);

            //Start values
            Frequency = 5;
            Amplitude = 2f;

            sineWaveProvider.Frequency = Frequency;
            sineWaveProvider.Amplitude = Amplitude;

            //Test Chart
            GenerateTestWave();
        }

        private void GenerateTestWave()
        {
            //TODO: handle different types of waves

            WavePointSeriesCollection = new SeriesCollection();
            IChartValues sineValues = new ChartValues<float>();

            int samples = 360;
            for(float x = 0; x <= samples; x += 1)
            {
                float x_rad = (float)(Frequency * x * (Math.PI) / 180);
                sineValues.Add((float)(Amplitude * (Math.Sin(x_rad))));
            }

            WavePointSeriesCollection.Add(new LineSeries
            {
                Values = sineValues,
                LineSmoothness = 0.5, //0: straight lines, 1: really smooth lines
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
                sineWaveProvider.Frequency = Frequency;
                GenerateTestWave();
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
                GenerateTestWave();
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

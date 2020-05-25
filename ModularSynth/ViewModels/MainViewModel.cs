﻿using GalaSoft.MvvmLight;
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
            Frequency = 1;
            Amplitude = 2f;

            sineWaveProvider.Frequency = Frequency;
            sineWaveProvider.Amplitude = Amplitude;

            //Test Chart
            GenerateWave();
        }

        private void GenerateWave()
        {
            //TODO: handle different types of waves and proper number of samples and all the hard stuff...

            WavePointSeriesCollection = new SeriesCollection();
            IChartValues waveValues = new ChartValues<float>();
            
            int samples = 360;
            for(float sampleIndex = 0; sampleIndex <= samples; sampleIndex += 1)
            {
                float x_rad = (float)(sampleIndex * (Math.PI) / 180.0);

                //Sine
                //float x = (float)(Amplitude * Math.Sin(Frequency * x_rad));

                //Triangle
                float x = (float)( (Math.Abs( ((Frequency * sampleIndex) % 4) - 2) - 1) * Amplitude);

                waveValues.Add(x);
            }

            WavePointSeriesCollection.Add(new LineSeries
            {
                Values = waveValues,
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
                sineWaveProvider.Amplitude = Amplitude;
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

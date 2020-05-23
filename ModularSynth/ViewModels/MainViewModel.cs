using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ModularSynth.WaveProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private WaveOut waveOut;

        public MainViewModel()
        {
            StartStopSinCommand = new RelayCommand(StartStopSineWave);
        }

        public RelayCommand StartStopSinCommand
        {
            get;
            private set;
        }

        private void StartStopSineWave()
        {
            if (waveOut == null)
            {
                var sineWaveProvider = new SineWaveProvider32();
                sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
                sineWaveProvider.Frequency = 1000;
                sineWaveProvider.Amplitude = 0.25f;
                waveOut = new WaveOut();
                waveOut.Init(sineWaveProvider);
                waveOut.Play();
            }
            else
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
        }
    }
}

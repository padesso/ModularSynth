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
        }

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

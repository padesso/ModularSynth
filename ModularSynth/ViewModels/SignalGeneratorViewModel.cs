using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels
{
    public class SignalGeneratorViewModel : ViewModelBase
    {
        //TODO: move waveout to mixer module...
        private WaveOut waveOut;
        private SignalGenerator signalGenerator;

        public SignalGeneratorViewModel()
        {
            //SIGNAL GENERATOR TEST
            signalGenerator = new SignalGenerator(); //Leave default for now but add option to change...  maybe globally?
            signalGenerator.Frequency = Frequency;
            signalGenerator.Gain = Amplitude;
            signalGenerator.Type = SignalGeneratorType.Sin;

            //Wave player - TODO: move to mixer module or something
            waveOut = new WaveOut();
            waveOut.Init(signalGenerator);

            StartStopWaveCommand = new RelayCommand(StartPauseWave);

            //Start values
            Frequency = 440;
            Amplitude = 2f;
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
                //RenderWave();
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
                //RenderWave();
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

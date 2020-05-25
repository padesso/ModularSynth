using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.WaveProviders
{
    public enum Waveform
    {
        Sine,
        Triangle,
        Sawtooth,
        Square,
        Noise
    }

    public class WaveformWaveProvider : WaveProvider32
    {
        
        private int sample;

        public WaveformWaveProvider(Waveform waveform)
        {
            Waveform = waveform;
            Frequency = 1000;
            Amplitude = 0.25f; // let's not hurt our ears
        }

        private Waveform waveform;
        public Waveform Waveform
        {
            get
            {
                return waveform;
            }

            set
            {
                waveform = value;
            }
        }

        //TODO: clamp
        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                //buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                buffer[n + offset] = GetWaveValue(sample, sampleRate);
                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }

        private float GetWaveValue(int sample, int sampleRate)
        {
            float val = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));

            return val;
        }
    }
}

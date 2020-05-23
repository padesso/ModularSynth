﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.WaveProviders
{
    public class SineWaveProvider32 : WaveProvider32
    {
        int sample;

        public SineWaveProvider32()
        {
            Frequency = 1000;
            Amplitude = 0.25f; // let's not hurt our ears
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }

        public float[] GetAmplitudes()
        {
            int chartSample = 0;
            float[] amps = new float[250];// WaveFormat.SampleRate];

            for(int i = 0; i < 250; i++)
            {
                amps[i] = (float)(Amplitude * Math.Sin((2 * Math.PI * chartSample * Frequency) / 250));
                chartSample++;
            }

            return amps;
        }
    }
}

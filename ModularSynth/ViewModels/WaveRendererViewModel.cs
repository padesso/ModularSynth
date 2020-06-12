using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace ModularSynth.ViewModels
{
    public class WaveRendererViewModel : ViewModelBase
    {
        public WaveRendererViewModel()
        {
        }

        #region WaveRendering
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
            for (float sampleIndex = 0; sampleIndex <= samples; sampleIndex++)
            {
                float x_rad = (float)(sampleIndex * Math.PI / 180.0);

                //Sine
                //float y = (float)(Amplitude * Math.Sin(Frequency * x_rad));

                //Triangle
                //float x = (float)( (Math.Abs( ((Frequency * sampleIndex) % 4) - 2) - 1) * Amplitude);

                //Sawtooth
                //float x = (float)(-1 * ((Amplitude * 2) / Math.PI) * Math.Atan(1 / Math.Tan((x_rad * Math.PI / Frequency))));
                //float x = (float)(Amplitude * (Frequency * x_rad) % 1);

                //Square
                //float x = (float)(Amplitude * Math.Sign(Math.Sin((2 * Math.PI * Frequency) * x_rad)));

                //Noize!
                //float x = (float)rand.NextDouble() * Amplitude;

                //waveValues.Add(y);
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
        #endregion
    }
}

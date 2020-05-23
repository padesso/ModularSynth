using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            TestString = "this is a test";
        }

        private string testString;

        public string TestString
        {
            get => testString;
            set => Set(ref testString, value);
        }
    }
}

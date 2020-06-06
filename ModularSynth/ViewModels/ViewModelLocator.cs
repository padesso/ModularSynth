using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels
{
    public class ViewModelLocator
    {       
        public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
        public PortViewModel PortViewModel => App.ServiceProvider.GetRequiredService<PortViewModel>();
    }
}

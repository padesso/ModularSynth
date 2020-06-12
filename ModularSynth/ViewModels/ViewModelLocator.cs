using Microsoft.Extensions.DependencyInjection;
using ModularSynth.ViewModels.Browser;
using ModularSynth.ViewModels.Rack;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModularSynth.ViewModels
{
    public class ViewModelLocator
    {       
        public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
        public PortViewModel PortViewModel => App.ServiceProvider.GetRequiredService<PortViewModel>();
        public ModuleBrowserViewModel ModuleBrowserViewModel => App.ServiceProvider.GetRequiredService<ModuleBrowserViewModel>();
        public ModuleRackViewModel ModuleRackViewModel => App.ServiceProvider.GetRequiredService<ModuleRackViewModel>();
    }
}

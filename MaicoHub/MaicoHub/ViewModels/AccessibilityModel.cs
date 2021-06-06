using MaicoHub.Services;
using MaicoHub.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MaicoHub.ViewModels
{
    class AccessibilityModel:BaseViewModel
    {
        public AccessibilityModel()
        {
            Accept = new Command(() =>
            {
                DependencyService.Get<IAccessibility>().Active();
                Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            });
        }
        public ICommand Accept { get; }
    }
}

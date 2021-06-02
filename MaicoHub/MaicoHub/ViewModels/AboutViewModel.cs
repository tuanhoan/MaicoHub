using MaicoHub.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MaicoHub.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            var number = "900";
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            CallPhone = new Command(() =>
            {
                DependencyService.Get<IPhoneCall>().MakeCall(number);
            });
        }

        public ICommand OpenWebCommand { get; }
        public ICommand CallPhone { get; }

    }
}
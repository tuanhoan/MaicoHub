using Android.Widget;
using MaicoHub.Services;
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
            Title = "MaicoHub";
            Token = App.token;
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            MaicoHub.App.information.phoneNumber = number;
            CallPhone = new Command(() =>
            {
                DependencyService.Get<IPhoneCall>().MakeCall(number);
            });
            Record = new Command(() =>
            {
                DependencyService.Get<IPhoneCall>().StartRecorder();
            });
            CopyToken = new Command(() =>
            {
                Clipboard.SetTextAsync(Token);
                Toast.MakeText(Android.App.Application.Context, "sao chép thành công: " + Clipboard.GetTextAsync().Result, ToastLength.Short).Show();
            });
        }

        public ICommand OpenWebCommand { get; }
        public ICommand CallPhone { get; }
        public ICommand Record { get; }
        public ICommand CopyToken { get; }

    }
}
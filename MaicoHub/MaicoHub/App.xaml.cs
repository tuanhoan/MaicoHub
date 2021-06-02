using MaicoHub.Services;
using MaicoHub.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaicoHub
{
    public partial class App : Application
    {
        public static bool IsCall = false;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            if (IsCall == true)
            {
                Console.WriteLine("Vô");
                DependencyService.Get<IPhoneCall>().LoadFile();
                IsCall = false;
            }
        }
    }
}

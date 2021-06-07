using MaicoHub.Services;
using MaicoHubAPI.Model;
using System;
using Xamarin.Forms;

namespace MaicoHub
{
    public partial class App : Application
    {
        public static bool IsCall = false;
        public static Information information = new Information();
        public static string token = null;
        public static bool isAccessibility = false;
        public static IPhoneRecord phoneRecord;

        public App()
        {
            InitializeComponent();
            phoneRecord = DependencyService.Get<IPhoneRecord>();
            MainPage = new AppShell(); 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            //if(IsCall)
            //{
            //    phoneRecord.StartRecord();
            //}
        }

        protected override void OnResume()
        {
            //if (IsCall == true)
            //{
            //    phoneRecord.StopRecord();

            //    IsCall = false;
            //}
        }
    }
}

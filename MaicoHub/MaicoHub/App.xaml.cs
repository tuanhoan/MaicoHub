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
                //DependencyService.Get<IPhoneCall>().LoadFile();
                //GoogleDriveService googleDriveService = new GoogleDriveService();
                //googleDriveService.Test();

                //GoogleDriveService driveService = new GoogleDriveService();
                //driveService.Test();
                //driveService.Upload(information.filePath, "1ThUOQ_eEodHm4UVMt7wp4iTzW-Aoc94x");

                IsCall = false;
            }
        }
    }
}

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaicoHub.Droid.Service;
using MaicoHub.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall))]
namespace MaicoHub.Droid.Service
{
    class PhoneCall:IPhoneCall
    {
        [Obsolete]
        public void LoadFile()
        {
            var folder = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "Music/Recordings/Call Recordings";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filePath = Directory.GetFiles(folder).Last();
        } 

        public void MakeCall(string PhoneNumber)
        {
            try
            {
                var URI = Android.Net.Uri.Parse(String.Format("tel:" + PhoneNumber));
                var intent = new Intent(Intent.ActionCall, URI);
                intent.SetFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
                MaicoHub.App.IsCall = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
using Android.Content;
using Android.Media;
using Android.Widget;
using MaicoHub.Droid.Service;
using MaicoHub.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall))]
namespace MaicoHub.Droid.Service
{
    class PhoneCall : IPhoneCall
    {
        public MediaRecorder recorder = new MediaRecorder();
        [Obsolete]
        public void LoadFile()
        {
            //var folder = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "Music/Recordings/Call Recordings";
            var folder = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "Music/Recordings/Call Recordings/";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filePath = Directory.GetFiles(folder).Last();
            MaicoHub.App.information.filePath = filePath;
        }
        [Obsolete]
        public async Task StartRecorder()
        {
            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Download/";
            try
            {
                recorder.Reset();
                recorder.SetAudioSource(AudioSource.VoiceRecognition);
                recorder.SetOutputFormat(OutputFormat.Default);
                recorder.SetAudioEncoder(AudioEncoder.Default);
                recorder.SetOutputFile(path + "test.mp3");
                recorder.Prepare();
                recorder.Start(); // Exception Hits
                //Toast.MakeText(Android.App.Application.Context, "bắt đầu ghi âm", ToastLength.Short).Show();
                await MakeCall("900");
                await Task.Delay(10000);
                recorder.Stop();
                recorder.Reset();
                //Toast.MakeText(Android.App.Application.Context, "Ghi âm thành công" + path, ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(Android.App.Application.Context, ex.Message + path, ToastLength.Short).Show();
                System.Console.WriteLine(ex.Message);
            }
        }

        [Obsolete]
        public async Task MakeCall(string PhoneNumber)
        {
            try
            {
                MaicoHub.App.information.phoneNumber = PhoneNumber;
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
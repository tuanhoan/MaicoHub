using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaicoHub.Droid.Service;
using MaicoHub.Service;
using MaicoHub.Services;
using MaicoHubAPI.Model;
using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

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

        //async Task Test()
        //{

        //    recorder = new AudioRecorderService
        //    {
        //        TotalAudioTimeout = TimeSpan.FromSeconds(30000),
        //        StopRecordingOnSilence = true
        //    };
        //    recorder.FilePath = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "Download/test.mp3";
        //    if (!recorder.IsRecording)
        //    {
        //        await recorder.StartRecording(); 
        //    }

        //}

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
                Toast.MakeText(Android.App.Application.Context, "bắt đầu ghi âm", ToastLength.Short).Show();

                await Task.Delay(10000);
                recorder.Stop();
                recorder.Reset();
                Toast.MakeText(Android.App.Application.Context, "Ghi âm thành công" + path, ToastLength.Short).Show();
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
                //await Test();
                Android.App.Application.Context.StartActivity(intent);


                //await Task.Delay(10000);
                //if (recorder.IsRecording)
                //{
                //    await recorder.StopRecording();
                //}
                //try
                //{
                //    var filePath = recorder.GetAudioFilePath();

                //    if (filePath != null)
                //    {
                //        player.Play(filePath);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                MaicoHub.App.IsCall = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ThuAmHIHI()
        {
            MediaRecorder recorder = new MediaRecorder();
            recorder.Start();
        }
         
    }
}
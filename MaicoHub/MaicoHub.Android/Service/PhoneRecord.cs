using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaicoHub.Droid.Service;
using MaicoHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneRecord))]
namespace MaicoHub.Droid.Service
{
    class PhoneRecord : IPhoneRecord
    {
        MediaRecorder recorder = new MediaRecorder();
        [Obsolete]
        string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Download/";  

        [Obsolete]
        public void StartRecord()
        { 
            try
            {
                recorder.Reset();
                recorder.SetAudioSource(AudioSource.VoiceRecognition);
                recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                recorder.SetAudioEncoder(AudioEncoder.AmrNb); 
                //recorder.SetAudioSamplingRate(8000);
                //recorder.SetAudioEncodingBitRate(12200); 
                recorder.SetOutputFile(path + "test.mp3");
                recorder.Prepare();
                recorder.Start(); // Exception Hits 
                Toast.MakeText(Android.App.Application.Context, "bắt đầu ghi âm", ToastLength.Short).Show(); 
            }
            catch (Exception ex)
            {
                Toast.MakeText(Android.App.Application.Context, ex.Message + path, ToastLength.Short).Show();
                System.Console.WriteLine(ex.Message);
            }
        }

        [Obsolete]
        public async Task StartRecordZalo()
        { 
            try
            {
                recorder.Reset();
                recorder.SetAudioSource(AudioSource.VoiceRecognition);
                recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                recorder.SetOutputFile(path + "zalo.wav");
                recorder.SetAudioSamplingRate(8000);
                recorder.SetAudioEncodingBitRate(12200);
                recorder.Prepare();
                recorder.Start(); // Exception Hits
                MaicoHub.App.IsCall = true;
                Toast.MakeText(Android.App.Application.Context, "bắt đầu ghi âm", ToastLength.Short).Show();
                Console.WriteLine("Recorrd: " + isVoip(Android.App.Application.Context));
                //await Task.Delay(5000);
                //recorder.Stop();
                //recorder.Reset();
                //Toast.MakeText(Android.App.Application.Context, "Ghi âm thành công" + path, ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(Android.App.Application.Context, ex.Message + path, ToastLength.Short).Show();
                System.Console.WriteLine(ex.Message);
            }
        }

        [Obsolete]
        public void StopRecord()
        {
            try
            { 
                recorder.Stop();
                recorder.Reset();
                Toast.MakeText(Android.App.Application.Context, "Ghi âm thành công" + path, ToastLength.Short).Show();
            }
            catch
            {

            }
        }

        public bool isVoip(Context context)
        {
            //System.Threading.Thread.Sleep(1000);
             AudioManager manager = (AudioManager)context.GetSystemService(Context.AudioService);
            if (manager.Mode == Mode.InCommunication)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
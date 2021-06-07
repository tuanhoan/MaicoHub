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
        public static MediaRecorder recorder = new MediaRecorder();
        [Obsolete]
        public void LoadFile()
        {
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
                Toast.MakeText(Android.App.Application.Context, "bắt đầu ghi âm", ToastLength.Short).Show();
                MaicoHub.App.IsCall = true;
                await Task.Delay(1);
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

            //    string[] PermissionsLocation = {
            //    Manifest.Permission.CallPhone
            //};
            //    RequestPermissions(PermissionsLocation, 0);

            string[] simSlotName = {
            "extra_asus_dial_use_dualsim",
            "com.android.phone.extra.slot",
            "slot",
            "simslot",
            "sim_slot",
            "subscription",
            "Subscription",
            "phone",
            "com.android.phone.DialingMode",
            "simSlot",
            "slot_id",
            "simId",
            "simnum",
            "phone_type",
            "slotId",
            "slotIdx"
        };
            MaicoHub.App.information.phoneNumber = PhoneNumber; 
            var URI = Android.Net.Uri.Parse(String.Format("tel:" + PhoneNumber));
            var intent = new Intent(Intent.ActionCall, URI); 
            intent.SetFlags(ActivityFlags.NewTask);
            intent.PutExtra("com.android.phone.force.slot", true);
            intent.PutExtra("Cdma_Supp", true);

            //Add all slots here, according to device.. (different device require different key so put all together)
            foreach (string s in simSlotName)
            {
                //0 or 1 according to sim
                intent.PutExtra(s, 1);
            }
            Android.App.Application.Context.StartActivity(intent);
            MaicoHub.App.IsCall = true;
            await Task.Delay(1);


            //try
            //{
            //    MaicoHub.App.information.phoneNumber = PhoneNumber;
            //    var URI = Android.Net.Uri.Parse(String.Format("tel:" + PhoneNumber));
            //    var intent = new Intent(Intent.ActionCall, URI);
            //    intent.PutExtra("com.android.phone.extra.slot", 0);
            //    intent.SetFlags(ActivityFlags.NewTask); 
            //    Android.App.Application.Context.StartActivity(intent); 
            //    MaicoHub.App.IsCall = true;

            //    await Task.Delay(1);
            //    //IPhoneRecord phoneRecord = new PhoneRecord();
            //    //phoneRecord.StartRecord();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
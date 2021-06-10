using Android;
using Android.AccessibilityServices;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Android.Views.Accessibility;
using MaicoHub.Droid.Service;
using MaicoHub.Services;
using System;
using System.Threading.Tasks;

namespace MaicoHub.Droid
{
    [Service(Label = "MaicoHub", Permission = Manifest.Permission.BindAccessibilityService)]
    [IntentFilter(new[] { "android.accessibilityservice.AccessibilityService" })]
    class MyAccessibilityService : AccessibilityService
    {
        private AccessibilityServiceInfo info = new AccessibilityServiceInfo();
        private string TAG = "MyAccessibilityService";

        public override void OnCreate()
        {
            base.OnCreate();
            Log.Verbose(TAG, "OnCreate service");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Log.Verbose(TAG, "OnDestroy service");
        }


        public override void OnAccessibilityEvent(Android.Views.Accessibility.AccessibilityEvent e)
        {
            Console.WriteLine(MaicoHub.App.phoneRecord.isVoip(Android.App.Application.Context));
            if (e.PackageName == "com.zing.zalo")
            {
                System.Threading.Thread.Sleep(2000);
                if (MaicoHub.App.phoneRecord.isVoip(Android.App.Application.Context))
                {
                    MaicoHub.App.phoneRecord.StartRecord();

                    Console.WriteLine("Run: " + MaicoHub.App.phoneRecord.isVoip(Android.App.Application.Context));
                    while (MaicoHub.App.phoneRecord.isVoip(Android.App.Application.Context))
                    {
                        Console.WriteLine("Đang ghi âm");
                    }
                    MaicoHub.App.phoneRecord.StopRecord();

                }
            }  
            Console.WriteLine("***** OnAccessibilityEvent *****");
        }

        protected override void OnServiceConnected()
        {
            base.OnServiceConnected();
            info.EventTypes = EventTypes.NotificationStateChanged;
            info.FeedbackType = Android.AccessibilityServices.FeedbackFlags.AllMask;
            info.NotificationTimeout = 100;
            this.SetServiceInfo(info);
        }

        public override void OnInterrupt()
        {
            throw new NotImplementedException();
        }
        public bool isVoip(Context context)
        {
            AudioManager manager = (AudioManager)context.GetSystemService(Context.AudioService);
            if(manager.Mode == Mode.InCommunication)
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
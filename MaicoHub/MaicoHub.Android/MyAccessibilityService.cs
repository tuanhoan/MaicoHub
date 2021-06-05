using Android;
using Android.AccessibilityServices;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    } 
}
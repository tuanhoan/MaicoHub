using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;
using MaicoHub.Droid.Service;
using MaicoHub.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyFirebaseMessaging))]
namespace MaicoHub.Droid.Service
{
    class MyFirebaseMessaging
    {
        [Service]
        [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
        public class MyFirebaseMessagingService : FirebaseMessagingService
        {
            const string TAG = "MyFirebaseMsgService";

            public override async void OnMessageReceived(RemoteMessage message)
            {
                Log.Debug(TAG, "From: " + message.From);

                string body = message.GetNotification().Body;
                Log.Debug(TAG, "Notification Message Body: " + body);

                IPhoneCall phoneCall = new PhoneCall();
                await phoneCall.MakeCall(body);
                //await phoneCall.StartRecorder();
            }

            void SendNotification(string messageBody, IDictionary<string, string> data) { }
        }
    }
}
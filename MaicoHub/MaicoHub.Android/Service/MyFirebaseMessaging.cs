using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                PhoneCall phoneCall = new PhoneCall();
                await phoneCall.StartRecorder();
            }

            void SendNotification(string messageBody, IDictionary<string, string> data) { }
        }
    }
}
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace MaicoHub.Droid.Service
{
    class MyFirebaseMessaging
    {
        [Service]
        [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
        public class MyFirebaseMessagingService : FirebaseMessagingService
        {
            const string TAG = "MyFirebaseMsgService";

            public override void OnMessageReceived(RemoteMessage message)
            {
                //Log.Debug(TAG, "From: " + message.From);

                string body = message.GetNotification().Body;
                //Log.Debug(TAG, "Notification Message Body: " + body);
                ////Ham make phone
                //PlacePhoneCall(body);

                PhoneCall phoneCall = new PhoneCall();
                phoneCall.MakeCall(body);

            }

            void SendNotification(string messageBody, IDictionary<string, string> data){ }


            //void SendNotification(string messageBody, IDictionary<string, string> data)
            //{
            //    var intent = new Intent(this, typeof(MainActivity));
            //    intent.AddFlags(ActivityFlags.ClearTop);
            //    foreach (var key in data.Keys)
            //    {
            //        intent.PutExtra(key, data[key]);
            //    }

            //    var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.OneShot);

            //    var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
            //                              .SetContentTitle("FCM Message")
            //                              .SetContentText(messageBody)
            //                              .SetAutoCancel(true)
            //                              .SetContentIntent(pendingIntent);

            //    var notificationManager = NotificationManagerCompat.From(this);
            //    notificationManager.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
            //}


            public void PlacePhoneCall(string number)
            {
                try
                {
                    PhoneDialer.Open(number);
                }
                catch (ArgumentNullException anEx)
                {
                    // Number was null or white space
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Phone Dialer is not supported on this device.
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
        }
    }
}
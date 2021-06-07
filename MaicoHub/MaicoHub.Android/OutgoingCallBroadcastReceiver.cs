using Android.App;
using Android.Content;
using Android.Media;
using Android.Net.Sip;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using MaicoHub.Droid.Service;
using MaicoHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaicoHub.Droid
{
    [BroadcastReceiver(Name = "com.sushhangover.OutgoingCallBroadcastReceiver")]
    [IntentFilter(new[] { Intent.ActionNewOutgoingCall, TelephonyManager.ActionPhoneStateChanged })]
    [Obsolete]
    public class OutgoingCallBroadcastReceiver : BroadcastReceiver
    { 
        public override void OnReceive(Context context, Intent intent)
        {   
            switch (intent.Action)
            {
                case Intent.ActionNewOutgoingCall:
                    
                    var outboundPhoneNumber = intent.GetStringExtra(Intent.ExtraPhoneNumber); 

                    MaicoHub.App.phoneRecord.StartRecord();
                    //Toast.MakeText(context, $"Started: Outgoing Call to {outboundPhoneNumber}", ToastLength.Long).Show();
                    break;
                case TelephonyManager.ActionPhoneStateChanged:
                    var state = intent.GetStringExtra(TelephonyManager.ExtraState);
                    if (state == TelephonyManager.ExtraStateIdle)
                    {
                        MaicoHub.App.phoneRecord.StopRecord();
                         
                        //Toast.MakeText(context, "Phone Idle (call ended)", ToastLength.Long).Show();
                    } 
                    else if (state == TelephonyManager.ExtraStateOffhook)
                    {
                        Toast.MakeText(context, "Phone Off Hook", ToastLength.Long).Show();
                    }
                        
                    else if (state == TelephonyManager.ExtraStateRinging)
                        Toast.MakeText(context, "Phone Ringing", ToastLength.Long).Show();
                    else if (state == TelephonyManager.ExtraIncomingNumber)
                    {
                        var incomingPhoneNumber = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                        Toast.MakeText(context, $"Incoming Number: {incomingPhoneNumber}", ToastLength.Long).Show();
                    }
                    break; 
                default:
                    break;
            }
        }
    }
}
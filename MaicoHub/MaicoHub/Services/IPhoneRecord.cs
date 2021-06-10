using Android.Content;
using Android.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaicoHub.Services
{
    public interface IPhoneRecord
    {
        void StartRecord();
        void StopRecord();
        Task StartRecordZalo();
        bool isVoip(Context context);
    }
}

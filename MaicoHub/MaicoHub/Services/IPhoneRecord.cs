using Android.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaicoHub.Services
{
    public interface IPhoneRecord
    {
        void StartRecord();
        void StopRecord(); 
    }
}

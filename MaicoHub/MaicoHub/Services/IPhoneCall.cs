using System;
using System.Collections.Generic;
using System.Text;

namespace MaicoHub.Services
{
    public interface IPhoneCall
    {
        void MakeCall(string PhoneNumber);
        void LoadFile();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaicoHub.Services
{
    public interface IPhoneCall
    {
        void MakeCall(string PhoneNumber);
        Task LoadFile();
    }
}

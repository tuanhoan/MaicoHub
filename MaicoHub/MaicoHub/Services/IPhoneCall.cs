using System.Threading.Tasks;

namespace MaicoHub.Services
{
    public interface IPhoneCall
    {
        Task MakeCall(string PhoneNumber);
        void LoadFile();
        Task StartRecorder();
    }
}

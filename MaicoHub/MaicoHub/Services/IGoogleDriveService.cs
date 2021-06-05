using System.Threading.Tasks;

namespace MaicoHub.Services
{
    interface IGoogleDriveService
    {
        string CreateFolder(string FolderName, string parentId = null);
        Task<string> Upload(string filePath, string folderId, string name = null);
        void Test();
    }
}

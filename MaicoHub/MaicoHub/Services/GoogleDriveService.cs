using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MaicoHub.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MaicoHub.Service
{
    public class GoogleDriveService
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "MaicoHub";
        protected readonly UserCredential credential;
        protected readonly DriveService service;
        protected string root = "1ThUOQ_eEodHm4UVMt7wp4iTzW-Aoc94x";
        public GoogleDriveService()
        { 
            using (var stream =
                new FileStream("storage/emulated/0/Download/credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "storage/emulated/0/Download/token.json"; 

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "tuananh.maicogroup@gmail.com", // use a const or read it from a config file
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
        public string CreateFolder(string FolderName, string parentId = null)
        {
            if (parentId == null) parentId = root;
            var FileMetaData = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(FolderName),
                MimeType = "application/vnd.google-apps.folder",
                Parents = new List<string>
                   {
                       parentId
                   }
            };

            FilesResource.CreateRequest request;

            request = service.Files.Create(FileMetaData);
            request.Fields = "id";
            var file = request.Execute();
            return file.Id;
        } 
        public async Task<string> Upload(string filePath, string folderId, string name = null)
        {
            bool isLoadComplete = false;
            Random rnd = new Random(); 

            if (name == null) name = filePath;

            var mimeType = "image/*";

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = name,
                MimeType = mimeType,
                Parents = new[] { folderId }
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
            {
                request = service.Files.Create(
                    fileMetadata, stream, mimeType);
                request.Fields = "id, name, parents, createdTime, modifiedTime, mimeType";
                request.IncludePermissionsForView = "published";
                while (!isLoadComplete)
                {
                    try
                    {
                        await request.UploadAsync();
                    }
                    catch (Google.GoogleApiException)
                    {
                        await Task.Delay(rnd.Next(10, 100));
                        continue;
                    }
                    isLoadComplete = true;
                }

            }
            return request.ResponseBody.Id;
        }

        public void Test()
        {
            Console.WriteLine("test");
        }
    }
}

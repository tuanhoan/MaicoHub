using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaicoHub.Droid.Service;
using MaicoHub.Service;
using MaicoHub.Services;
using MaicoHubAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall))]
namespace MaicoHub.Droid.Service
{
    class PhoneCall : IPhoneCall
    { 
        [Obsolete]
        public async Task LoadFile()
        {
            //var folder = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "Music/Recordings/Call Recordings";
            var folder = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "Download/";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filePath = Directory.GetFiles(folder).Last();
            MaicoHub.App.information.filePath = filePath;
             
            
            //await DependencyService.Get<GoogleDriveService>().Upload(filePath, "1ThUOQ_eEodHm4UVMt7wp4iTzW-Aoc94x");

            //try
            //{
            //    string a = "mutation{  addInformation(filePath:\"C:/Users/Administrator/Downloads/1.jpg\", phoneNumber:\"900\"){    filePath,    phoneNumber,    id  }}";
            //    var x = MaicoHub.App.information.filePath;
            //    string completeQuery = $@"mutation{{  addInformation(filePath:""{x}"", phoneNumber:""{MaicoHub.App.information.phoneNumber}""){{    filePath,    phoneNumber,    id  }}}}";
            //    string graphQLQueryType = "addInformation";

            //    var result = await MaicoHub.DataAccess.Mutation.ExceuteMutationAsyn<Information>(graphQLQueryType, completeQuery);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

        public void MakeCall(string PhoneNumber)
        {
            try
            {
                MaicoHub.App.information.phoneNumber = PhoneNumber;
                var URI = Android.Net.Uri.Parse(String.Format("tel:" + PhoneNumber));
                var intent = new Intent(Intent.ActionCall, URI);
                intent.SetFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
                MaicoHub.App.IsCall = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
         
    }
}
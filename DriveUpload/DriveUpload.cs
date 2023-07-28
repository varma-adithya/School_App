using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_App.DriveUpload
{
    internal class DriveUpload
    {
        private const string PathToServiceAccountKeyFile = @"D:/Projects/School App/school-app-194012-72589e7829bc.json";
        private const string ServiceAccountEmail = "school-app@school-app-194012.iam.gserviceaccount.com";
        private const string UploadFileName = "Welcome.txt";
        private const string DirectoryId = "1X1c7-rX7YqUNtLp-0B_id30XtUNwAohs";


        //GoogleCredential credential = GoogleCredential.FromFile(PathToServiceAccountKeyFile).CreateScoped(DriveService.ScopeConstants.Drive);

        //var service = new DriveService(new BaseClientService.Initializer()
        //{
        //    HttpClientInitializer = credential
        //});



        GoogleCredential credential = GoogleCredential.FromFile(PathToServiceAccountKeyFile)
                                              .CreateScoped(DriveService.ScopeConstants.Drive);

        var service = new DriveService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
        });
    }
}

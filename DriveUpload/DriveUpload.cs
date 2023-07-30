﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_App.DriveUpload
{
    internal class DriveUpload
    {
        private const string PathToServiceAccountKeyFile = @"D:/Projects/School App/school-app-194012-9f0d8d64a8c5.json";
        //private const string ServiceAccountEmail = "school-app@school-app-194012.iam.gserviceaccount.com";
        private const string UploadFilepath = "D:/Projects/School App/Welcome.txt";
        private const string DirectoryId = "1X1c7-rX7YqUNtLp-0B_id30XtUNwAohs";


        
        public void Upload()
        {
            GoogleCredential credential;
            var Stream = new FileStream(PathToServiceAccountKeyFile, FileMode.Open, FileAccess.Read);
            credential = GoogleCredential.FromStream(Stream).CreateScoped(DriveService.ScopeConstants.Drive);
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Drive Upload Console App"
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = Path.GetFileName(UploadFilepath),
                Parents = new List<string> { DirectoryId }
            };

            byte[] byteArray = File.ReadAllBytes(UploadFilepath);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                try
                {
                    var request = service.Files.Create(fileMetadata, stream, fileMetadata.MimeType);
                    request.Fields = "id";
                    var file = request.Upload();
                    Console.WriteLine("File upload Successfull");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("File upload failed");
                }
            }


        }
        
    }

}

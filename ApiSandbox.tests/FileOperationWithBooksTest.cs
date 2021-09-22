using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiSandbox.tests
{
    public class FileOperationWithBooksTest
    {
        [Fact]
        public void EnumerateFilesTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("newSettings.json", @"{
  ""ConnectionStrings"": {
    ""DefaultConnection"": ""Database=d4tmblunu1tedm; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=ycxwwebyyrkpdm; Password=6cabfa0ba77e19f28bbb0da3e572b207fedd69ba4b12a21d915f0c2af48b8d90; Ssl Mode=Require;Trust Server Certificate=true "",
    ""LocalPostgresConnection"": ""Server=127.0.0.1;Port=5432;Database=ApiSandbox-stefan;User Id=postgres;Password=parola123;"",
    ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-ApiSandbox-205DC6DB-DCFE-4AEA-B5CF-BD1B72712A66;Trusted_Connection=True;MultipleActiveResultSets=true"",
    ""Heroku"": ""postgres://ycxwwebyyrkpdm:6cabfa0ba77e19f28bbb0da3e572b207fedd69ba4b12a21d915f0c2af48b8d90@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d4tmblunu1tedm""
  },
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft"": ""Warning"",
      ""Microsoft.Hosting.Lifetime"": ""Information""
    }
  },
  ""AllowedHosts"": ""*""
}
");
        }
        public void ReadFilesTest()
        {
            using (var fs = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var returnedstring = temp.GetString(b);
                    Console.WriteLine(returnedstring);
                }
            }

        }

    }
}

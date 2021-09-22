using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiSandbox.Tests
{
    public class StartupTests
    {
        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            // Assume
            string databaseURL = "postgres://ycxwwebyyrkpdm:6cabfa0ba77e19f28bbb0da3e572b207fedd69ba4b12a21d915f0c2af48b8d90@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d4tmblunu1tedm";

            // Act
            string convertedConnectionString = Startup.ConvertConnectionString(databaseURL);

            // Assert
            Assert.Equal("Database=d4tmblunu1tedm; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=ycxwwebyyrkpdm; Password=6cabfa0ba77e19f28bbb0da3e572b207fedd69ba4b12a21d915f0c2af48b8d90; Ssl Mode=Require;Trust Server Certificate=true ", convertedConnectionString);
        }
    }
}

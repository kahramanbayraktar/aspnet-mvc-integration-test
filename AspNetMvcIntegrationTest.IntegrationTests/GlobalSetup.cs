using AspNetMvcIntegrationTest.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AspNetMvcIntegrationTest.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            //MigrateDbToLatestVersion();
            //Seed();
        }

        private static void MigrateDbToLatestVersion()
        {
            var configuration = new Data.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        private void Seed()
        {
            var context = new WeTubeContext();

            if (!context.Videos.Any())
            {
                context.Videos.AddRange(
                    new List<Video>
                    {
                        new Video
                        {
                            Title = "Learn React - React Crash Course 2018 - React Tutorial with Examples | Mosh",
                            Url = "https://www.youtube.com/watch?v=Ke90Tje7VS0",
                            Duration = 8726,
                            UploadTime = new DateTime(2018, 7, 16),
                            ViewCount = 471732
                        },
                        new Video
                        {
                            Title = "Blazor, a New NET Single Page Application Framework",
                            Url = "https://www.youtube.com/watch?v=GI_9g9lZpik",
                            Duration = 2947,
                            UploadTime = new DateTime(2018, 12, 18),
                            ViewCount = 5276
                        },
                        new Video
                        {
                            Title = "4 Programming Paradigms in 40 Minutes",
                            Url = "https://www.youtube.com/watch?v=cgVVZMfLjEI",
                            Duration = 2487,
                            UploadTime = new DateTime(2018, 3, 18),
                            ViewCount = 110715
                        }
                    });

                context.SaveChanges();
            }
        }
    }
}

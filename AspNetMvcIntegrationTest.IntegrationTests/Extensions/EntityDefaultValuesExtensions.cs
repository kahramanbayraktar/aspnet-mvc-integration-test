using AspNetMvcIntegrationTest.Data.Models;
using System;

namespace AspNetMvcIntegrationTest.IntegrationTests.Extensions
{
    public static class EntityDefaultValuesExtensions
    {
        public static void FillWithDefaultValues(this Video video)
        {
            video.Title = "Why humans run the world | Yuval Noah Harari";
            video.Url = "https://www.youtube.com/watch?v=nzj7Wg4DAbs";
            video.Duration = 1029;
            video.UploadTime = DateTime.Now;
            video.VideoId = 123456;
        }
    }
}

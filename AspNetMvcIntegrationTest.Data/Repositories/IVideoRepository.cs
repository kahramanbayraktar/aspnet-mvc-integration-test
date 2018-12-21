using AspNetMvcIntegrationTest.Data.Models;
using System.Collections.Generic;

namespace AspNetMvcIntegrationTest.Data.Repositories
{
    public interface IVideoRepository
    {
        Video GetMostViewedVideo();
        IEnumerable<Video> GetLatestVideos(int? count);
    }
}
using AspNetMvcIntegrationTest.Data.Models;
using System.Collections.Generic;

namespace AspNetMvcIntegrationTest.Web.ViewModels
{
    public class VideoStatsViewModel
    {
        public string Title { get; set; }

        public IList<Video> LatestVideos { get; set; }

        public Video MostViewedVideo { get; set; }
    }
}
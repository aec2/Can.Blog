using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Can.Blog.VideoDownload
{
    public class YouTubeDownloadStrategy : IVideoDownloadStrategy
    {
        public async Task<Stream> DownloadVideoAsync(string url)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var streamInfo = streamManifest.GetVideoStreams().GetWithHighestVideoQuality();
            if (streamInfo != null)
            {
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                return stream;
            }
            throw new Exception("No suitable stream found for this video.");

        }

        public bool AppliesTo(string source) => source.Equals("youtube", StringComparison.OrdinalIgnoreCase);


    }
}

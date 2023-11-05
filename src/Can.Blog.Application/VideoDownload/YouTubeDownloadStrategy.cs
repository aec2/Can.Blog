using Can.Blog.VideoDownload.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos.Streams;

namespace Can.Blog.VideoDownload
{
    public class YouTubeDownloadStrategy : IYouTubeDownloadStrategy
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
        public async Task<StreamManifest> GetVideoStreamManifestAsync(string url)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            return streamManifest;
        }

        public async Task<List<VideoQualityDto>> GetVideoQualitiesAsync(string url)
        {
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var qualities = streamManifest.GetMuxedStreams()
                .Select(streamInfo => new VideoQualityDto
                {
                    Quality = streamInfo.VideoQuality.Label,
                    Url = streamInfo.Url, // This URL is temporary and should not be sent to the client for security reasons
                    Format = streamInfo.Container.Name,
                    Size = streamInfo.Size.MegaBytes.ToString(CultureInfo.InvariantCulture) // You might want to format this size to a more readable format
                })
                .ToList();

            return qualities;
        }
        public bool AppliesTo(string source) => source.Equals("youtube", StringComparison.OrdinalIgnoreCase);

    }
}

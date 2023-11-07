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
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using static Volo.Abp.Http.MimeTypes;

namespace Can.Blog.VideoDownload
{
    public class YouTubeDownloadStrategy : IYouTubeDownloadStrategy
    {
        private readonly YoutubeClient _youtubeClient = new();

        private readonly string _ffmpegPath = @"C:\Users\aenes\OneDrive\Masaüstü\ffmpeg-4.4.1-win-64\ffmpeg.exe";

        public async Task<Stream> DownloadVideoAsync(string url)
        {
            var _youtubeClient = new YoutubeClient();
            var video = await _youtubeClient.Videos.GetAsync(url);
            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Id);
            var streamInfo = streamManifest.GetVideoStreams().GetWithHighestVideoQuality();
            if (streamInfo != null)
            {
                var stream = await _youtubeClient.Videos.Streams.GetAsync(streamInfo);
                return stream;
            }
            throw new Exception("No suitable stream found for this video.");

        }
        public async Task<StreamManifest> GetVideoStreamManifestAsync(string url)
        {
            var _youtubeClient = new YoutubeClient();
            var video = await _youtubeClient.Videos.GetAsync(url);
            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Id);
            return streamManifest;
        }

        public async Task<List<VideoQualityDto>> GetVideoQualitiesAsync(string url)
        {
            var _youtubeClient = new YoutubeClient();
            var video = await _youtubeClient.Videos.GetAsync(url);
            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(video.Id);
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

        public async Task<string> GetHighestQualityAndAudioMuxedStreamAsync(string url)
        {
            var _youtubeClient = new YoutubeClient();

            // Get stream manifest
            var videoUrl = url;
            var video = await _youtubeClient.Videos.GetAsync(url);
            var videoId = video.Id;


            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);

            // Select best audio stream (highest bitrate)
            var audioStreamInfo = streamManifest
                .GetAudioStreams()
                .Where(s => s.Container == Container.Mp4)
                .GetWithHighestBitrate();

            // Select best video stream (1080p60 in this example)
            var videoStreamInfo = streamManifest
                .GetVideoStreams()
                .Where(s => s.Container == Container.Mp4)
                .FirstOrDefault(s => s.VideoQuality.Label == "1080p");

            // Generate a unique file path
            var tempDirectory = Path.GetTempPath();
            var fileName = $"{videoId}_{Guid.NewGuid()}.mp4";
            var filePath = Path.Combine(tempDirectory, fileName);

            if (audioStreamInfo == null || videoStreamInfo == null)
            {
                throw new Exception("Unable to find suitable audio or video stream.");
            }
            // Download and mux streams into a single file
            var streamInfos = new[] { audioStreamInfo, videoStreamInfo };
            await _youtubeClient.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(filePath).SetPreset(ConversionPreset.UltraFast).SetFFmpegPath(_ffmpegPath).Build());

            return filePath;
        }


        public bool AppliesTo(string source) => source.Equals("_youtubeClient", StringComparison.OrdinalIgnoreCase);

    }
}

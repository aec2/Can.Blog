using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Can.Blog.VideoDownload.DTO;
using Volo.Abp;
using Volo.Abp.Application.Services;
using YoutubeExplode.Videos.Streams;

namespace Can.Blog.VideoDownload
{
    public class VideoDownloadService: ApplicationService
    {
        private IVideoDownloadStrategy _downloadStrategy;

        public VideoDownloadService(IVideoDownloadStrategy downloadStrategy)
        {
            _downloadStrategy = downloadStrategy;
        }

        public void SetStrategy(IVideoDownloadStrategy downloadStrategy)
        {
            _downloadStrategy = downloadStrategy;
        }

        public async Task<Stream> DownloadVideoAsync(string url)
        {
            return await _downloadStrategy.DownloadVideoAsync(url);
        }

        public Task<StreamManifest> GetYouTubeVideoStreamManifestAsync(string url)
        {
            var youTubeStrategy = _downloadStrategy as IYouTubeDownloadStrategy;

            if (youTubeStrategy == null)
            {
                throw new NotSupportedException("YouTube strategy is not available.");
            }

            return youTubeStrategy.GetVideoStreamManifestAsync(url);
        }

        public Task<List<VideoQualityDto>> GetYouTubeVideoQualitiesAsync(string url)
        {
            var youTubeStrategy = _downloadStrategy as IYouTubeDownloadStrategy;

            if (youTubeStrategy == null)
            {
                throw new NotSupportedException("YouTube strategy is not available.");
            }

            return youTubeStrategy.GetVideoQualitiesAsync(url);
        }

    }
}

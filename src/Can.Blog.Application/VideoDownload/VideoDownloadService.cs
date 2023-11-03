using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

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
    }
}

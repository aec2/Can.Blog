using Can.Blog.VideoDownload;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Can.Blog.Controllers
{
    public class VideoDownloadController : AbpController
    {
        private readonly VideoDownloadService _videoDownloadService;

        public VideoDownloadController(VideoDownloadService videoDownloadService)
        {
            _videoDownloadService = videoDownloadService;
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download(string videoUrl, string source)
        {
            switch (source.ToLower())
            {
                case "youtube":
                    _videoDownloadService.SetStrategy(new YouTubeDownloadStrategy());
                    break;
                case "twitter":
                    _videoDownloadService.SetStrategy(new TwitterDownloadStrategy());
                    break;
                case "instagram":
                    _videoDownloadService.SetStrategy(new InstagramDownloadStrategy());
                    break;
                default:
                    return BadRequest("Unsupported video source.");
            }

            var videoStream = await _videoDownloadService.DownloadVideoAsync(videoUrl);

            return File(videoStream, "video/mp4", "download.mp4");
        }
    }
}

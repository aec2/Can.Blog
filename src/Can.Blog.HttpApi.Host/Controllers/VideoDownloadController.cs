using Can.Blog.VideoDownload;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Can.Blog.VideoDownload.DTO;
using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Can.Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoDownloadController : AbpController
    {
        private readonly VideoDownloadService _videoDownloadService;

        public VideoDownloadController(VideoDownloadService videoDownloadService)
        {
            _videoDownloadService = videoDownloadService;
        }

        [HttpPost("download")]
        //[Route("api/app/download")]
        public async Task<IActionResult> Download(DownloadVideoRequest request)
        {
            switch (request.Source.ToLower())
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

            var videoStream = await _videoDownloadService.DownloadVideoAsync(request.VideoUrl);

            return File(videoStream, "video/mp4", "download.mp4");
        }

        [HttpGet("youtube/manifest")]
        public async Task<ActionResult> GetYouTubeVideoStreamManifest(string videoUrl)
        {
            try
            {
                _videoDownloadService.SetStrategy(new YouTubeDownloadStrategy());
                var manifest = await _videoDownloadService.GetYouTubeVideoStreamManifestAsync(videoUrl);
                var videoStreams = manifest.GetMuxedStreams();
                return Ok(videoStreams);
            }
            catch (NotSupportedException)
            {
                return BadRequest("This feature is only supported for YouTube videos.");
            }
        }

        [HttpGet("youtube/qualities")]
        public async Task<IActionResult> GetVideoQualities(string videoUrl, string source)
        {
            // Ensure that the source is YouTube since this is a YouTube-specific feature
            if (!source.Equals("youtube", System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Quality selection is only supported for YouTube videos.");
            }
            _videoDownloadService.SetStrategy(new YouTubeDownloadStrategy());

            var qualities = await _videoDownloadService.GetYouTubeVideoQualitiesAsync(videoUrl);
            return Ok(qualities);
        }
    }
}

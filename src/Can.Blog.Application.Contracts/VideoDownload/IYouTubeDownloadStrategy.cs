using System.Collections.Generic;
using System.Threading.Tasks;
using Can.Blog.VideoDownload.DTO;
using YoutubeExplode.Videos.Streams;

namespace Can.Blog.VideoDownload;

public interface IYouTubeDownloadStrategy : IVideoDownloadStrategy
{
    Task<StreamManifest> GetVideoStreamManifestAsync(string url);
    Task<List<VideoQualityDto>> GetVideoQualitiesAsync(string url);
}
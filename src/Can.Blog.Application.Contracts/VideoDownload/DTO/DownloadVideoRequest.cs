namespace Can.Blog.VideoDownload.DTO;

public record DownloadVideoRequest(string VideoUrl, string Source)
{
    public string VideoUrl { get; private set; } = VideoUrl;
    public string Source { get; private set; } = Source;
}
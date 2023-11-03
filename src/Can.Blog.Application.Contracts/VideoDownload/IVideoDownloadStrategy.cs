using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Can.Blog.VideoDownload
{
    public interface IVideoDownloadStrategy: IApplicationService
    {
        Task<Stream> DownloadVideoAsync(string url);
        bool AppliesTo(string source);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.Blog.VideoDownload
{
    public class InstagramDownloadStrategy : IVideoDownloadStrategy
    {
        public Task<Stream> DownloadVideoAsync(string url)
        {
            throw new NotImplementedException();
        }

        public bool AppliesTo(string source) => source.Equals("instagram", StringComparison.OrdinalIgnoreCase);

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Can.Blog.Post
{
    public interface IPostAppService: IApplicationService
    {
        public Task<PostDto> GetPostByIdAsync(Guid id);
    }
}

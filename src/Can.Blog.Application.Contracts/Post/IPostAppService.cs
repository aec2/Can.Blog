using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Can.Blog.Post
{
    public interface IPostAppService: IApplicationService
    {
        public Task<PostDTO> GetPostByIdAsync(Guid id);
    }
}

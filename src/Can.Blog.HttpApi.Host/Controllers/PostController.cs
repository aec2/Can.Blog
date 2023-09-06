using Can.Blog.Post;
using Volo.Abp.AspNetCore.Mvc;

namespace Can.Blog.Controllers
{
    public class PostController  : AbpController
    {
        private readonly IPostAppService _postAppService;

        public PostController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

    }
}

using System;
using System.Threading.Tasks;
using Can.Blog.Post;
using Microsoft.AspNetCore.Mvc;
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

using Can.Blog.Tag;

namespace Can.Blog.Controllers
{
    public class TagController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
    }
}

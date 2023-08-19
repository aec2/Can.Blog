using Can.Blog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Can.Blog.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BlogController : AbpControllerBase
{
    protected BlogController()
    {
        LocalizationResource = typeof(BlogResource);
    }
}

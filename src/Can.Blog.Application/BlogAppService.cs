using Can.Blog.Localization;
using Volo.Abp.Application.Services;

namespace Can.Blog;

/* Inherit your application services from this class.
 */
public abstract class BlogAppService : ApplicationService
{
    protected BlogAppService()
    {
        LocalizationResource = typeof(BlogResource);
    }
}

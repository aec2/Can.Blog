using Can.Blog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Can.Blog;

[DependsOn(
    typeof(BlogEntityFrameworkCoreTestModule)
    )]
public class BlogDomainTestModule : AbpModule
{

}

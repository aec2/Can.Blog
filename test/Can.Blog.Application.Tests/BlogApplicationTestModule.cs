using Volo.Abp.Modularity;

namespace Can.Blog;

[DependsOn(
    typeof(BlogApplicationModule),
    typeof(BlogDomainTestModule)
    )]
public class BlogApplicationTestModule : AbpModule
{

}

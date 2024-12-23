﻿using Can.Blog.VideoDownload;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Can.Blog;

[DependsOn(
    typeof(BlogDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(BlogApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class BlogApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BlogApplicationModule>();
        });

        context.Services.AddTransient<IVideoDownloadStrategy, YouTubeDownloadStrategy>();
        context.Services.AddTransient<IVideoDownloadStrategy, TwitterDownloadStrategy>();
        context.Services.AddTransient<IVideoDownloadStrategy, InstagramDownloadStrategy>();
    }
}

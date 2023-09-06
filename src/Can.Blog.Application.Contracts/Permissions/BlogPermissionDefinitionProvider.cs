using Can.Blog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Can.Blog.Permissions;

public class BlogPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var blogGroup = context.AddGroup(BlogPermissions.GroupName);

        var postsPermission = blogGroup.AddPermission(BlogPermissions.Posts.Default);
        postsPermission.AddChild(BlogPermissions.Posts.Create);
        postsPermission.AddChild(BlogPermissions.Posts.Edit);
        postsPermission.AddChild(BlogPermissions.Posts.Delete);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BlogPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlogResource>(name);
    }
}

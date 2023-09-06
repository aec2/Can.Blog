namespace Can.Blog.Permissions;

public static class BlogPermissions
{
    public const string GroupName = "Blog";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Posts
    {
        public const string Default = GroupName + ".Posts";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}

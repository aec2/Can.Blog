using AutoMapper;
using Can.Blog.Category;
using Can.Blog.Post;
using Can.Blog.Tag;

namespace Can.Blog;

public class BlogApplicationAutoMapperProfile : Profile
{
    public BlogApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Blog.Post, PostDTO>();
        CreateMap<Blog.Tag, TagDTO>();
        CreateMap<Blog.Category, CategoryDTO>();
    }
}

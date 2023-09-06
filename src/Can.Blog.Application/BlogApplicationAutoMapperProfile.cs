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
            //.ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category)); ;
        CreateMap<Blog.Post, PostDTO>()
            .ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));
        CreateMap<Blog.Tag, TagDTO>();
        CreateMap<TagDTO, Blog.Tag>();

        CreateMap<Blog.Category, CategoryDTO>();
        CreateMap<CategoryDTO, Blog.Category>();
        CreateMap<Blog.Post, CreateUpdatePostDto>();
        CreateMap<Blog.Post, CreateUpdatePostDto>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
            .ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));

        CreateMap<CreateUpdatePostDto, Blog.Post>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore()) // since Tags collection is read-only
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryDto))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));


    }
}

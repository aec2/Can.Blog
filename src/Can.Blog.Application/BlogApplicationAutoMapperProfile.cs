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
        CreateMap<Blog.Tag, TagDTO>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<TagDTO, Blog.Tag>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());


        CreateMap<Blog.PostTag, PostTagDTO>();
        CreateMap<PostTagDTO, Blog.PostTag>();

        CreateMap<Blog.Category, CategoryDTO>()
            .ForMember(category => category.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<CategoryDTO, Blog.Category>()
            .ForMember(category => category.Id, opt => opt.MapFrom(src => src.Id)); ;
        CreateMap<Blog.Post, CreateUpdatePostDto>()
            //.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
            .ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));

        CreateMap<CreateUpdatePostDto, Blog.Post>()
            //.ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>src.Tags)) 
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));


    }
}

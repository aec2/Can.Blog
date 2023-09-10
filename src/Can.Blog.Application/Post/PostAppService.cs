using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Can.Blog.Blog;
using Can.Blog.Tag;
using Polly;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace Can.Blog.Post
{
    public class PostAppService : ApplicationService
    {
        private readonly IRepository<Blog.Post> _postRepository;
        private readonly IRepository<Blog.Category> _categoryRepository;
        private readonly IRepository<Blog.Tag> _tagRepository;

        public PostAppService(IRepository<Blog.Post> postRepository, IRepository<Blog.Category> categoryRepository, IRepository<Blog.Tag> tagRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        public async Task<PostDTO> GetPostByIdAsync(Guid id)
        {
            var queryable = await _postRepository.WithDetailsAsync(x => x.Category, x => x.PostTags);

            var query = queryable.Where(x => x.Id == id);
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Blog.Post), id);
            }

            try
            {
                var postDto = ObjectMapper.Map<Blog.Post, PostDTO>(queryResult); //TODO Check this mapping
                return postDto;

            }
            catch (Exception exception)
            {

                Debug.WriteLine(exception.Message);
            }

            return new PostDTO();
        }

        public async Task<List<PostDTO>> GetAllPosts()
        {
            var postList = await _postRepository.WithDetailsAsync( x => x.Category);

            if (postList == null)
            {
                return new List<PostDTO>();
            }

            var postDtos = ObjectMapper.Map<List<Blog.Post>, List<PostDTO>>(postList.OrderByDescending(x => x.PublishedDate).ToList());
            return postDtos;

        }

        [UnitOfWork(IsDisabled = true)]
        public async Task<Blog.Post> CreateAsync(CreateUpdatePostDto newCreateUpdatePostDto)
        {
            try
            {
                var post = new Blog.Post
                {
                    Title = newCreateUpdatePostDto.Title,
                    Content = newCreateUpdatePostDto.Content,
                    ImgUrl = newCreateUpdatePostDto.ImgUrl,
                    UserName = newCreateUpdatePostDto.UserName,
                    CategoryId = newCreateUpdatePostDto.CategoryId,
                    PublishedDate = DateTime.Now
                };
                var result = await _postRepository.InsertAsync(post);

                result.PostTags.Clear();
                if (newCreateUpdatePostDto.Tags.Any())
                {
                    foreach (var tag in newCreateUpdatePostDto.Tags)
                    {
                        result.PostTags.Add(new PostTag()
                        {
                            PostGuid = result.Id,
                            TagGuid = tag.Id
                        }); 
                    }
                }

                await _postRepository.UpdateAsync(result);
                return result;
            }
            catch (ArgumentNullException argNullEx)
            {
                Debug.WriteLine($"Null argument error occurred while creating new post: {argNullEx.Message}");
                throw;
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"An error occurred while creating new post: {exception.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {

            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty", nameof(id));

            var post = await _postRepository.FindAsync(x => x.Id == id);

            if (post == null)
            {
                throw new EntityNotFoundException($"No Post found with the ID {id}");
            }

            await _postRepository.DeleteAsync(post);
        }

        public async Task<Blog.Post> UpdateAsync(Guid id, CreateUpdatePostDto updateDto)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty", nameof(id));

            var existingPostQueryable = await _postRepository.WithDetailsAsync(x => x.PostTags);
            var existingPost = existingPostQueryable.FirstOrDefault(x => x.Id == id);
            if (existingPost == null)
                throw new EntityNotFoundException($"No Post found with the ID {id}");

            // Map properties from DTO to existing post
            ObjectMapper.Map(updateDto, existingPost);


            // Clear existing PostTag relationships
            existingPost.PostTags.Clear();

            // For each tag in DTO, create a new PostTag relationship
            foreach (var tagDto in updateDto.Tags)
            {
                // Check if the PostTag relationship already exists
                if (!existingPost.PostTags.Any(pt => pt.PostGuid == existingPost.Id && pt.TagGuid == tagDto.Id))
                {
                    var postTag = new PostTag
                    {
                        PostGuid = existingPost.Id,
                        TagGuid = tagDto.Id  
                    };

                    existingPost.PostTags.Add(postTag);
                }
            }

            await _postRepository.UpdateAsync(existingPost);

            return existingPost;
        }
    }
}

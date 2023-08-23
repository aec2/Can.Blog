using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Can.Blog.Post
{
    public class PostAppService : ApplicationService
    {
        private readonly IRepository<Blog.Post> _postRepository;
        private readonly IRepository<Blog.Category> _categoryRepository;

        public PostAppService(IRepository<Blog.Post> postRepository, IRepository<Blog.Category> categoryRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PostDTO> GetPostByIdAsync(Guid id)
        {
            var queryable = await _postRepository.WithDetailsAsync(x=> x.Tags); //WithDetailsAsync(x=> x.Tags);

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
    }
}

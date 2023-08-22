using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Can.Blog.Post
{
    public class PostAppService: ApplicationService
    {
        private readonly IRepository<Blog.Post> _postRepository;

        public PostAppService(IRepository<Blog.Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostDto> GetPostByIdAsync(Guid id)
        {
            var queryable = await _postRepository.GetQueryableAsync();

            var query = queryable.Where(x => x.Id == id);
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Blog.Post), id);
            }

            var postDto = ObjectMapper.Map<Blog.Post, PostDto>(queryResult); //TODO Check this mapping

            return postDto;
        }
    }
}

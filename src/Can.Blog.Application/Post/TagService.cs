using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Can.Blog.Tag;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Can.Blog.Post
{
    public class TagService: ApplicationService
    {
        private readonly IRepository<Blog.Tag> _tagRepository;

        public TagService(IRepository<Blog.Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<TagDTO>> GetAllTags()
        {
            var categories = await _tagRepository.GetListAsync();

            if (categories == null)
            {
                return new List<TagDTO>();
            }

            var categoriesDto = ObjectMapper.Map<List<Blog.Tag>, List<TagDTO>>(categories.ToList());
            return categoriesDto;

        }

        public async Task<TagDTO> CreateAsync(TagDTO tagDto)
        {
            var tagEntity = ObjectMapper.Map<TagDTO, Blog.Tag>(tagDto);

            var result = await _tagRepository.InsertAsync(tagEntity);

            return ObjectMapper.Map<Blog.Tag,TagDTO>(result);

        }
    }
}

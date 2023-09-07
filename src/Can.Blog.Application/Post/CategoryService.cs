using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Can.Blog.Category;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Can.Blog.Post
{
    public class CategoryService: ApplicationService
    {
        private readonly IRepository<Blog.Category> _categoryRepository;

        public CategoryService(IRepository<Blog.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetListAsync();

            if (categories == null)
            {
                return new List<CategoryDTO>();
            }

            var categoriesDto = ObjectMapper.Map<List<Blog.Category>, List<CategoryDTO>>(categories.ToList());
            return categoriesDto;

        }
    }
}

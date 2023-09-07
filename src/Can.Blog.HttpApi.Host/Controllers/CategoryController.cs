using Can.Blog.Category;
using Volo.Abp.AspNetCore.Mvc;

namespace Can.Blog.Controllers
{
    public class CategoryController : AbpController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}

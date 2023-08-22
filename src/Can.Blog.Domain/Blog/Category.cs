using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Can.Blog.Blog
{
    public class Category : Entity<Guid>
    {
        public Category()
        {
            
        }
        public string Name { get; set; }
        public string Alias { get; set; }
        public ICollection<Post> Posts{ get; private set; } = new List<Post>();

    }
}

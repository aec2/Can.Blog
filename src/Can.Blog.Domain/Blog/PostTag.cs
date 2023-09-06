using System;
using Volo.Abp.Domain.Entities;

namespace Can.Blog.Blog
{
    public class PostTag
    {
        public Guid PostGuid { get; set; }
        public Guid TagGuid { get; set; }

        public Post Post { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}


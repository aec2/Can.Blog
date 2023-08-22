using Can.Blog.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


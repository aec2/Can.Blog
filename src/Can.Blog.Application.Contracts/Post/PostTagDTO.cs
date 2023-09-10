using System;
using System.Collections.Generic;
using System.Text;

namespace Can.Blog.Post
{
    public class PostTagDTO
    {
        public Guid PostGuid { get; set; }
        public Guid TagGuid { get; set; }
    }
}

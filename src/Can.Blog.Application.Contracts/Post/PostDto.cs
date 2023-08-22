using System;
using System.Collections.Generic;
using System.Text;
using Can.Blog.Tag;

namespace Can.Blog.Post
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ImgUrl { get; set; }
        public string UserName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } 
        public List<TagDTO> Tags { get; set; } = new(); 
    }
}

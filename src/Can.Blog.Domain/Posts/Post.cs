using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Can.Blog.Post;
using Volo.Abp.Domain.Entities;

namespace Can.Blog.Posts
{
    public class Post: Entity<Guid>
    {
        public Post(Guid id, string title, string content, string imgUrl, string author, PostDetail postDetail): base(id)
        {
            Title = title;
            Content = content;
            ImgUrl = imgUrl;
            Author = author;
            PostDetail = postDetail;
        }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public string ImgUrl { get; private set; }
        public string Author { get; private set; }
        public PostDetail PostDetail { get; private set; }
        public List<Tag> Tags { get; private set; }
    }
}

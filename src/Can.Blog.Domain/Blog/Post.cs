using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities;

namespace Can.Blog.Blog
{
    public class Post: Entity<Guid>
    {
        public Post()
        {
            
        }
        private Post(Guid id, string title, string content, string imgUrl, string user): base(id)
        {
            Title = title;
            Content = content;
            ImgUrl = imgUrl;
            UserName = user;
        }

        public static Post CreateInstance(Guid id, string title, string content, string imgUrl, string userName)
        {
            return new Post(id, title, content, imgUrl, userName);
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public string ImgUrl { get; private set; }
        public string UserName { get; private set; }
        public Guid CategoryId { get; set; }
        public Category Category { get;  set; }
        public List<PostTag> PostTags { get; } = new();
        public List<Tag> Tags { get; } = new();
    }
}

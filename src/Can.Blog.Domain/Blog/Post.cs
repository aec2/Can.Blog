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

        public string Title { get;  set; }
        public string Content { get;  set; }
        public DateTime PublishedDate { get;  set; }
        public string ImgUrl { get;  set; }
        public string UserName { get;  set; }
        public Guid CategoryId { get; set; }
        public Category Category { get;  set; }
        public ICollection<PostTag> PostTags { get; } = new List<PostTag>();
        //public ICollection<Tag> Tags { get; set; }
    }
}

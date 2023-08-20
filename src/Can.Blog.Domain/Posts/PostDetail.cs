using System;
using Volo.Abp.Domain.Entities;

namespace Can.Blog.Post;

public class PostDetail : Entity<Guid>
{
    public int Views { get; private set; }
    public int Likes { get; private set; }
    public int Comments { get; private set; }
    public Guid PostId { get; private set; }

    public PostDetail(int views, int likes, int comments)
    {
        Views = views;
        Likes = likes;
        Comments = comments;
    }
}
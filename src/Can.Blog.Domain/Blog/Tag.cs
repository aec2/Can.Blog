using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Can.Blog.Blog;

public class Tag : Entity<Guid>
{
    public string Name { get; private set; }
    public string Alias { get; set; }
    public List<PostTag> PostTags { get; } = new();
    public List<Post> Posts { get; } = new();

}
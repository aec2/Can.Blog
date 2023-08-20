using System;
using Volo.Abp.Domain.Entities;

namespace Can.Blog.Post;

public class Tag : Entity<Guid>
{
    public string Name { get; private set; }

    public Tag(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

}
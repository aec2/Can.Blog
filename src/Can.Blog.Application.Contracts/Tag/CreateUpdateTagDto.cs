using System;

namespace Can.Blog.Tag;

public class CreateUpdateTagDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
}
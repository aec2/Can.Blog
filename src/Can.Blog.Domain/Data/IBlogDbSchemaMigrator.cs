using System.Threading.Tasks;

namespace Can.Blog.Data;

public interface IBlogDbSchemaMigrator
{
    Task MigrateAsync();
}

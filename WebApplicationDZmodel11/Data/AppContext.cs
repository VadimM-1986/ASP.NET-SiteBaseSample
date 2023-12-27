using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplicationDZmodel11.Models;


namespace WebApplicationDZmodel11.Data
{
    public class AppAddContext : DbContext
    {

        // Создаем подключение
        public DbSet<ModelDB> modelDB { get; set; } = null!;
    

        public AppAddContext(DbContextOptions<AppAddContext> options) : base(options) {}


    }
}

using bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<UserCommentEntity> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var tags = new List<TagEntity>
        {
            new TagEntity { Id = 1, TagName = "Featured" },
            new TagEntity { Id = 2, TagName = "New" },
            new TagEntity { Id = 3, TagName = "Popular" }
        };

        modelBuilder.Entity<TagEntity>().HasData(tags);

        var categories = new List<CategoryEntity>
        {
            new CategoryEntity { Id = 1, CategoryName = "T-Shirts" },
            new CategoryEntity { Id = 2, CategoryName = "Shirts" },
            new CategoryEntity { Id = 3, CategoryName = "Pants" },
            new CategoryEntity { Id = 4, CategoryName = "Skirts" },
            new CategoryEntity { Id = 5, CategoryName = "Shorts" },
            new CategoryEntity { Id = 6, CategoryName = "Accessories" }
        };

        modelBuilder.Entity<CategoryEntity>().HasData(categories);
    }
}

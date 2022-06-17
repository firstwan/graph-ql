using Microsoft.EntityFrameworkCore;
using GraphQL_example.Domain.Models;

namespace GraphQL_example.Domain.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemList> ItemList { get;set; }
        public DbSet<ItemData> ItemData { get;set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.ItemDatas)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemData_ItemList");
            });

            modelBuilder.Entity<ItemList>().HasData(
                new ItemList{
                    Id = 1,
                    Name = "To do list"
                }
            );

            modelBuilder.Entity<ItemData>().HasData(
                new ItemData{
                    Id = 1,
                    Title = "Testing data 1",
                    Description = "Hahahahah",
                    Done = false,
                    ListId = 1
                },
                new ItemData{
                    Id = 2,
                    Title = "Testing data 2",
                    Description = "Second one",
                    Done = true,
                    ListId = 1
                }
            );
        }
    }
}

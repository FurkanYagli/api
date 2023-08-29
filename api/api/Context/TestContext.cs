using api.model;
using Microsoft.EntityFrameworkCore;

namespace odws.entity.Context
{
    public class TestContext : DbContext
    {
        
        public DbSet<Test> Test
        {
            get; set;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Database=Test; Integrated Security=True; TrustServerCertificate=True;");
        }
        

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Query<TypeView>().ToView("AuthorArticleCount");

            modelBuilder.Entity<TypeView>(entity =>
            {
                //entity.HasKey(e => e.Id);
                //entity.ToTable("TypeView");
                //entity.Property(e => e.Name).HasMaxLength(50);
                entity.HasNoKey();
                entity.ToView("TypeView");

            });

        }*/
    }
}
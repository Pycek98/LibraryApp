using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Book
            modelBuilder.Entity<Book>()
                .HasKey(k => k.BookID);

            modelBuilder.Entity<Book>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(p => p.Year).HasMaxLength(4);

            // Konfiguracja relacji między Author a Book
            modelBuilder.Entity<Book>()
                        .HasRequired(b => b.Author)
                        .WithMany(a => a.Books)
                        .HasForeignKey(b => b.AuthorID);
            //Author
            modelBuilder.Entity<Author>()
                .HasKey(k => k.AuthorID);

            modelBuilder.Entity<Author>()
                .Property(p => p.Surname).IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Ebook.Models {
    public class ModelsDbContext: IdentityDbContext<IdentityUser, IdentityRole, string> {
        public ModelsDbContext (DbContextOptions options): base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Book> Tbl_Book {get; set;}
        public DbSet<Category> Tbl_Category {get; set;}
        public DbSet<BookUser> Tbl_BookUser {get; set;}
    }

    

}
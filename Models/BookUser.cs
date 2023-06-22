using System;
using Microsoft.AspNetCore.Identity;

namespace Ebook.Models {
    public class BookUser {
        public int Id {get; set;}
        public IdentityUser user {get; set;}
        public Book book {get; set;}
    }
}
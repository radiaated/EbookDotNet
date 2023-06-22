using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebook.Models {
    public class Book {
        public int Id {get; set;}
        public string ?Isbn {get; set;}
        public string ?Title {get; set;}
        public string ?Author {get; set;}
        public string ?Description {get; set;}
        public string ?category {get; set;}
        public string ?Language {get; set;}
        
        public string ?Cover {get; set;}
        public DateTime ?Published {get; set;}
        
    } 
}
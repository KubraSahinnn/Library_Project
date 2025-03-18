using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }
        
        [Required]  
        public string kitapAdi { get; set; }
        
        [Required]
        public string yazar {  get; set; } 
        
        [ForeignKey(nameof(kitapTuru))]

        public int kitapTuruId { get; set; }
        public kitapTuru kitapTuru { get; set; }
    }
}

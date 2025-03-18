using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Referans
    {
        [Key]
        public int Id{  get; set; }
        public string kitapAdi { get; set; }
        public string yazar {  get; set; }
		[ValidateNever]
        public string kitapTuru { get; set; }
        public string fotopath { get; set; }
    }
}

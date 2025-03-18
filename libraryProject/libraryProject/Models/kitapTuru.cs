
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class kitapTuru
    {
        [Key]//primary key
        public int Id {  get; set; }

        [Required(ErrorMessage ="Kitap Türü Adı Boş Bırakılamaz!")]//Null olamaz
        [MaxLength(20)]
        [DisplayName("Kitap Türü Adı")]
        public string Ad {  get; set; }

	}
}

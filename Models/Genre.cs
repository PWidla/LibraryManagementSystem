using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Please enter name of genre")]
        [Display(Name = "Literary genre")]
        public string Name { get; set; }
    }
}

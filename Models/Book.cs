using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter release year")]
        [Range(0, 2023, ErrorMessage = "Release year must be between 0 and 2023")]
        [Display(Name = "Release year")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; }

        //Foreign key
        [Required(ErrorMessage = "Please choose genre")]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }

        [ForeignKey("GenreID")]
        public virtual Genre ?Genre { get; set; }

        //Foreign key
        [Required(ErrorMessage = "Please choose author")]
        [Display(Name = "Author")]
        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Author ?Author { get; set; }
    }
}
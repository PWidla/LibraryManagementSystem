using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public enum Category
    {
        Fiction, Adventure, Classics, Crime, Historical, Horror, Poetry, Romance, Science, Thriller, Autobiography, Biography
    }

    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }

        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter release year")]
        [Range(0, 2023, ErrorMessage = "Release year must be between 0 and 2023")]
        [Display(Name = "Release year")]
        public int ReleaseYear { get; set; }

        //[Required(ErrorMessage = "Availability check is required")]
        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; }

        //Foreign key
        [Required(ErrorMessage = "Please choose author")]
        [Display(Name = "Author")]
        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Author? Author { get; set; }
    }
}
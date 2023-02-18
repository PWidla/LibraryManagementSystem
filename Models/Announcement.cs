using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    [Table("Announcement")]
    public class Announcement
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required(ErrorMessage = "Please enter title")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        [Required(ErrorMessage = "Please enter Content")]
        public string Content { get; set; }

        [Display(Name = "Date of creation")]
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}

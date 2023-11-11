using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMF.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        [Display(Name = "Tantárgy")]
        [Required(ErrorMessage = "Tantárgy nevének megadása kötelező!")]
        public string Title { get; set; }

        [Display(Name = "Kredit")]
        [Required(ErrorMessage = "Kredit értékének megadása kötelező!")]
        public int Credits { get; set; }

        [Display(Name = "Jelentkezések")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}

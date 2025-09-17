using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Eesnimi")]
        public string FirstName { get; set; }
        [Display(Name = "Õpetaja nimi")]
        public string FullName
        {
            get { return LastName + "," + FirstName; }
        }

        /**/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [Display(Name = "Tööleasumiskuupäev")]
        public DateTime HireDate {  get; set; }

        public ICollection<CourseAssignment>? CourseAssignments {  get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

        /* Lisa kolm omadust õpetajale*/

        [Required]
        [Display(Name = "Palk")]
        public double Salary { get; set; }


        [Display(Name = "Boonused")]
        public string? Bonuses { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name = "Sugu")]
        public string Gender { get; set; }
    }
}
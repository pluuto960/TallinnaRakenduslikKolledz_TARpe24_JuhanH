using System.Data;
using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public enum DepartmentStatus
    {
        Suletud, Avatud, Pausil, Deprecated, Ootel
    }
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }

        public Instructor? Administrator { get; set; }

        public ICollection<Course>? Courses { get; set; }
        public byte? RowVersion { get; set; }

        //* 3 isiklikult unikaalset andmevälja kursusele juurde */

        public string Aadress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }



    }
}
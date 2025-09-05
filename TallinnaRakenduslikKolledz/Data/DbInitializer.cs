using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Data
{
    public class DbInitializer
    {
        public static void Initalize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Students.Any())
            {
                return;
            }
            var Students = new Student[]
            {
            new Student
            {

            FirstName = "George",
            LastName = "Teemus",
            EnrollmentDate = DateTime.Now,

            }

            };
        }
    }
}

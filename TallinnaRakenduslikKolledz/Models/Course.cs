﻿using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }

        public ICollection<Enrollment>? Enrollments {get;set;}    
        public ICollection<CourseAssignment>? CourseAssignments {get;set;}    
       
    }
}

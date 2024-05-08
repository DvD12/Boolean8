using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teoria016_EF
{
    [Table("student")]
    [Index(nameof(Email), nameof(Name), IsUnique = true)]
    public class Student
    {
        [Key] public int StudentId { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        [Column("student_email")]
        public string Email { get; set; }
        public List<Review> Reviews { get; set; } // 1:N con Review
        public List<Course> FrequentedCourses { get; set; } // N:N con Course
    }

    public class Course
    {
        [Key] public int CourseId { get; set; }
        public string Name { get; set; }
        public CourseImage CourseImage { get; set; } // Riferimento 1:1 alla tabella figlia
        public List<Student> StudentsEnrolled { get; set; } // N:N con Student
    }

    public class CourseImage
    {
        [Key] public int CourseImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        // Chiave esterna 1:1 con la tabella genitrice Course
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public class Review
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        // Vincolo 1:N
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

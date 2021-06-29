using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastHope.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<CourseTopic> CourseTopics { get; set; }
    }
}
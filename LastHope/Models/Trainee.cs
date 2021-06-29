using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastHope.Models
{
    public class Trainee
    {
        public int TraineeID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public int Phone { get; set; }
        public int TOPEIC { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
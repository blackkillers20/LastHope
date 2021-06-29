using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastHope.Models
{
    public class CourseTopic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public string CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
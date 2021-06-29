using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastHope.Models
{
    public class Trainer
    {
        public int TrainerID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public int Phone { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TrainerAssign> TrainerAssigns { get; set; }
    }
}
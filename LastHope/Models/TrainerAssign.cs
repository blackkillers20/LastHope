using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastHope.Models
{
    public class TrainerAssign
    {
        public int ID { get; set; }
        public int TopicID { get; set; }
        public int TrainerID { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual Trainer Trainer { get; set; }

    }
}
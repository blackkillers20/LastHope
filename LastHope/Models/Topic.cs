using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastHope.Models
{
    public class Topic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TopicID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<TrainerAssign> TrainerAssigns { get; set; }
    }
}
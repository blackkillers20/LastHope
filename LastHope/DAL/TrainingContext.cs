using LastHope.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LastHope.DAL
{
    public class TrainingContext : DbContext
    {
        public TrainingContext() : base("SchoolContext")
        {
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerAssign> TrainerAssigns { get; set; }
        public DbSet<CourseTopic> CourseTopics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<LastHope.Models.Staff> Staffs { get; set; }
    }
}
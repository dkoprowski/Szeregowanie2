using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SzeregowanieProjekt2.Models.BasicModels
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int id { get; set; }

        public string label { get; set; }

        public int release { get; set; }
        public int deadline { get; set; }
        public int processingTime { get; set; }

        public Color color { get; set; }


    }

    public class TaskDBContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
    }
}

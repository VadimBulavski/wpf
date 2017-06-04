using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSearchBank.Entitys
{
    [Table("Punkts")]
    public class Punkt
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NamePunkt { get; set; }
        [Required]
        public Bank BankName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Housing { get; set; }
        public string Office { get; set; }
        public double Xcoord { get; set; }
        public double Ycoord { get; set; }
        public DateTime? DateOpening { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public TimeSpan? LunchTimeStart { get; set; }
        public TimeSpan? LunchTimeEnd { get; set; }
        public TimeSpan? MaintenanceTimeStart { get; set; }
        public TimeSpan? MaintenanceTimeEnd { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Recall> Recalls { get; set; }
        public ICollection<Service> Service { get; set; }
    }
}

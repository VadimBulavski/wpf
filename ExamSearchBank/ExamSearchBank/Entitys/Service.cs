using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSearchBank.Entitys
{
    [Table("Services")]
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        public ICollection<Punkt> Punkt { get; set; }
    }
}

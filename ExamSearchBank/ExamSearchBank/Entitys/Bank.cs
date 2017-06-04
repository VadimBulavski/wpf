using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSearchBank.Entitys
{
    [Table("Banks")]
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameBank { get; set; }
        public ICollection<Kurs> Kurs { get; set; }
        public ICollection<Punkt> Puncts { get; set; }
    }
}

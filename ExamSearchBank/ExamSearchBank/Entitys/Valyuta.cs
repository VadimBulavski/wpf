using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSearchBank.Entitys
{
    [Table("Valyutes")]
    public class Valyuta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ValyutaName { get; set; }
        public ICollection<Kurs> Kurs { get; set; }
    }
}

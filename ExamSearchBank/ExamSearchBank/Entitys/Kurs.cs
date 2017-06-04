using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSearchBank.Entitys
{
    [Table("Kurses")]
    public class Kurs
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Bank> Banks { get; set; }
        public Valyuta Valyuta { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Sell { get; set; }
        public decimal Buy { get; set; }
    }
}

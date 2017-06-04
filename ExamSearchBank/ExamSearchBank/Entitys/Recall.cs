using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSearchBank.Entitys
{
    [Table("Recalls")]
    public class Recall
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameRecall { get; set; }
        [MaxLength]
        public string ContextRecall { get; set; }
        [Required]
        public string ClientFirstName { get; set; }
        [Required]
        public string ClientLastName { get; set; }
        [Required]
        public string ClientPatronymic { get; set; }
        public string ClientPhone { get; set; }
        public string ClientCity { get; set; }
        public string ClientStreet { get; set; }
        public string ClientHouse { get; set; }
        public Punkt Punkt { get; set; }
        public DateTime Date { get; set; }
    }
}

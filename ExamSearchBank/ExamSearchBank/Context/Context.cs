using ExamSearchBank.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSearchBank.Context
{
    public class ContextDb:DbContext
    {
        public ContextDb() { }
        public ContextDb(string ConnectionString)
            :base(ConnectionString)
        {

        }
    
        public DbSet<Bank> Banks { get; set; }   
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Kurs> Kurs { get; set; }
        public DbSet<Punkt> Punkt { get; set; }
        public DbSet<Recall> Recalls { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Valyuta> Valyuta { get; set; }

    }
}

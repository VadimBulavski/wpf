using ExamSearchBank.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExamSearchBank.Forms
{
    /// <summary>
    /// Логика взаимодействия для CreateValyuta.xaml
    /// </summary>
    public partial class CreateValyuta : Window
    {
        Context.ContextDb dbContext; 
        public CreateValyuta()
        {
            InitializeComponent();
            string conn = @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True";
            dbContext = new Context.ContextDb(conn);
            dbContext.SaveChanges();
        }

        private void btValyutaOk_Click(object sender, RoutedEventArgs e)
        {
            int current = 0;
            Valyuta val = new Valyuta() { ValyutaName = tbValyutaName.Text };
            List<string> names = dbContext.Valyuta.Where(p=>p.ValyutaName == val.ValyutaName).Select(s => s.ValyutaName).ToList();
            foreach(string s in names)
            {
                if (s == tbValyutaName.Text)
                    current++;
            }
            if(current > 0)
            {
                MessageBox.Show("Повтор данных");
            }
            else
            {
                dbContext.Valyuta.Add(val);
                dbContext.SaveChanges();
                if (MessageBox.Show("Данные успешно внесены") == MessageBoxResult.OK)
                {
                    this.Close();
                    
                }
            }
                
        }
    }
}

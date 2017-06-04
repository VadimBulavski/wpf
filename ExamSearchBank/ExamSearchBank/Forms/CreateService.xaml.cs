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
    /// Логика взаимодействия для CreateService.xaml
    /// </summary>
    public partial class CreateService : Window
    {
        Context.ContextDb dbContext;
        public CreateService()
        {
            InitializeComponent();
            string conn = @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True";
            dbContext = new Context.ContextDb(conn);
            dbContext.SaveChanges();
        }

        private void btServiceOk_Click(object sender, RoutedEventArgs e)
        {
            int current = 0;
            Service service = new Service() { ServiceName = tbServiceName.Text};
            List<string> names = dbContext.Services.Where(p => p.ServiceName == service.ServiceName).Select(s => s.ServiceName).ToList();
            foreach (string s in names)
            {
                if (s == tbServiceName.Text)
                    current++;
            }
            if (current > 0)
            {
                MessageBox.Show("Повтор данных");
            }
            else
            {
                dbContext.Services.Add(service);
                dbContext.SaveChanges();
                if (MessageBox.Show("Данные успешно внесены") == MessageBoxResult.OK)
                {
                    this.Close();

                }
            }
        }
    }
}

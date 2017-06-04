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
    /// Логика взаимодействия для CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Window
    {
        Context.ContextDb dbContext;
        public CreateEmployee()
        {
            InitializeComponent();
            string conn = @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True";
            dbContext = new Context.ContextDb(conn);
        }

        private void btEmployeeOk_Click(object sender, RoutedEventArgs e)
        {
            Employee empl = new Employee() 
            { 
                FirstName = tbFirstName.Text, 
                LastName = tbLastName.Text, 
                Patronymic = tbPatronymic.Text 
            };
            dbContext.Employees.Add(empl);
            dbContext.SaveChanges();
            if(MessageBox.Show("Данные успешно внесены!") == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
    }
}

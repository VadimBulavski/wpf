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
using System.Collections.ObjectModel;

namespace ExamSearchBank.Forms
{
    /// <summary>
    /// Логика взаимодействия для CreateRecall.xaml
    /// </summary>
    public partial class CreateRecall : Window
    {
        Context.ContextDb dbContext;
        List<Bank> banks;
        public CreateRecall()
        {
            InitializeComponent();
            string conn = @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True";
            dbContext = new Context.ContextDb(conn);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            banks = dbContext.Banks.Select(s => s).ToList();
            cbRecallBank.ItemsSource = banks;
            cbRecallBank.DisplayMemberPath = "NameBank";
        }

        private void btRecallOk_Click(object sender, RoutedEventArgs e)
        {
            Recall recall = new Recall();
            if (tbRecallName.Text == string.Empty || tbClientFirstName.Text == string.Empty ||
                tbClientLastName.Text == string.Empty || tbClientPatronymic.Text == string.Empty)
                MessageBox.Show("Заполните все обязательные поля!");
            else
            {
                recall.NameRecall = tbRecallName.Text;
                recall.ContextRecall = tbRecallContext.Text;
                recall.ClientFirstName = tbClientFirstName.Text;
                recall.ClientLastName = tbClientLastName.Text;
                recall.ClientPatronymic = tbClientPatronymic.Text;
                recall.ClientPhone = tbClientPhone.Text;
                recall.ClientCity = tbClientCity.Text;
                recall.ClientStreet = tbClientStreet.Text;
                recall.ClientHouse = tbClientHouse.Text;
                recall.Date = DateTime.Now;
                recall.Punkt = (Punkt)cbRecallPunkt.SelectionBoxItem;
                dbContext.Recalls.Add(recall);
                dbContext.SaveChanges();
            }
           
        }
    }
}

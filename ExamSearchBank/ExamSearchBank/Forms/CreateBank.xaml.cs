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
    /// Логика взаимодействия для CreateBank.xaml
    /// </summary>
    public partial class CreateBank : Window
    {
        Context.ContextDb dbContext;
        public CreateBank()
        {
            InitializeComponent();
            string conn = @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True";
            dbContext = new Context.ContextDb(conn);
        }

        private void btCreateValyuta_Click(object sender, RoutedEventArgs e)
        {
            CreateValyuta crVal = new CreateValyuta();
            if(crVal.ShowDialog().HasValue)
            {
                foreach (UIElement cbElem in spValyuta.Children)
                {
                    if (cbElem is ComboBox)
                    {
                        ((ComboBox)cbElem).ItemsSource = dbContext.Valyuta.Select(s => s).ToList();
                        ((ComboBox)cbElem).DisplayMemberPath = "ValyutaName";
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (UIElement cbElem in spValyuta.Children)
            {
                if(cbElem is ComboBox)
                {
                    ((ComboBox)cbElem).ItemsSource = dbContext.Valyuta.Select(s => s).ToList();
                    ((ComboBox)cbElem).DisplayMemberPath = "ValyutaName";
                }
            }
        }

        private void btBankOk_Click(object sender, RoutedEventArgs e)
        {
            Bank bank = new Bank() { NameBank = tbBankName.Text, Kurs = new List<Kurs>(), Puncts = new List<Punkt>()};
            List<string> nameBank = dbContext.Banks.Where(p => p.NameBank == tbBankName.Text).Select(s => s.NameBank).ToList();
            if (tbBankName.Text == string.Empty)
                MessageBox.Show("Неправильное имя банка!");
            else
            {
                int current = 0;
                foreach (string s in nameBank)
                {
                    if (s == tbBankName.Text)
                        current++;
                }
                if (current > 0)
                {
                    MessageBox.Show("Банк с данным именем уже существует!");
                }
                else
                {
                    List<Valyuta> valList = new List<Valyuta>();
                    List<string> sellList = new List<string>();
                    List<string> buyList = new List<string>();
                    foreach (UIElement valElem in spValyuta.Children)
                    {
                        if (valElem is ComboBox)
                            if (((ComboBox)valElem).Text != string.Empty)
                                valList.Add((Valyuta)((ComboBox)valElem).SelectionBoxItem);
                    }

                    foreach (UIElement sellElem in spSell.Children)
                    {
                        if (sellElem is TextBox)
                            if (((TextBox)sellElem).Text != string.Empty)
                                sellList.Add(((TextBox)sellElem).Text);
                    }

                    foreach (UIElement buyElem in spBuy.Children)
                    {
                        if (buyElem is TextBox)
                            if (((TextBox)buyElem).Text != string.Empty)
                                buyList.Add(((TextBox)buyElem).Text);
                    }
                    for (int a = 0; a < valList.Count(); a++)
                    {
                        Kurs kurs = new Kurs()
                        {
                            Valyuta = valList[a],
                            Date = DateTime.Now.Date,
                            Time = DateTime.Now.TimeOfDay,
                            Sell = decimal.Parse(sellList[a]),
                            Buy = decimal.Parse(buyList[a])
                        };
                        bank.Kurs.Add(kurs);
                    }
                    dbContext.Banks.Add(bank);
                    dbContext.SaveChanges();

                    if (MessageBox.Show("Данные успешно внесены") == MessageBoxResult.OK)
                    {
                        this.Close();
                    }
                }
            }
           
        }
    }
}

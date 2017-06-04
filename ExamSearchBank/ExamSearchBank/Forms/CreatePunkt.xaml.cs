using BaseMapApp.CustomMarkers;
using ExamSearchBank.Entitys;
using GMap.NET.WindowsPresentation;
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
    /// Логика взаимодействия для CreatePunkt.xaml
    /// </summary>
    public partial class CreatePunkt : Window
    {
        Context.ContextDb dbContext;
        public CreatePunkt()
        {
            InitializeComponent();
            string conn = @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True";
            dbContext = new Context.ContextDb(conn);
        }

        private void btAddBank_Click(object sender, RoutedEventArgs e)
        {
            CreateBank crBank = new CreateBank();
            if(crBank.ShowDialog().HasValue)
            {
                cbSelectBankName.ItemsSource = dbContext.Banks.Select(s => s).ToList();
                cbSelectBankName.DisplayMemberPath = "NameBank";
            }
        }

        private void btAddServise_Click(object sender, RoutedEventArgs e)
        {
            CreateService crService = new CreateService();
            if(crService.ShowDialog().HasValue)
            {
                foreach (UIElement spElem in gridService.Children)
                {
                    if (spElem is StackPanel)
                        foreach (UIElement cbElem in ((StackPanel)spElem).Children)
                            if (cbElem is ComboBox)
                            {
                                ((ComboBox)cbElem).DisplayMemberPath = "ServiceName";
                                ((ComboBox)cbElem).ItemsSource = dbContext.Services.Select(s => s).ToList();
                            }          
                }
            }
        }

        private void btCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployee crEmpl = new CreateEmployee();
            if(crEmpl.ShowDialog().HasValue)
            {
                cbSelectEmployee.ItemsSource = dbContext.Employees.Select(s => s).ToList();
                cbSelectEmployee.DisplayMemberPath = new Employee().ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbSelectBankName.ItemsSource = dbContext.Banks.Select(s => s).ToList();
            cbSelectBankName.DisplayMemberPath = "NameBank";

            foreach(UIElement gridElem in gridAddEmployee.Children)
            {
                if (gridElem is StackPanel)
                    foreach (UIElement cbElem in ((StackPanel)gridElem).Children)
                        if (cbElem is ComboBox)
                        {
                            ((ComboBox)cbElem).ItemsSource = dbContext.Employees.Select(s => s).ToList();
                            ((ComboBox)cbElem).DisplayMemberPath = new Employee().ToString();
                        }
                            
            }

            foreach (UIElement spElem in gridService.Children)
            {
                if (spElem is StackPanel)
                    foreach (UIElement cbElem in ((StackPanel)spElem).Children)
                        if (cbElem is ComboBox)
                        {
                            ((ComboBox)cbElem).DisplayMemberPath = "ServiceName";
                            ((ComboBox)cbElem).ItemsSource = dbContext.Services.Select(s => s).ToList();
                        }
            }
        }

        private void btCreatePunktOk_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            
            Punkt punkt = new Punkt();
            if (tbPunktName.Text == string.Empty)
                MessageBox.Show("Введите название отделения");
            else
            {
                punkt.NamePunkt = tbPunktName.Text;
                if (cbSelectBankName.Text == string.Empty)
                    MessageBox.Show("Не выбран банк");
                else
                {
                    punkt.BankName = (Bank)cbSelectBankName.SelectionBoxItem;
                    punkt.Phone = tbPunktPhone.Text;
                    punkt.City = tbPunktCity.Text;
                    punkt.Street = tbPunktStreet.Text;
                    punkt.House = tbPunktHouse.Text;
                    punkt.Housing = tbPunktHousing.Text;
                    punkt.Office = tbPunktOffice.Text;
                    punkt.Xcoord = double.Parse(tbPunktX.Text);
                    punkt.Ycoord = double.Parse(tbPunktY.Text);
                    if (dpDateOpening.Text == string.Empty)
                        punkt.DateOpening = null;
                    else
                    {
                        punkt.DateOpening = (DateTime)dpDateOpening.SelectedDate;
                        if (Int32.Parse(tbStartTimeHour.Text) > 24 || Int32.Parse(tbStartTimeMinute.Text) > 60)
                            MessageBox.Show("Неверный формат времени", labStartTime.Content.ToString());
                        else
                        {
                            TimeSpan time = new TimeSpan(Int32.Parse(tbStartTimeHour.Text), Int32.Parse(tbStartTimeMinute.Text), 0);
                            punkt.StartTime = time;
                            if (Int32.Parse(tbEndTimeHour.Text) > 24 || Int32.Parse(tbEndTimeMinute.Text) > 60)
                                MessageBox.Show("Неверный формат времени", labEndTime.Content.ToString());
                            else
                            {
                                TimeSpan time2 = new TimeSpan(Int32.Parse(tbEndTimeHour.Text), Int32.Parse(tbEndTimeMinute.Text), 0);
                                punkt.EndTime = time2;
                                if (Int32.Parse(tbStartLunchTimeHour.Text) > 24 || Int32.Parse(tbStartlunchTimeMinute.Text) > 60
                                    || Int32.Parse(tbEndLunchTimeHour.Text) > 24 || Int32.Parse(tbEndlunchTimeMinute.Text) > 60)
                                    MessageBox.Show("Неверный формат времени", labEndTime.Content.ToString());
                                else
                                {
                                    TimeSpan timeStart = new TimeSpan(Int32.Parse(tbStartLunchTimeHour.Text), Int32.Parse(tbStartlunchTimeMinute.Text), 0);
                                    punkt.LunchTimeStart = timeStart;
                                    TimeSpan timeEnd = new TimeSpan(Int32.Parse(tbEndLunchTimeHour.Text), Int32.Parse(tbEndlunchTimeMinute.Text), 0);
                                    punkt.LunchTimeEnd = timeEnd;
                                    if (Int32.Parse(tbStartMaintenanceTimeHour.Text) > 24 || Int32.Parse(tbStartMaintenanceTimeMinute.Text) > 60
                                        || Int32.Parse(tbEndMaintenanceTimeHour.Text) > 24 || Int32.Parse(tbEndMaintenanceTimeMinute.Text) > 60)
                                        MessageBox.Show("Неверный формат времени", labMaintenanceTime.Content.ToString());
                                    else
                                    {
                                        TimeSpan timeStart2 = new TimeSpan(Int32.Parse(tbStartMaintenanceTimeHour.Text),
                                                                          Int32.Parse(tbStartMaintenanceTimeMinute.Text), 0);
                                        punkt.MaintenanceTimeStart = timeStart2;
                                        TimeSpan timeEnd2 = new TimeSpan(Int32.Parse(tbEndMaintenanceTimeHour.Text),
                                                                         Int32.Parse(tbEndMaintenanceTimeMinute.Text), 0);
                                        punkt.MaintenanceTimeEnd = timeEnd2;

                                        punkt.Employees = new List<Employee>();
                                        foreach (UIElement gridElem in gridAddEmployee.Children)
                                        {
                                            if (gridElem is StackPanel)
                                                foreach (UIElement cbElem in ((StackPanel)gridElem).Children)
                                                    if (cbElem is ComboBox)
                                                    {
                                                        if (((ComboBox)cbElem).Text != string.Empty)
                                                            punkt.Employees.Add((Employee)((ComboBox)cbElem).SelectionBoxItem);
                                                    }
                                        }

                                        punkt.Recalls = new List<Recall>();
                                        punkt.Service = new List<Service>();
                                        foreach (UIElement spElem in gridService.Children)
                                        {
                                            if (spElem is StackPanel)
                                                foreach (UIElement cbElem in ((StackPanel)spElem).Children)
                                                    if (cbElem is ComboBox)
                                                    {
                                                        if (((ComboBox)cbElem).Text != string.Empty)
                                                            punkt.Service.Add(((Service)((ComboBox)cbElem).SelectionBoxItem));
                                                    }
                                        }
                                        dbContext.Punkt.Add(punkt);
                                        dbContext.SaveChanges();

                                        if (MessageBox.Show("Данные успешно внесены!") == MessageBoxResult.OK)
                                            this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btEditPunkt_Click(object sender, RoutedEventArgs e)
        {
            
            Punkt punkt = (Punkt)this.DataContext;
            if (tbPunktName.Text == string.Empty)
                MessageBox.Show("Введите название отделения");
            else
            {
                punkt.NamePunkt = tbPunktName.Text;
                if (cbSelectBankName.Text == string.Empty)
                    MessageBox.Show("Не выбран банк");
                else
                {
                    punkt.BankName = (Bank)cbSelectBankName.SelectionBoxItem;
                    punkt.Phone = tbPunktPhone.Text;
                    punkt.City = tbPunktCity.Text;
                    punkt.Street = tbPunktStreet.Text;
                    punkt.House = tbPunktHouse.Text;
                    punkt.Housing = tbPunktHousing.Text;
                    punkt.Office = tbPunktOffice.Text;
                    punkt.Xcoord = double.Parse(tbPunktX.Text);
                    punkt.Ycoord = double.Parse(tbPunktY.Text);
                    if (dpDateOpening.Text == string.Empty)
                        punkt.DateOpening = null;
                    else
                    {
                        punkt.DateOpening = (DateTime)dpDateOpening.SelectedDate;
                        if (Int32.Parse(tbStartTimeHour.Text) > 24 || Int32.Parse(tbStartTimeMinute.Text) > 60)
                            MessageBox.Show("Неверный формат времени", labStartTime.Content.ToString());
                        else
                        {
                            TimeSpan time = new TimeSpan(Int32.Parse(tbStartTimeHour.Text), Int32.Parse(tbStartTimeMinute.Text), 0);
                            punkt.StartTime = time;
                            if (Int32.Parse(tbEndTimeHour.Text) > 24 || Int32.Parse(tbEndTimeMinute.Text) > 60)
                                MessageBox.Show("Неверный формат времени", labEndTime.Content.ToString());
                            else
                            {
                                TimeSpan time2 = new TimeSpan(Int32.Parse(tbEndTimeHour.Text), Int32.Parse(tbEndTimeMinute.Text), 0);
                                punkt.EndTime = time2;
                                if (Int32.Parse(tbStartLunchTimeHour.Text) > 24 || Int32.Parse(tbStartlunchTimeMinute.Text) > 60
                                    || Int32.Parse(tbEndLunchTimeHour.Text) > 24 || Int32.Parse(tbEndlunchTimeMinute.Text) > 60)
                                    MessageBox.Show("Неверный формат времени", labEndTime.Content.ToString());
                                else
                                {
                                    TimeSpan timeStart = new TimeSpan(Int32.Parse(tbStartLunchTimeHour.Text), Int32.Parse(tbStartlunchTimeMinute.Text), 0);
                                    punkt.LunchTimeStart = timeStart;
                                    TimeSpan timeEnd = new TimeSpan(Int32.Parse(tbEndLunchTimeHour.Text), Int32.Parse(tbEndlunchTimeMinute.Text), 0);
                                    punkt.LunchTimeEnd = timeEnd;
                                    if (Int32.Parse(tbStartMaintenanceTimeHour.Text) > 24 || Int32.Parse(tbStartMaintenanceTimeMinute.Text) > 60
                                        || Int32.Parse(tbEndMaintenanceTimeHour.Text) > 24 || Int32.Parse(tbEndMaintenanceTimeMinute.Text) > 60)
                                        MessageBox.Show("Неверный формат времени", labMaintenanceTime.Content.ToString());
                                    else
                                    {
                                        TimeSpan timeStart2 = new TimeSpan(Int32.Parse(tbStartMaintenanceTimeHour.Text),
                                                                          Int32.Parse(tbStartMaintenanceTimeMinute.Text), 0);
                                        punkt.MaintenanceTimeStart = timeStart2;
                                        TimeSpan timeEnd2 = new TimeSpan(Int32.Parse(tbEndMaintenanceTimeHour.Text),
                                                                         Int32.Parse(tbEndMaintenanceTimeMinute.Text), 0);
                                        punkt.MaintenanceTimeEnd = timeEnd2;

                                        punkt.Employees = new List<Employee>();
                                        foreach (UIElement gridElem in gridAddEmployee.Children)
                                        {
                                            if (gridElem is StackPanel)
                                                foreach (UIElement cbElem in ((StackPanel)gridElem).Children)
                                                    if (cbElem is ComboBox)
                                                    {
                                                        if (((ComboBox)cbElem).Text != string.Empty)
                                                            punkt.Employees.Add((Employee)((ComboBox)cbElem).SelectionBoxItem);
                                                    }
                                        }

                                        punkt.Recalls = new List<Recall>();
                                        punkt.Service = new List<Service>();
                                        foreach (UIElement spElem in gridService.Children)
                                        {
                                            if (spElem is StackPanel)
                                                foreach (UIElement cbElem in ((StackPanel)spElem).Children)
                                                    if (cbElem is ComboBox)
                                                    {
                                                        if (((ComboBox)cbElem).Text != string.Empty)
                                                            punkt.Service.Add((Service)((ComboBox)cbElem).SelectionBoxItem);
                                                    }
                                        }
                                        dbContext.SaveChanges();

                                        if (MessageBox.Show("Данные успешно внесены!") == MessageBoxResult.OK)
                                            this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

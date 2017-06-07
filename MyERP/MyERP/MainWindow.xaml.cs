using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListCollectionView view;
        WindowNew win = new WindowNew();
        public MainWindow()
        {
            InitializeComponent();
            view = (ListCollectionView)CollectionViewSource.GetDefaultView(lbListProfesion.ItemsSource);
         
        }

        private void lbListProfesion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dictionary<string, double> ratingDiagramm = new Dictionary<string, double>();
            ratingDiagramm.Add("Выполнения задания в срок", Rating.EffectivenessOfImplementation);
            ratingDiagramm.Add("Соответствие квалификации", Rating.EffectivenessOfQualifications);
            ratingDiagramm.Add("Качества выполнения", Rating.EffectivenessOfQuality);
            ratingDiagramm.Add("Работы в команде", Rating.EffectivenessOfTeamWork);
            ratingDiagramm.Add("Отработанное время", Rating.EfficiencyOfTimeWorked);
            pieChart.DataContext = ratingDiagramm;
        }

        private void cbAll_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = null;
        }

        private void cbDirector_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = delegate(object item)
            {
                Profession prof = (Profession)item;
                return (prof.Position == Position.Director);
            };
            
        }

        private void cbManager_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = delegate(object item)
            {
                Profession prof = (Profession)item;
                return (prof.Department == Departament.Managers);
            };
        }

        private void cbDeputyDirector_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = delegate(object item)
            {
                Profession prof = (Profession)item;
                return (prof.Position == Position.DeputyDirector);
            };
        }

        private void cbDisigner_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = delegate(object item)
            {
                Profession prof = (Profession)item;
                return (prof.Department == Departament.Disigners);
            };
        }

        private void cbHeadOfDepartment_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = delegate(object item)
            {
                Profession prof = (Profession)item;
                return (prof.Position == Position.HeadOfDepartment);
            };
        }

        private void cbWorking_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = delegate(object item)
            {
                Profession prof = (Profession)item;
                return (prof.Position == Position.Working);
            }; 
        }

        private void cbShipping_Checked(object sender, RoutedEventArgs e)
        {
            view.Filter = delegate(object item)
            {
                Profession prof = (Profession)item;
                return (prof.Department == Departament.Shipping);
            };
        }

        private void buttDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить текущую запись?",
                                                      "Внимание!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            //if(result == MessageBoxResult.OK)
               // profession.Remove((Profession)lbListProfesion.SelectedItem);
        }

        private void buttEdit_Click(object sender, RoutedEventArgs e)
        {
            win.DataContext = lbListProfesion.SelectedItem;
            if (win.ShowDialog() == true)
            {
                lbListProfesion.SelectedItem = win.DataContext;
            }
        }

        AddProfessionWindow addPofWindow = new AddProfessionWindow();
        private void buttNew_Click(object sender, RoutedEventArgs e)
        {
            addPofWindow.Show();
            //win.DataContext = new Profession();
            //if (win.ShowDialog() == true)
            //{
            //    profession.Add((Profession)win.DataContext);
            //}       
        }
    }



    public class ConvertorData : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime temp = (DateTime)value;
            return string.Format("{0:dd MMMM yyyy}", temp);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
    public class ConvertorPosition : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Profession prof = new Profession();
            Position temp = (Position)value;
            return string.Format("{0}", prof.GetPosition(temp));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
    public class ConvertorDepartment : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Profession dep = new Profession();
            Departament temp = (Departament)value;
            return string.Format("{0}", dep.GetDepartment(temp));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class ConvertorOrderData : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime temp = (DateTime)value;
            return string.Format("{0:dd.MM.yy}", temp);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string temp = (string)value;
            return DateTime.Parse(temp);
        }
    }
}

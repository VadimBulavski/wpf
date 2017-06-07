using Microsoft.Win32;
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

namespace MyERP
{
    /// <summary>
    /// Логика взаимодействия для AddProfessionWindow.xaml
    /// </summary>
    public partial class AddProfessionWindow : Window
    {
        OpenFileDialog myDialog;
        public AddProfessionWindow()
        {
            InitializeComponent();
            myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.GIF)|*.JPG;*.GIF" + "|Все файлы (*.*)|*.* ";
        }

        private void buttAddFoto_Click(object sender, RoutedEventArgs e)
        {
            if (myDialog.ShowDialog().Value)
            {
                imgFoto.Source = new BitmapImage(new Uri(myDialog.FileName, UriKind.RelativeOrAbsolute));
            }
        }

        //private void buttOK_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBoxResult result =
        //        MessageBox.Show("Хотите изменить или добавить элемент?", "Внимание!",
        //        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        //    if (result == MessageBoxResult.OK)
        //    {
        //        DialogResult = true;
        //        this.Close();
        //    }
        //}
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using GMap.NET.WindowsPresentation;
using ExamSearchBank;
using ExamSearchBank.Forms;
using ExamSearchBank.Context;
using ExamSearchBank.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace BaseMapApp.CustomMarkers
{
   /// <summary>
   /// Interaction logic for CustomMarkerDemo.xaml
   /// </summary>
   public partial class CustomMarkerRed
   {
      Popup Popup;
      Label Label;
      GMapMarker Marker;
      MainWindow MainWindow;
      ContextDb dbContext;

      public CustomMarkerRed(MainWindow window, GMapMarker marker, string title)
      {
         dbContext = new ContextDb(@"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True");

         this.InitializeComponent();

         this.MainWindow = window;
         this.Marker = marker;

         Popup = new Popup();
         Label = new Label();

         this.Loaded += new RoutedEventHandler(CustomMarkerDemo_Loaded);
         this.SizeChanged += new SizeChangedEventHandler(CustomMarkerDemo_SizeChanged);
         this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);
         this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
         this.MouseMove += new MouseEventHandler(CustomMarkerDemo_MouseMove);
         this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
         this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonDown);

         Popup.Placement = PlacementMode.Mouse;
         {
            Label.Background = Brushes.Blue;
            Label.Foreground = Brushes.White;
            Label.BorderBrush = Brushes.WhiteSmoke;
            Label.BorderThickness = new Thickness(2);
            Label.Padding = new Thickness(5);
            Label.FontSize = 22;
            Label.Content = title;
         }
         Popup.Child = Label;
      }

      void CustomMarkerDemo_Loaded(object sender, RoutedEventArgs e)
      {
         if(icon.Source.CanFreeze)
         {
            icon.Source.Freeze();
         }
      }

      void CustomMarkerDemo_SizeChanged(object sender, SizeChangedEventArgs e)
      {
         Marker.Offset = new Point(-e.NewSize.Width/2, -e.NewSize.Height);
      }

      void CustomMarkerDemo_MouseMove(object sender, MouseEventArgs e)
      {
         if(e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
         {
            Point p = e.GetPosition(MainWindow.gMapControl);
            Marker.Position = MainWindow.gMapControl.FromLocalToLatLng((int)p.X, (int)p.Y);
         }
      }

      void CustomMarkerDemo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         if(!IsMouseCaptured)
         {
            Mouse.Capture(this);
         }
      }

      void CustomMarkerDemo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {
         if(IsMouseCaptured)
         {
            Mouse.Capture(null);
         }
      }

      void MarkerControl_MouseLeave(object sender, MouseEventArgs e)
      {
         Marker.ZIndex -= 10000;
         Popup.IsOpen = false;
      }

      void MarkerControl_MouseEnter(object sender, MouseEventArgs e)
      {
         Marker.ZIndex += 10000;
         Popup.IsOpen = true;

         Label label = (Label)Popup.Child;
         var punkt = dbContext.Punkt.Where(p => p.NamePunkt == label.Content.ToString()).Select(s => s).ToList();
         foreach(var p in punkt)
         {
             MainWindow.tbNamePunkt.Text = p.NamePunkt;
             MainWindow.tbAddress.Text = p.City + " " + p.Street + " " + p.House + " " + p.Housing + " " + p.Office;
             MainWindow.tbPhone.Text = p.Phone;
             MainWindow.tbStartTime.Text = p.StartTime.ToString();
             MainWindow.tbEndTime.Text = p.EndTime.ToString();
             MainWindow.tbStartLunchTime.Text = p.LunchTimeStart.ToString();
             MainWindow.tbEndLunchTime.Text = p.LunchTimeEnd.ToString();
             MainWindow.tbMaintenanceTimeStart.Text = p.MaintenanceTimeStart.ToString();
             MainWindow.tbMaintenanceTimeEnd.Text = p.MaintenanceTimeEnd.ToString();
       
             /*foreach (var s in p.Service)
             {
                 Label serviceName = new Label();
                 serviceName.Content = s.ServiceName;
                 MainWindow.spInfo.Children.Add(serviceName);
             } */
         }      
      }

      private void cmAddRecall_Click(object sender, RoutedEventArgs e)
      {
          CreateRecall crRecall = new CreateRecall();
          crRecall.Show();
      }

      private void cmDeleteMarker_Click(object sender, RoutedEventArgs e)
      {

      }

      private void cmDeletePunkt_Click(object sender, RoutedEventArgs e)
      {

      }

      private void cmEditPunkt_Click(object sender, RoutedEventArgs e)
      {
          ContextDb dbContext = new ContextDb( @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True");
          CreatePunkt crPunkt = new CreatePunkt();
          CreateBank crBank = new CreateBank();
          Label label = (Label)Popup.Child;
          List<Punkt> punkts = dbContext.Punkt.Where(p=>p.NamePunkt == label.Content.ToString()).Select(s=>s).ToList();
          crPunkt.DataContext = punkts;
          crPunkt.btAddBank.Content = "Изменить курс";
          crPunkt.btCreatePunktOk.Visibility = System.Windows.Visibility.Collapsed;
          crPunkt.btEditPunkt.Visibility = System.Windows.Visibility.Visible;
          if (crPunkt.ShowDialog().HasValue)
              crPunkt.Close();
      }
   }
}
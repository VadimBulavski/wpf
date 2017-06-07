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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamSearchBank.Context;
using ExamSearchBank.Entitys;
using ExamSearchBank.Forms;
using GMap.NET.WindowsPresentation;
using BaseMapApp.CustomMarkers;
using GMap.NET.MapProviders;
using GMap.NET;

namespace ExamSearchBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GMapMarker currentMarker;
        public GMapMarker NewMarker;
        ContextDb dbContext;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = @"Data Source=(localdb)\v11.0;initial catalog = BanksDB.mdf;Integrated Security=True";
            dbContext = new ContextDb(connectionString);
            dbContext.SaveChanges();
        }


        private void cmAddRecall_Click(object sender, RoutedEventArgs e)
        {
            CreateRecall crRecall = new CreateRecall();
            crRecall.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gMapControl.MapProvider = GMapProviders.OpenStreetMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.Position = new PointLatLng(54.6961334816182, 25.2985095977783);

            gMapControl.Bearing = 0;
            gMapControl.MaxZoom = 17;
            gMapControl.MinZoom = 2;
            gMapControl.Zoom = 15;
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl.CanDragMap = true;

            gMapControl.Position = new GMap.NET.PointLatLng(53.902800, 27.561759);
            gMapControl.CanDragMap = true;

            gMapControl.ShowCenter = false;

            gMapControl.MouseLeftButtonDown += gMapControl_MouseLeftButtonDown;

            AddMarkers();
        }

        public void AddDefaultMarker(CreatePunkt crPunkt, GMapMarker demoMarker)
        {

            currentMarker = new GMapMarker(gMapControl.Position);
            currentMarker.Shape = new CustomMarkerRed(this, currentMarker, crPunkt.tbPunktName.Text);
            currentMarker.Position = demoMarker.Position;
            gMapControl.Markers.Add(currentMarker);
        }

        public void AddMarkers()
        {
            List<Punkt> punkts = dbContext.Punkt.Select(s => s).ToList();
            foreach(Punkt p in punkts)
            {
                currentMarker = new GMapMarker(gMapControl.Position);
                currentMarker.Shape = new CustomMarkerRed(this, currentMarker, p.NamePunkt);
                currentMarker.Position = new GMap.NET.PointLatLng(p.Ycoord, p.Xcoord);
                gMapControl.Markers.Add(currentMarker);
            }
        }

        private void gMapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(gMapControl);
            NewMarker = new GMapMarker(gMapControl.Position);
            NewMarker.Shape = new CustomMarkerDemo(this, NewMarker, "Пользовательский маркер");
            NewMarker.Position = gMapControl.FromLocalToLatLng((int)p.X, (int)p.Y);
            gMapControl.Markers.Add(NewMarker);
        }
    }
}

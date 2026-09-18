using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GMap.NET;
using GMap.NET.Avalonia;
using GMap.NET.MapProviders;
using GMap.NET.Markers;

namespace Demo.AvaloniaUi
{
    public partial class MainWindow : Window
    {
        public GMapControl MainMap { get; }

        private GMapRoute my_route;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            //  this.AttachDevTools();
#endif

            GoogleMapProvider.Instance.ApiKey = "AIzaSyAmO6pIPTz0Lt8lmYZEIAaixitKjq-4WlB";

            MainMap = this.Get<GMapControl>("GMap");
            MainMap.MapProvider = GMapProviders.OpenStreetMap;
            MainMap.Position = new PointLatLng(43.4270, 25.10);
            MainMap.FillEmptyTiles = true;
            MainMap.Markers.Add(new GMarkerRound(MainMap.Position, "1"));
            MainMap.Markers.Add(new GMarkerRound(new PointLatLng(43.4278, 25.1055), "2"));
            MainMap.Markers.Add(new GMarkerRound(new PointLatLng(45.4298, 27.1075), "3"));
            MainMap.Markers.Add(new GMarkerRound(new PointLatLng(43.4270, 25.10), "R1"));
            MainMap.Markers.Add(new GMarkerRound(new PointLatLng(43.4270, 25.14), "RN"));

            List<PointLatLng> route_ps = [];
            route_ps.Add(new PointLatLng(43.4270, 25.10));
            route_ps.Add(new PointLatLng(43.4270, 25.11));
            route_ps.Add(new PointLatLng(43.4275, 25.12));
            route_ps.Add(new PointLatLng(43.4280, 25.13));
            route_ps.Add(new PointLatLng(43.4300, 25.14));

            my_route = new GMapRoute(route_ps, "rute");
            MainMap.Routes.Add(my_route);

            MainMap.PointerPressed += MainMap_PointerPressed;
        }

        private void MainMap_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (e.KeyModifiers == Avalonia.Input.KeyModifiers.Control)
            {
                Point p = e.GetPosition(MainMap);
                PointLatLng plng = MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
                my_route.Points.Add(plng);
                MainMap.ForceUpdateOverlays();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnClosing(WindowClosingEventArgs e)
        {
            base.OnClosing(e);
            this.Get<GMapControl>("GMap").Dispose();
        }

    }
}

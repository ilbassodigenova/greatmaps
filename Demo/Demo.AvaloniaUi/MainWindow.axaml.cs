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

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            //  this.AttachDevTools();
#endif

            GoogleMapProvider.Instance.ApiKey = "AIzaSyAmO6pIPTz0Lt8lmYZEIAaixitKjq-4WlB";

            MainMap = this.Get<GMapControl>("GMap");
            MainMap.MapProvider = GMapProviders.OpenStreetMap;
            MainMap.Position = new PointLatLng(44.4268, 26.1025);
            MainMap.FillEmptyTiles = true;
            MainMap.Markers.Add(new GMarkerRound(MainMap.Position, "1"));
            MainMap.Markers.Add(new GMarkerRound(new PointLatLng(43.4278, 25.1055), "2"));
            MainMap.Markers.Add(new GMarkerRound(new PointLatLng(45.4298, 27.1075), "3"));
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

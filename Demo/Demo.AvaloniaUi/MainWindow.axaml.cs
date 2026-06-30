using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GMap.NET;
using GMap.NET.Avalonia;
using GMap.NET.MapProviders;

namespace Demo.AvaloniaUi
{
    public partial class MainWindow : Window
    {
        public GMapControl MainMap { get; }

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            GoogleMapProvider.Instance.ApiKey = "AIzaSyAmO6pIPTz0Lt8lmYZEIAaixitKjq-4WlB";

            MainMap = this.Get<GMapControl>("GMap");
            MainMap.MapProvider = GMapProviders.OpenStreetMap;
            MainMap.Position = new PointLatLng(44.4268, 26.1025);
            MainMap.FillEmptyTiles = true;
            MainMap.Markers.Add(new(MainMap.Position));
            MainMap.Markers.Add(new(new PointLatLng(44.4278, 26.1055)));
            MainMap.Markers.Add(new(new PointLatLng(44.4298, 26.1075)));
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

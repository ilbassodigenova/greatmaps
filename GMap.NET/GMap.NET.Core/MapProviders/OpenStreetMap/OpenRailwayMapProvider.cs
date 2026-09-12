using System;

namespace GMap.NET.MapProviders.OpenStreetMap
{
    public class OpenRailwayMapProvider : OpenStreetMapProviderBase
    {
        public static readonly OpenRailwayMapProvider Instance;

        OpenRailwayMapProvider()
        {
            RefererUrl = "https://www.openrailwaymap.org";
        }

        static OpenRailwayMapProvider()
        {
            Instance = new OpenRailwayMapProvider();
        }


        public OpenRailwayMapStyle Style = OpenRailwayMapStyle.standard;
        #region GMapProvider Members

        public override Guid Id
        {
            get;
        } = new Guid("0482c579-efdc-4cb5-814d-5efe6e1895a3");

        public override string Name
        {
            get;
        } = "OpenRailwayMap";

        GMapProvider[] _overlays;

        public override GMapProvider[] Overlays
        {
            get
            {
                if (_overlays == null)
                {
                    _overlays = new GMapProvider[] { this };
                }

                return _overlays;
            }
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, string.Empty);

            return GetTileImageUsingHttp(url);
        }

        #endregion

        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            return string.Format(UrlFormat, Style, zoom, pos.X, pos.Y);
        }

        static readonly string UrlFormat = "https://tiles.openrailwaymap.org/{0}/{1}/{2}/{3}.png";
    }
}

using Avalonia;
using Avalonia.Media;
using GMap.NET.Avalonia;

namespace GMap.NET.Markers
{
    public class GMarkerRound(PointLatLng p, string text) : GMapMarker(p)
    {
        private readonly string txt = text;

        public override void Render(DrawingContext drawingContext)
        {
            Point p = new Point(LocalPositionX, LocalPositionY);
            drawingContext.DrawEllipse(new SolidColorBrush(Colors.GreenYellow), new Pen(0x0), p, 10, 10);
            drawingContext.DrawText(format(txt), p);
        }


        private static FormattedText format(string txt)
        {
            FormattedText ft = new FormattedText(txt,
               System.Globalization.CultureInfo.CurrentCulture,
               FlowDirection.LeftToRight, new Typeface("GenericSansSerif"),
                       19, new SolidColorBrush(Colors.Black));
            return ft;
        }
    }
}

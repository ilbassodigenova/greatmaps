using System.Collections.Generic;
using System.Runtime.Serialization;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace GMap.NET.Avalonia
{
    public class GMapRoute : MapRoute, IShapable
    {
        public GMapRoute(string name) : base(name)
        {
        }

        public GMapRoute(MapRoute route) : base(route)
        {
        }

        public GMapRoute(IEnumerable<PointLatLng> points, string name) : base(points, name)
        {
        }

        protected GMapRoute(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


        /// <summary>
        ///     creates path from list of points, for performance set addBlurEffect to false
        /// </summary>
        /// <returns></returns>
        public virtual Path CreatePath(List<Point> localPath, bool addBlurEffect)
        {
            // Create a StreamGeometry to use to specify myPath.
            var geometry = new StreamGeometry();

            using (var ctx = geometry.Open())
            {
                //ctx.BeginFigure(localPath[0], false, false);
                //// Draw a line to the next specified point.
                //ctx.PolyLineTo(localPath, true, true);

                ctx.BeginFigure(localPath[0], false);
                // Draw a line to the next specified point.
                foreach (var path in localPath)
                {
                    ctx.LineTo(path);
                }
            }

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            //geometry.Freeze();
            //michele
            //geometry.EndBatchUpdate();
            // Create a path to draw a geometry with.
            var myPath = new Path();
            {
                // Specify the shape of the Path using the StreamGeometry.
                myPath.Data = geometry;

                if (addBlurEffect)
                {
                    //BlurEffect ef = new BlurEffect();
                    //{
                    //    ef.KernelType = KernelType.Gaussian;
                    //    ef.Radius = 3.0;
                    //    ef.RenderingBias = RenderingBias.Performance;
                    //}
                    //myPath.Effect = ef;
                }

                myPath.Stroke = Brushes.Navy;
                myPath.StrokeThickness = 5;
                myPath.StrokeJoin = PenLineJoin.Round;
                myPath.StrokeLineCap = PenLineCap.Square;
                //myPath.StrokeEndLineCap = PenLineCap.Square;
                myPath.Opacity = 0.6;
                myPath.IsHitTestVisible = false;
            }
            return myPath;
        }

        public void Render(DrawingContext drawingContext)
        {
            throw new System.NotImplementedException();
        }
    }
}

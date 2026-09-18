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
        /// Rendering params
        /// </summary>
        public IBrush Stroke = Brushes.Navy;

        /// <summary>
        /// Rendering params
        /// </summary>
        public int StrokeThickness = 5;

        /// <summary>
        /// Rendering params
        /// </summary>
        public PenLineJoin StrokeJoin = PenLineJoin.Round;

        /// <summary>
        /// Rendering params
        /// </summary>
        public PenLineCap StrokeLineCap = PenLineCap.Square;

        /// <summary>
        /// Rendering params
        /// </summary>
        public double Opacity = 0.6;

        /// <summary>
        /// Rendering params
        /// </summary>
        public bool IsHitTestVisible = false;

        /// <summary>
        /// This is updated by <see cref="CreatePath(List{Point}, bool)"/>. 
        /// </summary>
        public Path MyPath { get; set; } = new Path();


        /// <summary>
        ///     creates path from list of points. Path is stored automatically in <see cref="MyPath"/>
        /// </summary>
        /// <param name="addBlurEffect">nicer but slower performances</param>
        /// <param name="localPath">points to draw in local (x-y) coordinates</param>
        /// <returns>the created path</returns>
        public virtual Path CreatePath(List<Point> localPath, bool addBlurEffect)
        {
            // Create a StreamGeometry to use to specify myPath.
            StreamGeometry geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = geometry.Open())
            {
                //ctx.BeginFigure(localPath[0], false, false);
                //// Draw a line to the next specified point.
                //ctx.PolyLineTo(localPath, true, true);

                ctx.BeginFigure(localPath[0], false);
                // Draw a line to the next specified point.
                foreach (Point path in localPath)
                {
                    ctx.LineTo(path);
                }
            }

            // Create a path to draw a geometry with.
            MyPath = new Path();
            {
                // Specify the shape of the Path using the StreamGeometry.
                MyPath.Data = geometry;

                if (addBlurEffect)
                {
                    BlurEffect ef = new BlurEffect();
                    MyPath.Effect = ef;
                }

                MyPath.Stroke = Stroke;
                MyPath.StrokeThickness = StrokeThickness;
                MyPath.StrokeJoin = StrokeJoin;
                MyPath.StrokeLineCap = StrokeLineCap;
                MyPath.Opacity = Opacity;
                MyPath.IsHitTestVisible = IsHitTestVisible;
            }
            return MyPath;
        }

        /// <summary>
        /// renders on graphic context.
        /// </summary>
        /// <param name="drawingContext"></param>
        public void Render(DrawingContext drawingContext)
        {
            MyPath.Render(drawingContext);
        }
    }
}

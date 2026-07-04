using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Shapes;

namespace GMap.NET.Avalonia
{
    /// <summary>
    /// Interface for objects that have more than one shape
    /// </summary>
    public interface IShapable
    {

        public void Clear();

        public Path CreatePath(List<Point> localPath, bool addBlurEffect);
    }
}

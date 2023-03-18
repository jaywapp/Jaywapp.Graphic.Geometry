using Jaywapp.Graphic.Geometry.Interface;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Jaywapp.Graphic.Geometry.Service
{
    public class Drawer
    {
        #region Properties
        public List<IGeometry> Geometries { get; set; } = new List<IGeometry>();
        #endregion

        #region Constructor
        public Drawer(IEnumerable<IGeometry> geometries = null)
        {
            Geometries = geometries?.ToList() ?? new List<IGeometry>();
        }
        #endregion

        #region Functions
        public void Draw(WriteableBitmap bitmap)
        {
            var width = (int)bitmap.Width;
            var height = (int)bitmap.Height;

            bitmap.Lock();

            using (var surface = Create(bitmap))
            {
                surface.Canvas.Clear(SKColors.Black);

                foreach (var geometry in Geometries)
                    geometry.Draw(surface.Canvas);
            }

            bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            bitmap.Unlock();
        }

        private static SKSurface Create(WriteableBitmap bitmap)
        {
            var width = (int)bitmap.Width;
            var height = (int)bitmap.Height;
            var info = new SKImageInfo(width, height, SKColorType.Bgra8888);

            return SKSurface.Create(info, bitmap.BackBuffer, width * 4);
        }
        #endregion
    }
}

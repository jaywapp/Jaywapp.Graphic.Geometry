using SkiaSharp;

namespace Jaywapp.Graphic.Geometry.Interface
{
    public interface IGeometry
    {
        SKPaint Paint { get; }

        void Draw(SKCanvas canvas);
    }
}

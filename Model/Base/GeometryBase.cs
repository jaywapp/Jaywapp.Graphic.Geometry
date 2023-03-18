using Jaywapp.Graphic.Geometry.Helper;
using Jaywapp.Graphic.Geometry.Interface;
using SkiaSharp;
using System.Windows.Media;

namespace Jaywapp.Graphic.Geometry.Model.Base
{
    public abstract class GeometryBase : IGeometry
    {
        public SKPaint Paint { get; } = new SKPaint();

        private SKPaint SelectedPaint { get; } = new SKPaint();

        public Color Color
        {
            get => Paint.Color.Convert();
            set => Paint.Color = value.Convert();
        }

        public bool IsSelected { get; set; }

        public GeometryBase(Color color)
        {
            SelectedPaint.Color = SKColors.Red;
            Color = color;
        }

        public abstract void Draw(SKCanvas canvas);

        protected SKPaint GetPaint()
        {
            return IsSelected ? SelectedPaint : Paint;
        }
    }
}

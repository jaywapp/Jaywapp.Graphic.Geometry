namespace Jaywapp.Graphic.Geometry.Model
{
    public class Square : Rectangle
    {
        #region Properties
        public float SideLength { get; set; }
        #endregion

        #region Constructor
        public Square(float x, float y, float sideLength) : base(x, y, sideLength, sideLength)
        {
            SideLength = sideLength;
        }
        #endregion
    }
}

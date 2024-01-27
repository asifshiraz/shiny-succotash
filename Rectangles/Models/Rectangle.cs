using System.Xml;

namespace Rectangles.Models;

public class Rectangle
{
    private Point _topLeft, _bottomRight, _bottomLeft, _topRight;

    public Rectangle(Point topLeft, Point bottomRight)
    {
        _topLeft = topLeft;
        _bottomRight = bottomRight;
        _bottomLeft = new Point(topLeft.X, bottomRight.Y);
        _topRight = new Point(bottomRight.X, topLeft.Y);
    }

    public int TopY { get { return _topLeft.Y; } }

    public int BottomY { get { return _bottomRight.Y; } }

    public int LeftX { get { return _bottomLeft.X; } }

    public int RightX { get { return _topRight.X; } }

    public Point TopLeft { get { return _topLeft; } }

    public Point BottomLeft { get { return _bottomLeft; } }

    public Point BottomRight { get { return _bottomRight; } }

    public Point TopRight { get { return _topRight; } }

    public Line TopLine { get { return new Line(_topLeft, _topRight); } }

    public Line LeftLine { get { return new Line(_topLeft, _bottomLeft); } }

    public Line BottomLine { get { return new Line(_bottomLeft, _bottomRight); } }

    public Line RightLine { get { return new Line(_topRight, _bottomRight); } }
}

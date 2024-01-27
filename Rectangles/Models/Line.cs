namespace Rectangles.Models;

public struct Line
{
    public Point Start;
    public Point End;

    public Line(int x, int y, int x1, int y1)
    {
        Start = new Point(x, y);
        End = new Point(x1, y1);
    }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }
}

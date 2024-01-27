using Rectangles.Models;

namespace Rectanges.Tests;

public static class TestData
{
    public static Line Horizontal_left         = new Line(10, 20, 20, 20);
    public static Line Horizontal_left_higher  = new Line(10, 21, 20, 21);
    public static Line Horizontal_left_lower   = new Line(10, 19, 20, 19);

    public static Line Horizontal_center         = new Line(15, 20, 35, 20);
    public static Line Horizontal_center_higher  = new Line(15, 21, 35, 21);
    public static Line Horizontal_center_lower   = new Line(15, 19, 35, 19);

    public static Line Horizontal_right         = new Line(30, 20, 40, 20);
    public static Line Horizontal_right_higher  = new Line(30, 21, 40, 21);
    public static Line Horizontal_right_lower   = new Line(30, 19, 40, 19);
}

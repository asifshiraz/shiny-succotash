using Rectangles.Models;
using Rectangles.Services;

namespace Rectanges.Tests;
public class ShapeAnalyzerTests
{
    private ShapesAnalyzer _sut;

    public ShapeAnalyzerTests() 
    {
        _sut = new ShapesAnalyzer();
    }

    public static IEnumerable<object[]> LineOverlapsTestData()
    {
        // Overlapping lines
        yield return new object[] { TestData.Horizontal_left, TestData.Horizontal_right, false };
        yield return new object[] { TestData.Horizontal_left_higher, TestData.Horizontal_center, false };
        yield return new object[] { TestData.Horizontal_left_lower, TestData.Horizontal_center, false };

        // Nonoverlapping lines
        yield return new object[] { TestData.Horizontal_left, TestData.Horizontal_center, true };
        yield return new object[] { TestData.Horizontal_left_higher, TestData.Horizontal_center_higher, true };
        yield return new object[] { TestData.Horizontal_left_lower, TestData.Horizontal_center_lower, true };
    }

    [Theory]
    [MemberData(nameof(LineOverlapsTestData))]
    public void LineOverlapsTest(Line first, Line second, bool result)
    {
        var calculated_result_normal = _sut.LineOverlaps(first, second);
        Assert.Equal(result, calculated_result_normal);

        var calculated_result_reversed = _sut.LineOverlaps(second, first);
        Assert.Equal(result, calculated_result_reversed);
    }

    [Theory]
    [InlineData(8, 20, false)] // left of line
    [InlineData(22, 20, false)] // right of line
    [InlineData(10, 20, true)] // on line start
    [InlineData(20, 20, true)] // on line end
    [InlineData(15, 20, true)] // on middle of line
    [InlineData(15, 21, false)] // middle of line but above
    [InlineData(15, 19, false)] // middle of line but below
    public void IsPointContainedInLineTest(int x, int y, bool result)
    {
        var calculated_result = _sut.IsPointContainedIn(TestData.Horizontal_left, new Point(x, y));
        Assert.Equal(result, calculated_result);
    }

    [Theory]
    [InlineData(8, 15, false)] // left of rect
    [InlineData(22, 15, false)] // above rect
    [InlineData(15, 22, false)] // right of rect
    [InlineData(15, 8, false)] // below rect
    [InlineData(10, 15, false)] // on rect boundary
    [InlineData(15, 15, true)] // inside rect
    public void IsPointContainedInRectangleTest(int x, int y, bool result)
    {
        var testRect = new Rectangle(new Point(10, 20), new Point(20, 10));
        var calculated_result = _sut.IsPointContainedIn(testRect, new Point(x, y));
        Assert.Equal(result, calculated_result);
    }

    [Theory]
    [InlineData(10, 20, 20, 10, 12, 18, 18, 12, true)] // Contained
    [InlineData(10, 20, 20, 10, 12, 22, 18, 8, false)] // Just overlapping
    [InlineData(10, 20, 20, 10, 12, 30, 18, 25, false)] // Outside
    public void IsInsideTest(int rect1_x1, int rect1_y1, int rect1_x2, int rect1_y2, int rect2_x1, int rect2_y1, int rect2_x2, int rect2_y2, bool result)
    {
        var rect1 = new Rectangle(new Point(rect1_x1, rect1_y1), new Point(rect1_x2, rect1_y2));
        var rect2 = new Rectangle(new Point(rect2_x1, rect2_y1), new Point(rect2_x2, rect2_y2));

        var calculated_result = _sut.IsInside(rect1, rect2);
        Assert.Equal(result, calculated_result);
    }

    [Theory]
    [InlineData(10, 20, 20, 10, 12, 22, 18, 12, true)] // Intersecting
    [InlineData(10, 20, 20, 10, 12, 30, 22, 25, false)] // Not intersecting
    public void AreIntersectingTest(int rect1_x1, int rect1_y1, int rect1_x2, int rect1_y2, int rect2_x1, int rect2_y1, int rect2_x2, int rect2_y2, bool result)
    {
        var rect1 = new Rectangle(new Point(rect1_x1, rect1_y1), new Point(rect1_x2, rect1_y2));
        var rect2 = new Rectangle(new Point(rect2_x1, rect2_y1), new Point(rect2_x2, rect2_y2));

        var calculated_result = _sut.AreIntersecting(rect1, rect2);
        Assert.Equal(result, calculated_result);
    }

    [Theory]
    [InlineData(10, 20, 20, 10, 12, 18, 18, 12, ShapeRelationshipType.Containment)] // Contained
    [InlineData(10, 20, 20, 10, 5, 15, 10, 10, ShapeRelationshipType.Adjacency)] // Adjacent
    [InlineData(10, 20, 20, 10, 12, 22, 18, 12, ShapeRelationshipType.Intersection)] // Intersection
    [InlineData(10, 20, 20, 10, 12, 30, 22, 25, ShapeRelationshipType.None)] // None
    public void FindRelationshipTest(int rect1_x1, int rect1_y1, int rect1_x2, int rect1_y2, int rect2_x1, int rect2_y1, int rect2_x2, int rect2_y2, ShapeRelationshipType result)
    {
        var rect1 = new Rectangle(new Point(rect1_x1, rect1_y1), new Point(rect1_x2, rect1_y2));
        var rect2 = new Rectangle(new Point(rect2_x1, rect2_y1), new Point(rect2_x2, rect2_y2));

        var calculated_result = _sut.FindRelationship(rect1, rect2);
        Assert.Equal(result, calculated_result);
    }


}
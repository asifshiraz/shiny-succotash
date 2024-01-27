using Rectangles.Models;

namespace Rectangles.Services;

public class ShapesAnalyzer : IShapeAnalyzer
{
    /// <summary>
    /// Finds nature of relationship between two rectangles
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public ShapeRelationshipType FindRelationship(Rectangle first, Rectangle second)
    {
        if (IsInside(first, second) || IsInside(second, first))
            return ShapeRelationshipType.Containment;
        else if (AreAdjacent(first, second))
            return ShapeRelationshipType.Adjacency;
        else if (AreIntersecting(first, second))
            return ShapeRelationshipType.Intersection;
        return ShapeRelationshipType.None;
    }

    /// <summary>
    /// Determines if one rectangle is contained inside the other
    /// </summary>
    /// <param name="outer"></param>
    /// <param name="inner"></param>
    /// <returns></returns>
    public bool IsInside(Rectangle outer, Rectangle inner)
    {
        return inner.LeftX >= outer.LeftX &&
               inner.TopY <= outer.TopY &&
               inner.RightX <= outer.RightX &&
               inner.BottomY >= outer.BottomY;
    }

    /// <summary>
    /// Determines if two rectangles are adjacent, by checking if any of their sides overlap
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool AreAdjacent(Rectangle first, Rectangle second)
    {
        bool adjacent = false;
        if (!adjacent)
            adjacent = first.TopY == second.BottomY && LineOverlaps(first.TopLine, second.BottomLine);
        if (!adjacent)
            adjacent = first.BottomY == second.TopY && LineOverlaps(first.BottomLine, second.TopLine);
        if (!adjacent)
            adjacent = first.RightX == second.LeftX && LineOverlaps(first.RightLine, second.LeftLine);
        if (!adjacent)
            adjacent = first.LeftX == second.RightX && LineOverlaps(first.LeftLine, second.RightLine);
        return adjacent;
    }

    /// <summary>
    /// Determines if two lines overlap
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool LineOverlaps(Line first, Line second)
    {
        // Check if the projections onto the x-axis overlap
        bool xOverlap = Math.Max(first.Start.X, first.End.X) >= Math.Min(second.Start.X, second.End.X) &&
                        Math.Min(first.Start.X, first.End.X) <= Math.Max(second.Start.X, second.End.X);

        // Check if the projections onto the y-axis overlap
        bool yOverlap = Math.Max(first.Start.Y, first.End.Y) >= Math.Min(second.Start.Y, second.End.Y) &&
                        Math.Min(first.Start.Y, first.End.Y) <= Math.Max(second.Start.Y, second.End.Y);

        // If both x and y projections overlap, the lines overlap
        return xOverlap && yOverlap;
        
    }

    /// <summary>
    /// Determines if a point is inside another line
    /// Note: This was not required after development, but didn't delete it, which it normally would be in regular code
    /// </summary>
    /// <param name="line"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    public bool IsPointContainedIn(Line line, Point point)
    {
        int minX = Math.Min(line.Start.X, line.End.X);
        int maxX = Math.Max(line.Start.X, line.End.X);
        int minY = Math.Min(line.Start.Y, line.End.Y);
        int maxY = Math.Max(line.Start.Y, line.End.Y);

        return point.X >= minX && point.X <= maxX && point.Y >= minY && point.Y <= maxY;
    }

    /// <summary>
    /// Determines if a point is inside a rectangle
    /// </summary>
    /// <param name="rectangle"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    public bool IsPointContainedIn(Rectangle rectangle, Point point) 
    {
        return point.X > rectangle.LeftX &&
               point.X < rectangle.RightX &&
               point.Y > rectangle.BottomY &&
               point.Y < rectangle.TopY;
    }

    /// <summary>
    /// Determines if the two rectangles intersect with each other
    /// Intersection implied by any corner point of a rectangle being inside the other
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool AreIntersecting(Rectangle first, Rectangle second)
    {
        var intersecting = false;

        intersecting = IsPointContainedIn(first, second.TopLeft);
        if (intersecting) return true;

        intersecting = IsPointContainedIn(first, second.BottomLeft);
        if (intersecting) return true;

        intersecting = IsPointContainedIn(first, second.BottomRight);
        if (intersecting) return true;

        intersecting = IsPointContainedIn(first, second.TopRight);
        if (intersecting) return true;

        intersecting = IsPointContainedIn(second, first.TopLeft);
        if (intersecting) return true;

        intersecting = IsPointContainedIn(second, first.BottomLeft);
        if (intersecting) return true;

        intersecting = IsPointContainedIn(second, first.BottomRight);
        if (intersecting) return true;

        intersecting = IsPointContainedIn(second, first.TopRight);
        if (intersecting) return true;

        return false;
    }


}

using Rectangles.Models;

namespace Rectangles.Services;

public interface IShapeAnalyzer
{
    ShapeRelationshipType FindRelationship(Rectangle first, Rectangle second);
}

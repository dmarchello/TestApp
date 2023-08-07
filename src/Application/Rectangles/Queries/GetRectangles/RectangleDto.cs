using TestApp.Application.Common.Mappings;
using TestApp.Domain.Entities;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public class RectangleDto : IMapFrom<Rectangle>
{
    public int Id { get; init; }

    public CoordinateDto TopLeft { get; init; }

    public CoordinateDto BottomRight { get; init; }
}
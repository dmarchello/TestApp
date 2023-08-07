using TestApp.Application.Common.Mappings;
using TestApp.Domain.Entities;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public class CoordinateDto : IMapFrom<Coordinate>
{
    public int X { get; init; }
    public int Y { get; init; }
}
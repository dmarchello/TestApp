using MediatR;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public record GetRectanglesByCoordinateQuery : IRequest<List<RectangleDto>>
{
    public int X { get; set; }
    public int Y { get; set; }
}
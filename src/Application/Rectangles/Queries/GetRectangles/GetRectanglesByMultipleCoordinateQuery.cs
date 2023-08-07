using MediatR;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public record GetRectanglesByMultipleCoordinateQuery : IRequest<List<RectangleVm>>
{
    public List<CoordinateDto> Coordinates { get; init; } = new();
}
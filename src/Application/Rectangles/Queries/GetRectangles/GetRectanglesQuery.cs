using MediatR;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public class GetRectanglesQuery : IRequest<List<RectangleDto>>
{
}
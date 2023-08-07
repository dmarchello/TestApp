using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Application.Common.Interfaces;
using TestApp.Application.Common.Mappings;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public class RectangleQueriesHandlers : 
    IRequestHandler<GetRectanglesByCoordinateQuery, List<RectangleDto>>,
    IRequestHandler<GetRectanglesQuery, List<RectangleDto>>,
    IRequestHandler<GetRectanglesByMultipleCoordinateQuery, List<RectangleVm>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public RectangleQueriesHandlers(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RectangleDto>> Handle(GetRectanglesByCoordinateQuery request, CancellationToken cancellationToken)
    {
        return await FindRectangles(request.X, request.Y, cancellationToken);
    }
    
    public Task<List<RectangleVm>> Handle(GetRectanglesByMultipleCoordinateQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Coordinates.Select(x=> new RectangleVm
        {
            Point = x,
            Rectangles = FindRectangles(x.X, x.Y, cancellationToken).Result
        }).ToList());
    }

    public async Task<List<RectangleDto>> Handle(GetRectanglesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rectangles
            .ProjectToListAsync<RectangleDto>(_mapper.ConfigurationProvider);
    }

    private Task<List<RectangleDto>> FindRectangles(int coordinateX, int coordinateY, CancellationToken cancellationToken)
    {
        return _context.Rectangles
            .Include(x => x.BottomRight)
            .Include(x => x.TopLeft)
            .Where(rectangle => coordinateX >= rectangle.TopLeft.X &&
                                coordinateX <= rectangle.BottomRight.X &&
                                coordinateY <= rectangle.TopLeft.Y &&
                                coordinateY >= rectangle.BottomRight.Y)
            .ProjectToListAsync<RectangleDto>(_mapper.ConfigurationProvider);
    }
}
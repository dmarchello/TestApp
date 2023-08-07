using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Rectangles.Queries.GetRectangles;

namespace API.Controllers;

public class RectanglesController : ApiControllerBase
{
    [HttpGet("by-coordinate")]
    public async Task<ActionResult<List<RectangleDto>>> GetRectanglesByCoordinate([FromQuery] GetRectanglesByCoordinateQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpGet("by-coordinates")]
    public async Task<ActionResult<List<RectangleVm>>> GetRectanglesByCoordinate([FromQuery] GetRectanglesByMultipleCoordinateQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<List<RectangleDto>>> GetRectangles([FromQuery] GetRectanglesQuery query)
    {
        return await Mediator.Send(query);
    }
}

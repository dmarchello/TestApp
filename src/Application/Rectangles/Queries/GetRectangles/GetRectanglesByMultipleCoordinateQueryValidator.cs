using FluentValidation;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public class GetRectanglesByMultipleCoordinateQueryValidator : AbstractValidator<GetRectanglesByMultipleCoordinateQuery>
{
    public GetRectanglesByMultipleCoordinateQueryValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Coordinates)
            .NotEmpty()
            .WithMessage("Coordinates are required.");
    }
}

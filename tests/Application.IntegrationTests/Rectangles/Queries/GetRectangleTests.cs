using FluentAssertions;
using NUnit.Framework;
using TestApp.Application.Common.Exceptions;
using TestApp.Application.Rectangles.Queries.GetRectangles;
using TestApp.Domain.Entities;

namespace TestApp.Application.IntegrationTests.Rectangles.Queries;

using static Testing;

public class GetRectangleTests : BaseTestFixture
{
    [Test]
    public Task ShouldRequireMinimumFields()
    {
        CountAsync<Rectangle>().Result.Should().Be(200);
        
        return Task.CompletedTask;
    }

    [Test]
    public async Task ShouldThrowValidationExceptionWhenCoordinatesNotSet()
    {
        GetRectanglesByCoordinateQuery query = new GetRectanglesByCoordinateQuery();

        await FluentActions.Invoking(() =>
            SendAsync(query)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldThrowValidationExceptionWhenCoordinatesAreDefault()
    {
        GetRectanglesByCoordinateQuery query = new()
        {
            Coordinate = new CoordinateDto { X = 0, Y = 0 }
        };

        await FluentActions.Invoking(() =>
            SendAsync(query)).Should().ThrowAsync<ValidationException>();
    }
}
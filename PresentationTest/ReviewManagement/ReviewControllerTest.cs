using Domain.Review.Model.Commands;
using Domain.Review.Model.Entities;
using Domain.Review.Model.Queries;
using Domain.Review.Repositories;
using Domain.Review.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Review.Controllers;
using Presentation.Review.Resources;

namespace PresentationTest.ReviewManagement;

public class ReviewManagementTest
{
    
    [Fact]
    public async Task GetReviews()
    {
        var reviewCommandService = new Mock<IReviewCommandService>();
        var reviewQueryService = new Mock<IReviewQueryService>();
        var query = new GetAllReviewsQuery();
        var reviews = reviewQueryService.Object.Handle(query).Result;
        var reviewEntities = reviews as ReviewEntity[] ?? reviews.ToArray();
        reviewQueryService.Setup(x => x.Handle(query)).ReturnsAsync(reviewEntities);
        var controller = new ReviewController(reviewQueryService.Object, reviewCommandService.Object);
        var result = await controller.GetAllScooters() as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
    
    
    [Fact]
    public async Task CreateReview()
    {
        var reviewCommandService = new Mock<IReviewCommandService>();
        var reviewQueryService = new Mock<IReviewQueryService>();
        var controller = new ReviewController(reviewQueryService.Object, reviewCommandService.Object);
        var result = await controller.CreateScooter(new CreateReviewResource(
            "Test",
            5
        )) as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }
    
}
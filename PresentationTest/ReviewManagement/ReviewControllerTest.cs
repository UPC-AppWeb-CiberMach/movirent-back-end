using Domain.Review.Model.Entities;
using Domain.Review.Model.Queries;
using Domain.Review.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Review.Controllers;
using Presentation.Review.Resources;

namespace PresentationTest.ReviewManagement;

public class ReviewManagementTest
{
    
    [Fact]
    public async Task Get_ReviewsTest()
    {
        var reviewCommandService = new Mock<IReviewCommandService>();
        var reviewQueryService = new Mock<IReviewQueryService>();
        var query = new GetAllReviewsQuery();
        var reviews = reviewQueryService.Object.Handle(query).Result;
        var reviewEntities = reviews as ReviewEntity[] ?? reviews.ToArray();
        reviewQueryService.Setup(x => x.Handle(query)).ReturnsAsync(reviewEntities);
        var controller = new ReviewController(reviewQueryService.Object, reviewCommandService.Object);
        var result = await controller.GetAllScooters() as ObjectResult;
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 200
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
    
    
    [Fact]
    public async Task Post_CreateReviewTest()
    {
        var reviewCommandService = new Mock<IReviewCommandService>();
        var reviewQueryService = new Mock<IReviewQueryService>();
        var controller = new ReviewController(reviewQueryService.Object, reviewCommandService.Object);
        var result = await controller.CreateScooter(new CreateReviewResource(
            "Es un buen scooter",
            5
        )) as ObjectResult;
        
        // Esperamos que el resultado no sea nulo y que el código de estado sea 201
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }
}
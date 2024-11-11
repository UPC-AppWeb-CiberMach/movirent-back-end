using System.Net.Mime;
using Domain.Review.Model.Queries;
using Domain.Review.Services;
using Domain.Review.Model.Commands;
using Microsoft.AspNetCore.Mvc;
using Presentation.Review.Resources;
using Presentation.Review.Transform;

namespace Presentation.Review.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ReviewController (IReviewQueryService reviewQueryService, 
    IReviewCommandService reviewCommandService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllScooters()
    {
        var query = new GetAllReviewsQuery();
        var reviews = await reviewQueryService.Handle(query);
        var reviewsResource = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return StatusCode(200, reviewsResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateScooter([FromBody] CreateReviewResource reviewResource)
    {
        var command = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(reviewResource);
        var reviewId = await reviewCommandService.Handle(command);
        return StatusCode(201, reviewId);
    }
}
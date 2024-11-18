using System.Net.Mime;
using Domain.ReviewManagement.Model.Queries;
using Domain.ReviewManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Review.Resources;
using Presentation.Review.Transform;
using Presentation.ReviewManagement.Resources;
using Presentation.ReviewManagement.Transform;

namespace Presentation.ReviewManagement.Controllers;
/// <summary>
/// Controlador de reseñas
/// </summary>
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
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid review data.");
        }

        try
        {
            var command = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(reviewResource);
            var reviewId = await reviewCommandService.Handle(command);
            return StatusCode(201, reviewId);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while creating the review.");
        }
    }
}
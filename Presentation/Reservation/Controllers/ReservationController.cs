using Domain.Reservation.Model.Commands;
using Domain.Reservation.Model.Entities;
using Domain.Reservation.Model.Queries;
using Domain.Reservation.Services;
using Presentation.Reservation.Resources;
using Presentation.Reservation.Transform;

namespace Presentation.Reservation.Controllers;
using Microsoft.AspNetCore.Mvc;


[Route("api/v1/[controller]")]
[ApiController]
public class ReservationController(
    IReservationQueryService reservationQueryService,
    IReservationCommandService reservationCommandService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReservationEntity>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var query = new GetAllReservationsQuery();
            var reservations = await reservationQueryService.Handle(query);
            if (reservations == null || !reservations.Any())
            {
                return NotFound();
            }

            var resources = reservations
                .Select(ReservationResourceFromEntityAssembler.ToResourceFromEntity)
                .ToList();
            return Ok(resources);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ReservationEntity), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetReservationByIdQuery(id);
        var reservation = await reservationQueryService.Handle(query);
        if (reservation == null)
            return NotFound();
        var resource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
        return Ok(resource);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateReservationResource createReservationResource)
    {
        if (!ModelState.IsValid) return BadRequest("Invalid resource data.");
        var command = CreateReservationCommandFromResourceAssembler.ToCommandFromResource(createReservationResource);
        var result = await reservationCommandService.Handle(command);

        return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateReservationResource updateReservationResource)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid resource data.");
        var command =
            UpdateReservationCommandFromResourceAssembler.ToCommandFromResource(id, updateReservationResource);
        var result = await reservationCommandService.Handle(command);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new CancelReservationCommand(id);
        var result = await reservationCommandService.Handle(command);
        return result ? NoContent() : NotFound();
    }
    
}
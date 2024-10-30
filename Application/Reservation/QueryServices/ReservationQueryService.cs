using Domain.Reservation.Model.Entities;
using Domain.Reservation.Model.Queries;
using Domain.Reservation.Repositories;
using Domain.Reservation.Services;

namespace Application.Reservation.QueryServices;

public class ReservationQueryService : IReservationQueryService
{
    private readonly IReservationRepository _repository;

    public ReservationQueryService(IReservationRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<ReservationEntity>?> Handle(GetAllReservationsQuery query)
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ReservationEntity?> Handle(GetReservationByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}
using Domain.Reservation.Model.Entities;
using Domain.Reservation.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Reservation;

public class ReservationRepository(AppDbContext context) : BaseRepository<ReservationEntity>(context), IReservationRepository
{
    public async Task<ReservationEntity?> CheckScooterAvailableAsync(int id)
    {
        return await context.Reservations.Where(r => r.ScooterId == id).FirstOrDefaultAsync();
    }
    public async Task<ReservationEntity?> CheckUserActiveReservationAsync(int id)
    {
        return await context.Reservations.Where(r => r.UserId == id).FirstOrDefaultAsync();
    }
    
}
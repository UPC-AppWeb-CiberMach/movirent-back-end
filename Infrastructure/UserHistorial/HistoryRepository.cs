using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserHistorial;

public class HistoryRepository(AppDbContext context) : BaseRepository<HistoryEntity>(context), IHistoryRepository
{
    private readonly AppDbContext _context = context;

    public async Task<bool> ExistByClientIdAsync(Guid clientId)
    {
        return await _context.Users.AnyAsync(e => e.Id == clientId);
    }

    public async Task<bool> ExistByScooterIdAsync(Guid scooterId)
    {
        return await _context.Scooters.AnyAsync(e => e.Id == scooterId);
    }
}
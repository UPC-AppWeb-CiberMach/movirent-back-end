using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserHistorial;
/// <summary>
/// Repositorio de historiales
/// </summary>
public class HistorialRepository(AppDbContext context) : BaseRepository<HistorialEntity>(context), IHistorialRepository
{
    public async Task<HistorialEntity?> CheckScooterAvailableAsync(int id)
    {
        return await context.Historials.Where(r => r.ScooterId == id).FirstOrDefaultAsync();
    }
    public async Task<HistorialEntity?> CheckUserActiveHistorialAsync(int id)
    {
        return await context.Historials.Where(r => r.UserId == id).FirstOrDefaultAsync();
    }
    
}
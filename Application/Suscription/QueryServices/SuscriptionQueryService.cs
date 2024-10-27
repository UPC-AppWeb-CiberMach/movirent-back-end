using Domain.Suscription.Model.Entities;
using Domain.Suscription.Model.Queries;
using Domain.Suscription.Repositories;
using Domain.Suscription.Services;

namespace Application.Suscription.QueryServices;

public class SuscriptionQueryService : ISuscriptionQueryService
{
    private readonly ISuscriptionRepository _suscriptionRepository;

    public SuscriptionQueryService(ISuscriptionRepository suscriptionRepository)
    {
        _suscriptionRepository = suscriptionRepository;
    }

    public async Task<SuscriptionEntity?> Handle(GetSuscriptionByIdQuery query)
    {
        return await _suscriptionRepository.GetByIdAsync(query.Id);
    }
    public async Task<IEnumerable<SuscriptionEntity>> Handle(GetAllSuscriptionsQuery query)
    {
        return await _suscriptionRepository.GetAllAsync();
    }
}
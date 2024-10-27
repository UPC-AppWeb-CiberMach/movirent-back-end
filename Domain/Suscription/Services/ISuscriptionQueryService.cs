using Domain.Suscription.Model.Entities;
using Domain.Suscription.Model.Queries;

namespace Domain.Suscription.Services;

public interface ISuscriptionQueryService
{
    Task<IEnumerable<SuscriptionEntity>> Handle(GetAllSuscriptionsQuery query);
    Task<SuscriptionEntity?> Handle(GetSuscriptionByIdQuery query);

}
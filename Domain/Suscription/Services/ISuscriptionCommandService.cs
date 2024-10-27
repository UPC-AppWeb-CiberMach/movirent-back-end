using Domain.Suscription.Model.Commands;
using Domain.Suscription.Model.Commands;

namespace Domain.Suscription.Services;

public interface ISuscriptionCommandService
{
    Task<int> Handle(CreateSuscriptionCommand command);
}
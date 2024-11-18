using Domain.Subscription.Model.Commands;
using Domain.Subscription.Model.Entities;
using Domain.Subscription.Repositories;
using Domain.Subscription.Services;
using Domain.Shared;

namespace Application.Subscription.CommandServices;


/// <summary>
/// Servicio de comandos de suscripciones
/// </summary>
public class SubscriptionCommandService : ISubscriptionCommandService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
    {
        _subscriptionRepository = subscriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSubscriptionCommand command)
    {
        // Validaciones adicionales antes de crear la suscripción
        if (string.IsNullOrWhiteSpace(command.Name) || command.Name.Length > 50)
        {
            throw new ArgumentException("El nombre de la suscripción no puede estar vacío y debe tener menos de 50 caracteres.");
        }

        if (command.Stars < 1 || command.Stars > 5)
        {
            throw new ArgumentException("La cantidad de estrellas debe estar entre 1 y 5.");
        }

        if (command.Price <= 0)
        {
            throw new ArgumentException("El precio de la suscripción debe ser mayor a 0.");
        }

        var subscription = new SubscriptionEntity(command);

        await _subscriptionRepository.AddAsync(subscription);
        await _unitOfWork.CompleteAsync();
        return subscription.Id;
    }
    
}
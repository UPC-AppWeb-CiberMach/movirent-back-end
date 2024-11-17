using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Domain.IAM.Services;
using Domain.Shared;

namespace Application.IAM.CommandServices;

/// <summary>
/// Servicio de comandos de usuario
/// </summary>
public class UserCommandService : IUserCommandService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserCommandService(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<int> Handle(CreateUserCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.email) || string.IsNullOrWhiteSpace(command.password) ||
            string.IsNullOrWhiteSpace(command.completeName) || string.IsNullOrWhiteSpace(command.phone) ||
            string.IsNullOrWhiteSpace(command.dni) || string.IsNullOrWhiteSpace(command.address))
        {
            throw new ArgumentException("Todos los campos son obligatorios.");
        }
        
        if (command.password.Length < 8)
        {
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
        }

        var user = new UserProfile(command);
        
        await _usersRepository.AddAsync(user);
        await _unitOfWork.CompleteAsync();
        return user.id; 
    }
    
    public async Task<bool> Handle(UpdateUserCommand command)
    {
        var user = await _usersRepository.GetByIdAsync(command.id);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.UpdateUserInfo(command);
        _usersRepository.Update(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }
    
    public async Task<bool> Handle(DeleteUserCommand command)
    {
        var user = await _usersRepository.GetByIdAsync(command.id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        _usersRepository.Delete(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
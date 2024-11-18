using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Domain.IAM.Services;
using Domain.Shared;

namespace Application.IAM.CommandServices;

/// <summary>
/// Servicio de consultas de usuario
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
    
    public async Task<Guid> Handle(CreateUserCommand command)
    {
        // ----- No se puede crear un usuario con un email que ya existe -----
        var existingUserByEmail = await _usersRepository.GetByEmailAsync(command.email);
        if (existingUserByEmail != null)
        {
            throw new Exception("El correo registrado ya existe");
        }

        // ----- No se puede crear un usuario con un DNI que ya existe -----
        var existingUserByDni = await _usersRepository.GetByDniAsync(command.dni);
        if (existingUserByDni != null)
        {
            throw new Exception("El DNI registrado ya existe");
        }

        // ----- No se puede crear un usuario con un teléfono que ya existe -----
        var existingUserByPhone = await _usersRepository.GetByPhoneAsync(command.phone);
        if (existingUserByPhone != null)
        {
            throw new Exception("El teléfono registrado ya existe");
        }
        var user = new UserProfile(command);
        await _usersRepository.AddAsync(user);
        await _unitOfWork.CompleteAsync();
    
        return user.Id; 
    }
    
    public async Task<bool> Handle(UpdateUserCommand command)
    {
        var user = await _usersRepository.GetByIdAsync(command.id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        _usersRepository.Update(user);
        user.UpdateUserInfo(command);
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
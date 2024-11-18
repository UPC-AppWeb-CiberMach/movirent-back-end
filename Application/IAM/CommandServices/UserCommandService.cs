using System.Data;
using System.Runtime.CompilerServices;
using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Domain.IAM.Services;
using Domain.Shared;

namespace Application.IAM.CommandServices;

public class UserCommandService(
    IUsersRepository usersRepository,
    IUnitOfWork unitOfWork,
    IEncryptService encryptService,
    ITokenService tokenService) : IUserCommandService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<(UserProfile userProfile, string token)> Handle(SignInCommand command)
    {
        var existingUser = await usersRepository.GetByEmailAsync(command.email);
        if (existingUser == null)
            throw new DataException("Invalid email or password");
        
        var isValidPassword = encryptService.Verify(command.Password, existingUser.Password);
        if(!isValidPassword)
            throw new DataException("Invalid email or password");
        
        var token = tokenService.GenerateToken(existingUser);

        return (existingUser, token);
    }
    
    public async Task Handle(SingUpCommand command)
    {
        var existingUserByEmail = await _usersRepository.GetByEmailAsync(command.email);
        if (existingUserByEmail != null)
            throw new DataException("Email already in use");

        var existingUserByDni = await _usersRepository.GetByDniAsync(command.dni);
        if (existingUserByDni != null)
            throw new DataException("DNI already in use");

        var existingUserByPhone = await _usersRepository.GetByPhoneAsync(command.phone);
        if (existingUserByPhone != null)
            throw new DataException("Phone number already in use");

        
        var user = new UserProfile
        {
            Email = command.email,
            Password = encryptService.Encrypt(command.password),
            CompleteName = command.completeName,
            Phone = command.phone,
            Dni = command.dni,
            Photo = command.photo,
            Address = command.address,
            Rol = command.rol
        };
        
        await usersRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
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
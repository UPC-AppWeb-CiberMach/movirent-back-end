using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Entities;
using Domain.IAM.Repositories;
using Domain.IAM.Services;
using Domain.Shared;

namespace Application.IAM.CommandServices;

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
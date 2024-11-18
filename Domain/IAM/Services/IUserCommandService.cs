using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Entities;

namespace Domain.IAM.Services;

public interface IUserCommandService
{
    Task<(UserProfile userProfile, string token)> Handle(SignInCommand command);
    Task Handle(SingUpCommand command);
    Task<bool> Handle(UpdateUserCommand command);
    Task<bool> Handle(DeleteUserCommand command);
}
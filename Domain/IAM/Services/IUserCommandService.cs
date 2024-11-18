using Domain.IAM.Model.Commands;

namespace Domain.IAM.Services;

public interface IUserCommandService
{
    Task<Guid> Handle(CreateUserCommand command);
    Task<bool> Handle(UpdateUserCommand command);
    Task<bool> Handle(DeleteUserCommand command);
}
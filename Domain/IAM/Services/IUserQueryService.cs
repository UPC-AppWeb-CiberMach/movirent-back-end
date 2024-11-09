using Domain.IAM.Model.Entities;
using Domain.IAM.Model.Queries;

namespace Domain.IAM.Services;

public interface IUserQueryService
{
    Task<IEnumerable<UserProfile>> Handle(GetAllUsersQuery query);
    Task<UserProfile?> Handle(GetUsersByIdQuery query);
}
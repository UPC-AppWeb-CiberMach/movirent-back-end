using Application.IAM.QueryServices;
using Domain.IAM.Model.Queries;
using Domain.IAM.Repositories;
using Moq;

namespace ApplicationTest.IAM;

public class UserQueryServiceTest
{
    [Fact]
    public void GetAllUsersTest()
    {
        var usersRepository = new Mock<IUsersRepository>();
        var userQueryService = new UserQueryService(usersRepository.Object);
        var query = new GetAllUsersQuery();
        
        var result = userQueryService.Handle(query);
        
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetUserByIdTest()
    {
        var usersRepository = new Mock<IUsersRepository>();
        var userQueryService = new UserQueryService(usersRepository.Object);
        var query = new GetUsersByIdQuery(1);
        
        var result = userQueryService.Handle(query);
        
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetUserByIdTest2()
    {
        var usersRepository = new Mock<IUsersRepository>();
        var userQueryService = new UserQueryService(usersRepository.Object);
        var query = new GetUsersByIdQuery(1);
        
        var result = userQueryService.Handle(query);
        
        Assert.NotNull(result);
    }
}
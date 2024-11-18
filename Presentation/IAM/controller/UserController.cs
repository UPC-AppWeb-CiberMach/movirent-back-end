using System.Net.Mime;
using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Queries;
using Domain.IAM.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.IAM.Resources;
using Presentation.IAM.Transform;

namespace Presentation.IAM.controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController (IUserQueryService userQueryService, 
        IUserCommandService userCommandService): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await userQueryService.Handle(query);
            var usersResource = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
            return StatusCode(200, usersResource);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserResource userResource)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid data");
            }
            var command = CreateUserCommandFromResourceAssembler.ToCommandFromResource(userResource);
            var userId = await userCommandService.Handle(command);
            return StatusCode(201, userId);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUsersByIdQuery(id);
            var user = await userQueryService.Handle(query);
            var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
            if (userResource == null)
            {
                return StatusCode(404, "User not found");
            }
            return StatusCode(200, userResource);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserResource userResource)
        {
            var command = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(id, userResource);
            await userCommandService.Handle(command);
            return StatusCode(200, "User updated");
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            await userCommandService.Handle(command);
            return StatusCode(200,"User deleted");
        }
    }
}
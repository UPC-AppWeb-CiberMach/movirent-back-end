using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using Domain.IAM.Model.Commands;
using Domain.IAM.Model.Queries;
using Domain.IAM.Repositories;
using Domain.IAM.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.IAM.Resources;
using Presentation.IAM.Transform;

namespace Presentation.IAM.controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserCommandService _userCommandService;
        private readonly IUsersRepository _usersRepository;

        public UserController(IUserQueryService userQueryService, IUserCommandService userCommandService, IUsersRepository usersRepository)
        {
            _userQueryService = userQueryService;
            _userCommandService = userCommandService;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _userQueryService.Handle(query);
            var usersResource = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
            return StatusCode(200, usersResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid data");
            }
            var command = CreateUserCommandFromResourceAssembler.ToCommandFromResource(userResource);
            var userId = await _userCommandService.Handle(command);
            return StatusCode(201, userId);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUsersByIdQuery(id);
            var user = await _userQueryService.Handle(query);
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
            await _userCommandService.Handle(command);
            return StatusCode(200, "User updated");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            await _userCommandService.Handle(command);
            return StatusCode(200, "User deleted");
        }

        [HttpGet("signin")]
        public async Task<IActionResult> SignIn([FromQuery] string email, [FromQuery] string password)
        {
            var user = await _usersRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return StatusCode(404, "User not found");
            }

            if (VerifyPassword(password, user.Password))
            {
                return StatusCode(200, "Sign in successful");
            }
            else
            {
                return StatusCode(401, "Invalid password");
            }
        }

        private bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
                var hashedInputPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedInputPassword == hashedPassword;
            }
        }
    }
}
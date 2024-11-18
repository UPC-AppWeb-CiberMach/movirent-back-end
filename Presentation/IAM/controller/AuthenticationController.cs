using Domain.IAM.Model.Commands;
using Domain.IAM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.IAM.Resources;
using Presentation.IAM.Transform;

namespace Presentation.IAM.controller;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="signUpResource">The user's registration data.</param>
    /// <returns>An action result indicating if the registration was successful.</returns>
    [HttpPost("register")]       
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUserResource signUpResource)
    {
        var command = CreateUserCommandFromResourceAssembler.ToCommandFromResource(signUpResource);

        await userCommandService.Handle(command);

        return StatusCode(201, command);
    }

    /// <summary>
    /// Logs in an existing user.
    /// </summary>
    /// <param name="signInResource">The user's login data.</param>
    /// <returns>A message indicating if the login was successful.</returns>
    [HttpPost("login")]
    [Produces("application/json")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] SingInResource resource)
    {
        var commad = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
            
        var response =   await userCommandService.Handle(commad);
            
        return Ok(new { message = "User created successfully",token = response.token , userId = response.userProfile.Id });
    }
}
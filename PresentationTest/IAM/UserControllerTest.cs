using Moq;
using Microsoft.AspNetCore.Mvc;
using Domain.IAM.Services;
using Domain.IAM.Model.Queries;
using Domain.IAM.Model.Commands;
using Presentation.IAM.controller;
using Presentation.IAM.Resources;
using Domain.IAM.Model.Entities;

public class UserControllerTests
    {
        private readonly Mock<IUserQueryService> _mockUserQueryService;
        private readonly Mock<IUserCommandService> _mockUserCommandService;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockUserQueryService = new Mock<IUserQueryService>();
            _mockUserCommandService = new Mock<IUserCommandService>();
            _controller = new UserController(_mockUserQueryService.Object, _mockUserCommandService.Object);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOkResult_WithUserList()
        {
            var users = new List<UserProfile> 
            {
                new UserProfile { Id = Guid.NewGuid(), Email = "velarde@gmail.com", CompleteName = "Nestor Velarde" },
                new UserProfile { Id = Guid.NewGuid(), Email = "teresita@gmail.com", CompleteName = "Tere Masias" }
            };
            _mockUserQueryService.Setup(s => s.Handle(It.IsAny<GetAllUsersQuery>())).ReturnsAsync(users);

            var result = await _controller.GetAllUsers();

            var okResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateUser_ReturnsCreatedResult_WithUserId()
        {
            var userResource = new CreateUserResource(
                "velarde@gmail.com",
                "password123",
                "Néstor Velarde",
                "123456789",
                "12345678",
                "photo_url",
                "123 Street Name"
            );

            var newUserId = Guid.NewGuid();
            _mockUserCommandService.Setup(s => s.Handle(It.IsAny<CreateUserCommand>())).ReturnsAsync(newUserId);

            var result = await _controller.CreateUser(userResource);

            var createdResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(newUserId, createdResult.Value);
        }

        [Fact]
        public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            _mockUserQueryService.Setup(s => s.Handle(It.IsAny<GetUsersByIdQuery>())).ReturnsAsync((UserProfile)null);
            
            var result = await _controller.GetUserById(1);
            
            var notFoundResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetUserById_ReturnsOkResult_WithUserResource()
        {
            var user = new UserProfile 
            { 
                Id = Guid.NewGuid(), 
                Email = "velarde.com", 
                CompleteName = "Velarde Néstor" 
            };
            _mockUserQueryService.Setup(s => s.Handle(It.IsAny<GetUsersByIdQuery>())).ReturnsAsync(user);

            var result = await _controller.GetUserById(1);

            var okResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(okResult.Value);
        }
    }
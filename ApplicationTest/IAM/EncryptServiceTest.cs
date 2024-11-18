using Xunit;
using Application.IAM.CommandServices;

public class EncryptServiceTest
{
    private readonly EncryptService _encryptService;

    public EncryptServiceTest()
    {
        _encryptService = new EncryptService();
    }

    [Fact]
    public void Encrypt_ShouldReturnHashedPassword()
    {
        // Arrange
        var password = "password123";

        // Act
        var hashedPassword = _encryptService.Encrypt(password);

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(hashedPassword)); // Asegúrate de que no sea vacío
        Assert.NotEqual(password, hashedPassword); // La contraseña encriptada debe ser diferente al texto original
    }

    [Fact]
    public void Verify_ShouldReturnTrue_ForCorrectPassword()
    {
        // Arrange
        var password = "password123";
        var hashedPassword = _encryptService.Encrypt(password);

        // Act
        var result = _encryptService.Verify(password, hashedPassword);

        // Assert
        Assert.True(result); // Verifica que la contraseña coincida
    }

    [Fact]
    public void Verify_ShouldReturnFalse_ForIncorrectPassword()
    {
        // Arrange
        var password = "password123";
        var hashedPassword = _encryptService.Encrypt(password);

        // Act
        var result = _encryptService.Verify("wrongPassword", hashedPassword);

        // Assert
        Assert.False(result); // Verifica que no coincida con una contraseña incorrecta
    }

    [Fact]
    public void Verify_ShouldWorkWithPreviouslyHashedPassword()
    {
        // Arrange
        var password = "password123";
        var hashedPassword = _encryptService.Encrypt(password); // Genera el hash dinámicamente

        // Act
        var result = _encryptService.Verify(password, hashedPassword);

        // Assert
        Assert.True(result); // Verifica que coincida con un hash válido
    }
}
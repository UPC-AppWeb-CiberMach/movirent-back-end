using Domain.IAM.Model.Entities;

namespace Domain.IAM.Services;

public interface IEncryptService
{
    public string Encrypt(string password);
    public bool Verify(string password, string passwordHashed);
}
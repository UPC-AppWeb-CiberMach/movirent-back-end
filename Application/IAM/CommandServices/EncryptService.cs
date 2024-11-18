﻿using Domain.IAM.Services;


namespace Application.IAM.CommandServices;

public class EncryptService : IEncryptService
{
    public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string passwordHashed)
    {
       return BCrypt.Net.BCrypt.Verify(password, passwordHashed);
    }
}
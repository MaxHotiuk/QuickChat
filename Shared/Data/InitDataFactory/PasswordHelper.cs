namespace QuickChat.Shared.Data.InitDataFactory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Helper class for hashing and verifying passwords using PBKDF2 with HMACSHA256.
/// </summary>
public static class PasswordHelper
{
    private static readonly byte[] Salt = Encoding.ASCII.GetBytes("StaticSalt");
    private const int KeySize = 32;
    private const int Iterations = 10000;

    /// <summary>
    /// Hashes a password using PBKDF2 with HMACSHA256.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password in a format containing iteration count, salt, and key.</returns>
    public static string HashPassword(string password)
    {
        using var algorithm = SHA256.Create();
        var derivedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
        var derivedKey = Convert.ToBase64String(derivedBytes);

        return $"{Iterations}.{Convert.ToBase64String(Salt)}.{derivedKey}";
    }

    /// <summary>
    /// Verifies if a password matches its hashed representation.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="hash">The hashed password to compare against.</param>
    /// <returns>True if the password matches the hash, otherwise false.</returns>
    public static bool VerifyPassword(string password, string hash)
    {
        return hash == HashPassword(password);
    }
}

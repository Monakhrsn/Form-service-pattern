using System.Security.Cryptography;
using System.Text;

namespace MainApp.Helpers;

public static class SecurePasswordGenerator
{
    private static readonly byte[] _key = Encoding.UTF8.GetBytes("ZW5zw6RrZXJueWNrZWw=");
    public static string Generate(string password)
    {
        using var hmac = new HMACSHA256(_key);
        var key = hmac.Key;
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        var encoded = Convert.ToBase64String(hash);
        return encoded;
    }

    public static bool Validate(string password, string expectedHashedPassword)
    {
        using var hmac = new HMACSHA256(_key);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        var encoded = Convert.ToBase64String(hash);
        return encoded == expectedHashedPassword;
    }
}
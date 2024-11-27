using System.Security.Cryptography;
using System.Text;

namespace MainApp.Helpers;

public static class SecurePasswordGenerator
{
    public static string Generate(string password)
    {
        using var hmac = new HMACSHA256();
        var key = hmac.Key;
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        var encoded = Convert.ToBase64String(hash);
        return encoded;
    }
}
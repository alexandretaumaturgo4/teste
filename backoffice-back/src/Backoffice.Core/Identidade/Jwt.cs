namespace Backoffice.Core;

public class Jwt
{
    public string Secret { get; set; }
    public int ExpirationInHours { get; set; }
    public string Issuer { get; set; }
}
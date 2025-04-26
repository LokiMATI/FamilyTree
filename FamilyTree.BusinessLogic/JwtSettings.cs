namespace FamilyTree.BusinessLogic;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public TimeSpan Expires { get; set; }

    public string Issuer { get; set; }

    public string Audience { get; set; }

    public JwtSettings(){}
    
    public JwtSettings(
        string secretKey,
        TimeSpan expires,
        string issuer,
        string audience)
    {
        SecretKey = secretKey;
        Expires = expires;
        Issuer = issuer;
        Audience = audience;
    }

}
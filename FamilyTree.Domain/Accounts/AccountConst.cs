namespace FamilyTree.Domain.Accounts;

/// <summary>
/// Константы для аккаунта.
/// </summary>
public class AccountConst
{
    /// <summary>
    /// Максимальная длина логина.
    /// </summary>
    public const byte MaxLoginLength = 16;

    /// <summary>
    /// Верификация написания логина.
    /// </summary>
    public const string LoginVerificationPattern = @"^[a-zA-Z0-9_\-.]{4,16}$";
}
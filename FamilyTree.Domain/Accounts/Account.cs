using System.Text.RegularExpressions;
using FamilyTree.Domain.Persons;

namespace FamilyTree.Domain.Accounts;

/// <summary>
/// Аккаунт.
/// </summary>
public class Account
{
    private readonly string _login;
    
    /// <summary>
    /// Создание на основании первичных данных.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="email">Электронная почта.</param>
    public Account(
        string login,
        string? email)
    {
        _login = login;
        Email = email;
    }

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Логин.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public string Login
    {
        get => _login;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException($"Value cannot be null or whitespace ", nameof(value));
            
            if (!Regex.IsMatch(value, AccountConst.LoginVerificationPattern))
                throw new ArgumentException($"Value is not a valid login verification pattern", nameof(value));
            
            _login = value;
        }
    }

    /// <summary>
    /// Хэш пароля.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public string? Email { get; set; }
}
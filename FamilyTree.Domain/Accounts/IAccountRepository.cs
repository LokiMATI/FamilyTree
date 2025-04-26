namespace FamilyTree.Domain.Accounts;

/// <summary>
/// Репозиторий аккаунта.
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// Получить аккаунт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Аккаунт.</returns>
    Task<Account> GetByIdAsync(
        Guid id);
    
    /// <summary>
    /// Получить аккаунт по логину.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Аккаунт.</returns>
    Task<Account> GetByLoginAsync(
        string login);
    
    /// <summary>
    /// Получить аккаунт по электронной почте.
    /// </summary>
    /// <param name="email">Электронная почта.</param>
    /// <returns>Аккаунт.</returns>
    Task<Account> GetByEmailAsync(
        string email);

    /// <summary>
    /// Создать новый аккаунт.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="email">Почта.</param>
    /// <returns>Созданный аккаунт.</returns>
    Task<Account> CreateAsync(
        string login,
        string password,
        string? email);
    
    /// <summary>
    /// Обновить аккаунт.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="email">Электронная почта.</param>
    /// <returns>Обновлённый аккаунт.</returns>
    Task<Account> UpdateAsync(
        Guid id,
        string? password,
        string? email);
}
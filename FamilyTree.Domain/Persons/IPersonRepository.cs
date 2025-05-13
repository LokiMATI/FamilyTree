namespace FamilyTree.Domain.Persons;

/// <summary>
/// Репозиторий человека.
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// Получить человека.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Человек.</returns>
    Task<Person> GetAsync(
        Guid id);

    /// <summary>
    /// Получить человека по идентификатору аккаунта. 
    /// </summary>
    /// <param name="id">Идентификатор аккаунта.</param>
    /// <returns>Человек.</returns>
    Task<Person> GetByAccountIdAsync(
        Guid id);

    /// <summary>
    /// Получить список людей.
    /// </summary>
    /// <param name="gender">Гендер.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="deathDate">Дата смерти.</param>
    /// <param name="page">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Список людей.</returns>
    Task<List<Person>> GetListAsync(
        Gender? gender = null,
        string? firstName = null,
        string? lastName = null,
        string? patronymic = null,
        DateTime? birthDate = null,
        DateTime? deathDate = null,
        int page = 1,
        int pageSize = int.MaxValue);

    /// <summary>
    /// Создать нового человека.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="patronymic">Отечество.</param>
    /// <param name="fatherId">Идентификатор отца.</param>
    /// <param name="motherId">Идентификатор матери.</param>
    /// <param name="accountId">Идентификатор аккаунт.</param>
    /// <returns>Созданный человек.</returns>
    Task<Person> CreateAsync(
        string firstName,
        string lastName,
        Gender gender,
        string? patronymic = null,
        Guid? fatherId = null,
        Guid? motherId = null,
        Guid? accountId = null);
    
    /// <summary>
    /// Обновить человека.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="birthPlace">Место рождения.</param>
    /// <param name="deathDate">Дата смерти.</param>
    /// <param name="deathPlace">Место смерти.</param>
    /// <param name="fatherId">Идентификатор отца.</param>
    /// <param name="motherId">Идентификатор матери.</param>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    /// <param name="biography">Биография.</param>
    /// <returns>Обновлённый человек.</returns>
    Task<Person> UpdateAsync(
        Guid id,
        string? firstName = null,
        string? lastName = null,
        string? patronymic = null,
        DateTime? birthDate = null,
        string? birthPlace = null,
        DateTime? deathDate = null,
        string? deathPlace = null,
        Guid? fatherId = null,
        Guid? motherId = null,
        Guid? accountId = null,
        string? biography = null);
    
    /// <summary>
    /// Удалить человека.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(
        Guid id);
}

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
    /// Получить список людей.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="deathDate">Дата смерти.</param>
    /// <param name="page">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Список людей.</returns>
    Task<List<Person>> GetListAsync(
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
    /// <param name="patronymic">Отечество.</param>
    /// <param name="father">Отец.</param>
    /// <param name="mother">Мать.</param>
    /// <param name="partners">Партнёры.</param>
    /// <param name="children">Дети.</param>
    /// <param name="accountId">Идентификатор аккаунт.</param>
    /// <returns>Созданный человек.</returns>
    Task<Person> CreateAsync(
        string firstName,
        string lastName,
        string? patronymic = null,
        Person? father = null,
        Person? mother = null,
        List<Person>? partners = null,
        List<Person>? children = null,
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
    /// <param name="father">Отец.</param>
    /// <param name="mother">Мать.</param>
    /// <param name="partners">Партнёры.</param>
    /// <param name="children">Дети.</param>
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
        Person? father = null,
        Person? mother = null,
        List<Person>? partners = null,
        List<Person>? children = null,
        Guid? accountId = null,
        string? biography = null);
    
    /// <summary>
    /// Удалить человека.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(
        Guid id);
}

using System.Text.RegularExpressions;

namespace FamilyTree.Domain.Persons;

/// <summary>
/// Человек.
/// </summary>
public class Person
{
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string? _patronymic;
    private string? _birthplace;
    private string? _deathPlace;
    private string? _biography;

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            
            if (value.Length > PersonConst.MaxFirstNameLength || !Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]*&"))
                throw new ArgumentException("Invalid first name", nameof(value));
            
            _firstName = value;
        }
    }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            
            if (value.Length > PersonConst.MaxLastNameLength || !Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]*&"))
                throw new ArgumentException("Invalid last name", nameof(value));
            
            _lastName = value;
        }
    }
    
    /// <summary>
    /// Гендер.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic
    {
        get => _patronymic;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            
            if (value.Length > PersonConst.MaxPatronymicLength || !Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]*&"))
                throw new ArgumentException("Invalid patronymic", nameof(value));
            
            _patronymic = value;
        }
    }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Место рождения.
    /// </summary>
    public string? Birthplace
    {
        get => _birthplace;
        set
        { 
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            
            if (value.Length > PersonConst.MaxAddressLength)
                throw new ArgumentException("Invalid length of birth place", nameof(value));
            
            _birthplace = value;
        }
    }

    /// <summary>
    /// Дата смерти.
    /// </summary>
    public DateTime? DeathDate { get; set; }

    /// <summary>
    /// Место смерти.
    /// </summary>
    public string? DeathPlace
    {
        get => _deathPlace;
        set
        { 
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            
            if (value.Length > PersonConst.MaxAddressLength)
                throw new ArgumentException("Invalid length of death place", nameof(value));
            
            _deathPlace = value;
        }
    }

    /// <summary>
    /// Идентификатор отца.
    /// </summary>
    public Guid? FatherId { get; set; }
    
    /// <summary>
    /// Идентификатор матери.
    /// </summary>
    public Guid? MotherId { get; set; }

    /// <summary>
    /// Идентификатор аккаунта.
    /// </summary>
    public Guid? AccountId { get; set; }

    /// <summary>
    /// Биография.
    /// </summary>
    public string? Biography
    {
        get => _biography;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            
            if (value.Length > PersonConst.MaxBiographyLength)
                throw new ArgumentException("Invalid length of biography", nameof(value));
            
            _biography = value;
        }
    }

    /// <summary>
    /// Создание на основе первичных данных.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="fatherId">Идентификатор отца.</param>
    /// <param name="motherId">Идентификатор матери.</param>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    public Person(
        string firstName,
        string lastName,
        Gender gender,
        string? patronymic,
        Guid? fatherId,
        Guid? motherId,
        Guid? accountId)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        
        if (patronymic is not null)
            Patronymic = patronymic;
        
        if (fatherId is not null)
            FatherId = fatherId;
        
        if (motherId is not null)
            MotherId = motherId;
        
        if (accountId is not null)
            AccountId = accountId;
    }
}

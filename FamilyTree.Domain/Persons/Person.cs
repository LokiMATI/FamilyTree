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
    private readonly List<Person> _partners = new();
    private readonly List<Person> _children = new();

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
    /// Отец.
    /// </summary>
    public Person? Father { get; set; }
    
    /// <summary>
    /// Мать.
    /// </summary>
    public Person? Mother { get; set; }

    /// <summary>
    /// Партнёры.
    /// </summary>
    public List<Person> Partners
    {
        get => _partners;
        set
        {
            foreach (var partner in value)
                if (!_partners.Contains(partner))
                    _partners.Add(partner);
        }
    }

    /// <summary>
    /// Дети.
    /// </summary>
    public List<Person> Children
    {
        get => _children;
        set
        { 
            foreach (var child in value)
                if (!_children.Contains(child))
                    _children.Add(child);
        }
    }

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
    /// <param name="patronymic">Отчество.</param>
    /// <param name="father">Отец.</param>
    /// <param name="mother">Мать.</param>
    /// <param name="partners">Партнёры.</param>
    /// <param name="children">Дети.</param>
    /// <param name="accountId">Идентификатор аккаунта.</param>
    public Person(
        string firstName,
        string lastName,
        string? patronymic,
        Person? father,
        Person? mother,
        List<Person>? partners,
        List<Person>? children,
        Guid? accountId)
    {
        FirstName = firstName;
        LastName = lastName;
        
        if (patronymic is not null)
            Patronymic = patronymic;
        
        if (father is not null)
            Father = father;
        
        if (mother is not null)
            Mother = mother;
        
        if (partners is not null)
            Partners = partners;
        
        if (children is not null)
            Children = children;
        
        if (accountId is not null)
            AccountId = accountId;
    }
}

using System.Text.RegularExpressions;

namespace FamilyTree.Domain.Persons;

/// <summary>
/// Человек.
/// </summary>
public class Person
{
    private string _firstName;
    private string _lastName;
    private string? _patronymic;
    private string? _birthplace;
    private string? _deathPlace;
    private string? _biography;
    private List<Person> _partners = new();
    private List<Person> _children = new();

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public virtual Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// Имя.
    /// </summary>
    public virtual string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            
            if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]*&"))
                throw new ArgumentException("Invalid first name", nameof(value));
            
            _firstName = value;
        }
    }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public virtual string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            
            if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]*&"))
                throw new ArgumentException("Invalid last name", nameof(value));
            
            _lastName = value;
        }
    }

    /// <summary>
    /// Отчество.
    /// </summary>
    public virtual string? Patronymic
    {
        get => _patronymic;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            
            if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-Я\s]*&"))
                throw new ArgumentException("Invalid patronymic", nameof(value));
            
            _patronymic = value;
        }
    }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    public virtual DateTime? BirthDate { get; set; }

    /// <summary>
    /// Место рождения.
    /// </summary>
    public virtual string? Birthplace
    {
        get => _birthplace;
        set
        { 
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            
            _birthplace = value;
        }
    }

    /// <summary>
    /// Дата смерти.
    /// </summary>
    public virtual DateTime? DeathDate { get; set; }

    /// <summary>
    /// Место смерти.
    /// </summary>
    public virtual string? DeathPlace
    {
        get => _deathPlace;
        set
        { 
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            
            _deathPlace = value;
        }
    }

    /// <summary>
    /// Отец.
    /// </summary>
    public virtual Person? Father { get; set; }
    
    /// <summary>
    /// Мать.
    /// </summary>
    public virtual Person? Mother { get; set; }

    /// <summary>
    /// Партнёры.
    /// </summary>
    public virtual List<Person>? Partners
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
    public virtual List<Person>? Children
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
    public virtual Guid? AccountId { get; set; }

    /// <summary>
    /// Биография.
    /// </summary>
    public virtual string? Biography
    {
        get => _biography;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            
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

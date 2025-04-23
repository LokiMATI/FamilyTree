namespace FamilyTree.Domain.Persons;

/// <summary>
/// Константы для человека.
/// </summary>
public class PersonConst
{
    /// <summary>
    /// Максимальная длина имени.
    /// </summary>
    public const byte MaxFirstNameLength = 60;
    
    /// <summary>
    /// Максимальная длина фамилии.
    /// </summary>
    public const byte MaxLastNameLength = 60;
    
    /// <summary>
    /// Максимальная длина отчества.
    /// </summary>
    public const byte MaxPatronymicLength = 60;
    
    /// <summary>
    /// Максимальная длинна адреса.
    /// </summary>
    public const byte MaxAddressLength = 100;
    
    /// <summary>
    /// Максимальная длина содержания биографии.
    /// </summary>
    public const int MaxBiographyLength = 500_000;
}
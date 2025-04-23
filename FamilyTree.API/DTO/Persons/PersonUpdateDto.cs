namespace FamilyTree.API.DTO.Persons;

public record PersonUpdateDto(
    string? FirstName = null,
    string? LastName = null,
    string? Patronymic = null,
    DateTime? BirthDate = null,
    string? BirthPlace = null,
    DateTime? DeathDate = null,
    string? DeathPlace = null,
    Guid? FatherId = null,
    Guid? MotherId = null,
    Guid? AccountId = null,
    string? Biography = null);
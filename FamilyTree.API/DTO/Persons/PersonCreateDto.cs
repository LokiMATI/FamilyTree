using FamilyTree.Domain.Persons;

namespace FamilyTree.API.DTO.Persons;

public record PersonCreateDto(
    string FirstName,
    string LastName,
    Gender Gender,
    string? Patronymic = null,
    Guid? FatherId = null,
    Guid? MotherId = null,
    Guid? AccountId = null);
namespace FamilyTree.API.DTO.Accounts;

public record AccountRegistrationDto(string Login, string Password, string? Email = null);
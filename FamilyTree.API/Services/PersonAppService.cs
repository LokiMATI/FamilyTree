using FamilyTree.Domain.Persons;
using Google.Protobuf.WellKnownTypes;

namespace FamilyTree.API.Services;

public class PersonAppService(IPersonRepository personRepository)
{
    public async Task<Person> GetPersonAsync(
        Guid id)
    {
        return await personRepository.GetAsync(
            id);
    }

    public async Task<List<Person>> GetPersonsAsync(
        Gender? gender = null,
        string? firstName = null,
        string? lastName = null,
        string? patronymic = null,
        DateTime? birthDate = null,
        DateTime? deathDate = null,
        int page = 1,
        int pageSize = int.MaxValue)
    {
        return await personRepository.GetListAsync(
            gender,
            firstName,
            lastName,
            patronymic,
            birthDate,
            deathDate,
            page,
            pageSize);
    }

    public async Task<Person> CreatePersonAsync(
        string firstName,
        string lastName,
        Gender gender,
        string? patronymic = null,
        Guid? fatherId = null,
        Guid? motherId = null,
        Guid? accountId = null)
    {
        return await personRepository.CreateAsync(
            firstName,
            lastName,
            gender,
            patronymic,
            fatherId,
            motherId,
            accountId);
    }

    public async Task<Person> UpdatePersonAsync(
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
        string? biography = null)
    {
        return await personRepository.UpdateAsync(
            id,
            firstName,
            lastName,
            patronymic,
            birthDate,
            birthPlace,
            deathDate,
            deathPlace,
            fatherId,
            motherId,
            accountId,
            biography);
    }

    public async Task DeletePersonAsync(
        Guid id)
    {
        await personRepository.DeleteAsync(id);
    }
    
}
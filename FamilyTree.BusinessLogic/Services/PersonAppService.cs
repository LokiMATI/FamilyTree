using FamilyTree.Domain.Persons;
using Microsoft.Extensions.Caching.Memory;

namespace FamilyTree.BusinessLogic.Services;

public class PersonAppService(IPersonRepository personRepository, IMemoryCache memoryCache)
{
    public async Task<Person> GetPersonAsync(
        Guid id)
    {
        memoryCache.TryGetValue(id, out Person? person);
        
        if (person is not null)
            return person;
        
        person = await personRepository.GetAsync(
            id);
        
        memoryCache.Set(id, person, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
        
        return person;
    }

    public async Task<Person> GetPersonByAccountIdAsync(
        Guid id)
    {
        return await personRepository.GetByAccountIdAsync(
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
        var person = await personRepository.CreateAsync(
            firstName,
            lastName,
            gender,
            patronymic,
            fatherId,
            motherId,
            accountId);
        
        memoryCache.Set(person.Id, person, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
        
        return person;
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
        var person = await personRepository.UpdateAsync(
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
        
        memoryCache.Set(person.Id, person, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
        
        return person;
    }

    public async Task DeletePersonAsync(
        Guid id)
    {
        memoryCache.Remove(id);
        
        await personRepository.DeleteAsync(id);
    }
    
}
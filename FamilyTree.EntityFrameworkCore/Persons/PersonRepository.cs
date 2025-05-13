using FamilyTree.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.EntityFrameworkCore.Persons;

/// <inheritdoc cref="IPersonRepository"/>
public class PersonRepository(FamilyTreeDbContext context) :
    IPersonRepository
{
    /// <inheritdoc/>
    public async Task<Person> GetAsync(
        Guid id)
    {
        var person = await context.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        
        if (person is null)
            throw new KeyNotFoundException("Person not found");
        
        return person;
    }

    /// <inheritdoc/>
    public async Task<Person> GetByAccountIdAsync(
        Guid id)
    {
        var person = await context.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.AccountId == id);
        
        if (person is null)
            throw new KeyNotFoundException("Person not found");
        
        return person;
    }

    /// <inheritdoc/>
    public async Task<List<Person>> GetListAsync(
        Gender? gender = null,
        string? firstName = null,
        string? lastName = null,
        string? patronymic = null,
        DateTime? birthDate = null, 
        DateTime? deathDate = null,
        int page = 1,
        int pageSize = int.MaxValue)
    {
        var persons = await context.Persons.AsNoTracking().ToListAsync();
        
        if (gender is not null)
            persons = await Task.Run(() => 
                persons.Where(p => p.Gender == gender).ToList());
        
        if (firstName is not null)
            persons = await Task.Run(() => 
                persons.Where(p => p.FirstName == firstName).ToList());
        
        if (lastName is not null)
            persons = await Task.Run(() =>
                persons.Where(p => p.LastName == lastName).ToList());
        
        if (patronymic is not null)
            persons = await Task.Run(() => 
                persons.Where(p => p.Patronymic == patronymic).ToList());
        
        if (birthDate is not null)
            persons = await Task.Run(() =>
                persons.Where(p => p.BirthDate == birthDate).ToList());
        
        if (deathDate is not null)
            persons = await Task.Run(() =>
                persons.Where(p => p.DeathDate == deathDate).ToList());
        
        return await Task.Run(() => 
            persons.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList());
    }

    /// <inheritdoc/>
    public async Task<Person> CreateAsync(
        string firstName, 
        string lastName,
        Gender gender,
        string? patronymic = null,
        Guid? fatherId = null,
        Guid? motherId = null,
        Guid? accountId = null)
    {
        Person person = new(
            firstName: firstName,
            lastName: lastName,
            gender: gender,
            patronymic: patronymic,
            fatherId: fatherId,
            motherId: motherId,
            accountId: accountId);
        
        await context.Persons.AddAsync(person);
        await context.SaveChangesAsync();
        
        return person;
    }

    /// <inheritdoc/>
    public async Task<Person> UpdateAsync(
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
        var person = await context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        
        if (person is null)
            throw new KeyNotFoundException("Person not found");
        
        if (firstName is not null)
            person.FirstName = firstName;

        if (lastName is not null)
            person.LastName = lastName;
        
        if (patronymic is not null)
            person.Patronymic = patronymic;
        
        if (birthDate is not null)
            person.BirthDate = birthDate;
        
        if (birthPlace is not null)
            person.Birthplace = birthPlace;
        
        if (deathDate is not null)
            person.DeathDate = deathDate;
        
        if (deathPlace is not null)
            person.DeathPlace = deathPlace;
        
        if (fatherId is not null)
            person.FatherId = fatherId;
        
        if (motherId is not null)
            person.MotherId = motherId;
        
        if (accountId is not null)
            person.AccountId = accountId;
        
        if (biography is not null)
            person.Biography = biography;
        
        context.Persons.Update(person);
        await context.SaveChangesAsync();
        
        return person;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        Guid id)
    {
        var person = await context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        
        if (person is null)
            throw new KeyNotFoundException("Person not found");
        
        await Task.Run(() => context.Persons.Remove(person));
        await context.SaveChangesAsync();
    }
}
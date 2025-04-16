using FamilyTree.Domain.Persons;

namespace FamilyTree.EntityFrameworkCore.Persons;

/// <inheritdoc cref="IPersonRepository"/>
public class PersonRepository :
    IPersonRepository
{
    private readonly FamilyTreeDbContext _context;

    public PersonRepository(FamilyTreeDbContext context)
    {
        _context = context;
    }
    
    public async Task<Person> GetAsync(
        Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Person>> GetListAsync(string? firstName = null, string? lastName = null, string? patronymic = null,
        DateTime? birthDate = null, DateTime? deathDate = null, int page = 1, int pageSize = Int32.MaxValue)
    {
        throw new NotImplementedException();
    }

    public async Task<Person> CreateAsync(string firstName, string lastName, string? patronymic = null, Person? father = null,
        Person? mother = null, List<Person>? partners = null, List<Person>? children = null, Guid? accountId = null)
    {
        throw new NotImplementedException();
    }

    public async Task<Person> UpdateAsync(Guid id, string? firstName = null, string? lastName = null, string? patronymic = null,
        DateTime? birthDate = null, string? birthPlace = null, DateTime? deathDate = null, string? deathPlace = null,
        Person? father = null, Person? mother = null, List<Person>? partners = null, List<Person>? children = null, Guid? accountId = null,
        string? biography = null)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
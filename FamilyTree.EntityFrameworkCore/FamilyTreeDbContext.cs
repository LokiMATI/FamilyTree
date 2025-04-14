using FamilyTree.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.EntityFrameworkCore;

/// <summary>
/// Контекст проекта FamilyTree
/// </summary>
public class FamilyTreeDbContext(DbContextOptions<FamilyTreeDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Сущность людей.
    /// </summary>
    DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Person>(person =>
        {
            person.ToTable("Person");
            person.HasKey(p => p.Id);

            person.HasIndex(i => new { i.FirstName, i.LastName });
            
            person.Property(p => p.FirstName).IsRequired().HasMaxLength(PersonConst.MaxFirstNameLength);
            person.Property(p => p.LastName).IsRequired().HasMaxLength(PersonConst.MaxLastNameLength);
            person.Property(p => p.Patronymic).HasMaxLength(PersonConst.MaxPatronymicLength);
            person.Property(p => p.Birthplace).HasMaxLength(PersonConst.MaxAddressLength);
            person.Property(p => p.DeathPlace).HasMaxLength(PersonConst.MaxAddressLength);
            person.Property(p => p.Biography).HasMaxLength(PersonConst.MaxBiographyLength);
            
            person.HasOne(p => p.Father).WithMany(u => u.Children);
            person.HasOne(p => p.Mother).WithMany(u => u.Children);
            person.HasMany(p => p.Partners).WithMany(u => u.Partners)
                .UsingEntity(j => j.ToTable("Partners"));
        });
    }
}

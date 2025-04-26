using FamilyTree.Domain.Accounts;
using FamilyTree.Domain.Persons;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.EntityFrameworkCore;

/// <summary>
/// Контекст проекта FamilyTree
/// </summary>
public class FamilyTreeDbContext : 
    DbContext
{
    /// <summary>
    /// Сущность людей.
    /// </summary>
    public DbSet<Person> Persons { get; set; }
    public DbSet<Account> Accounts { get; set; }

    public FamilyTreeDbContext(DbContextOptions<FamilyTreeDbContext> options) 
        : base(options)
    {
    }

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
    
            person.HasOne<Person>().WithMany().HasForeignKey(k => k.FatherId).OnDelete(DeleteBehavior.SetNull);
            person.HasOne<Person>().WithMany().HasForeignKey(k => k.MotherId).OnDelete(DeleteBehavior.SetNull);
            person.HasOne<Account>().WithMany().HasForeignKey(k => k.AccountId).OnDelete(DeleteBehavior.SetNull);
        });
    
        modelBuilder.Entity<Account>(account =>
        {
            account.ToTable("Account");
            account.HasKey(a => a.Id);
            
            account.Property(p => p.Login).IsRequired().HasMaxLength(AccountConst.MaxLoginLength);
            account.Property(p => p.PasswordHash).IsRequired();
        });
    }
}

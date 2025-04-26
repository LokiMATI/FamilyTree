using FamilyTree.Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.EntityFrameworkCore.Accounts;

/// <inheritdoc cref="IAccountRepository"/>
public class AccountRepository(FamilyTreeDbContext context) :
    IAccountRepository
{
    /// <inheritdoc/>
    public async Task<Account> GetByIdAsync(
        Guid id)
    {
        var account = await context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        
        if (account is null)
            throw new KeyNotFoundException("Account not found");
        
        return account;
    }

    /// <inheritdoc/>
    public async Task<Account> GetByLoginAsync(
        string login)
    {
        var account = await context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Login == login);
        
        if (account is null)
            throw new KeyNotFoundException("Account not found");
        
        return account;
    }

    /// <inheritdoc/>
    public async Task<Account> GetByEmailAsync(
        string email)
    {
        var account = await context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Email == email);
        
        if (account is null)
            throw new KeyNotFoundException("Account not found");
        
        return account;
    }

    /// <inheritdoc/>
    public async Task<Account> CreateAsync(
        string login,
        string password,
        string? email)
    {
        if (context.Accounts.Any(a => a.Login == login))
            throw new AggregateException("Login is already in use");
        if (email is not null && context.Accounts.Any(a => a.Email == email))
            throw new AggregateException("Email is already in use");
        
        var account = new Account(
            login,
            email);
        
        account.PasswordHash = new PasswordHasher<Account>().HashPassword(account, password);
        
        await context.Accounts.AddAsync(account);
        await context.SaveChangesAsync();
        
        return account;
    }

    /// <inheritdoc/>
    public async Task<Account> UpdateAsync(
        Guid id,
        string? password,
        string? email)
    {
        var account = await context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        
        if (account is null)
            throw new KeyNotFoundException("Account not found");
        
        if (password is not null)
            account.PasswordHash = new PasswordHasher<Account>().HashPassword(account, password);
        
        if (email is not null && !context.Accounts.Any(a => a.Email == email))
            account.Email = email;
        
        context.Accounts.Update(account);
        await context.SaveChangesAsync();
        
        return account;
    }
}
using FamilyTree.Domain.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace FamilyTree.BusinessLogic.Services;

public class AccountAppService(IAccountRepository repository, JwtService jwtService, IMemoryCache memoryCache)
{
    public async Task<Account> GetAccountByIdAsync(
        Guid id)
    {
        memoryCache.TryGetValue(id, out Account? account);

        if (account is not null) 
            return account;
        
        account = await repository.GetByIdAsync(id);
        memoryCache.Set(id, account, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));

        return account;
    }

    public async Task<Account> GetAccountByLoginAsync(
        string login)
    {
        return await repository.GetByLoginAsync(login);
    }
    
    public async Task<Account> GetAccountByEmailAsync(
        string email)
    {
        return await repository.GetByEmailAsync(
            email);
    }

    public async Task<string> RegistrationAsync(
        string login,
        string password,
        string? email)
    {
        var account = await repository.CreateAsync(
            login: login,
            password: password,
            email: email);
        
        memoryCache.Set(account.Id, account, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
        
        return jwtService.GenerateToken(
            account);
    }

    public async Task<string> LoginAsync(
        string login,
        string password)
    {
        var account = await repository.GetByLoginAsync(
            login);
        
        var result = new PasswordHasher<Account>()
            .VerifyHashedPassword(account, account.PasswordHash, password);

        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Unauthorized");
        
        memoryCache.Set(account.Id, account, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(60)));
        
        return jwtService.GenerateToken(account);
    }
}
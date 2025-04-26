using FamilyTree.Domain.Accounts;
using Microsoft.AspNetCore.Identity;

namespace FamilyTree.BusinessLogic.Services;

public class AccountAppService(IAccountRepository repository, JwtService jwtService)
{
    public async Task<Account> GetAccountByIdAsync(
        Guid id)
    {
        return await repository.GetByIdAsync(
            id);
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
        
        return jwtService.GenerateToken(account);
    }
}
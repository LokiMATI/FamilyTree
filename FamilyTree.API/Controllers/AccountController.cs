using FamilyTree.API.DTO.Accounts;
using FamilyTree.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(AccountAppService service) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<AccountDto>> GetAccountById(
        Guid id)
    {
        try
        {
            var account = await service.GetAccountByIdAsync(
                id);
            return Ok(new AccountDto(
                Id: account.Id,
                Login: account.Login,
                Email: account.Email));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [Authorize]
    [HttpGet("login")]
    public async Task<ActionResult<AccountDto>> GetAccountByLogin(
        string login)
    {
        try
        {
            var account = await service.GetAccountByLoginAsync(
                login);
            return Ok(new AccountDto(
                Id: account.Id,
                Login: account.Login,
                Email: account.Email));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [Authorize]
    [HttpGet("email")]
    public async Task<ActionResult<AccountDto>> GetAccountByEmail(
        string email)
    {
        try
        {
            return Ok(await service.GetAccountByEmailAsync(
                email));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost("auth")]
    public async Task<ActionResult<string>> Login(AccountLoginDto input)
    {
        try
        {
            return Ok(await service.LoginAsync(
                login: input.Login,
                password: input.Password));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Registration(AccountRegistrationDto input)
    {
        try
        {
            return Ok(await service.RegistrationAsync(
                login: input.Login,
                password: input.Password,
                email: input.Email));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
using FamilyTree.API.DTO.Persons;
using FamilyTree.BusinessLogic.Services;
using FamilyTree.Domain.Persons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.API.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PersonController(PersonAppService service) : ControllerBase
{
    [HttpGet("{id:guid:required}")]
    public async Task<ActionResult<Person>> GetPerson(
        Guid id)
    {
        try
        {
            return Ok(await service.GetPersonAsync(
                id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetListOfPeople(
        Gender? gender,
        string? firstName,
        string? lastName,
        string? patronymic,
        DateTime? birthDate,
        DateTime? deathDate,
        int page = 1,
        int pageSize = int.MaxValue)
    {
            var persons = await service.GetPersonsAsync(
                gender,
                firstName,
                lastName,
                patronymic,
                birthDate,
                deathDate,
                page,
                pageSize);
            
            return Ok(
                persons);
    }

    [HttpPost]
    public async Task<ActionResult<Person>> CreatePerson(
        [FromBody] PersonCreateDto input)
    {
        try
        {
            return Ok(await service.CreatePersonAsync(
                firstName: input.FirstName,
                lastName: input.LastName,
                gender: input.Gender,
                patronymic: input.Patronymic,
                fatherId: input.FatherId,
                motherId: input.MotherId,
                accountId: input.AccountId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:guid:required}")]
    public async Task<ActionResult<Person>> UpdatePerson(
        Guid id,
        [FromBody] PersonUpdateDto input)
    {
        try
        {
            return Ok(await service.UpdatePersonAsync(
                id: id,
                firstName: input.FirstName,
                lastName: input.LastName,
                patronymic: input.Patronymic,
                birthDate: input.BirthDate,
                birthPlace: input.BirthPlace,
                deathDate: input.DeathDate,
                deathPlace: input.DeathPlace,
                fatherId: input.FatherId,
                motherId: input.MotherId,
                accountId: input.AccountId,
                biography: input.Biography));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid:required}")]
    public async Task<ActionResult> DeletePerson(
        Guid id)
    {
        try
        {
            await service.DeletePersonAsync(
                id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
}
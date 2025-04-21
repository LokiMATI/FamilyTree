  using FamilyTree.Domain.Persons;
 using Google.Protobuf.WellKnownTypes;
 using Grpc.Core;
 using PersonServiceApp;
 using Gender = FamilyTree.Domain.Persons.Gender;
 using GenderGRpc = PersonServiceApp.Gender;

 namespace FamilyTree.Services.Services.Persons;

public class PersonAppService(IPersonRepository personRepository) :
    PersonService.PersonServiceBase
{
    public override Task<PersonReply> GetPerson(
        PersonIdRequest request,
        ServerCallContext context)
    {
        try
        {
            var person = personRepository.GetAsync(
                Guid.Parse(request.Id)).Result;

            var personReply = new PersonReply
            {
                Id = person.Id.ToString(),
                Gender = (GenderGRpc)person.Gender,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Patronymic = person.Patronymic,
                BirthDate = person.BirthDate.ToString(),
                Birthplace = person.Birthplace,
                DeathDate = person.DeathDate.ToString(),
                DeathPlace = person.DeathPlace,
                FatherId = person.FatherId.ToString(),
                MotherId = person.MotherId.ToString(),
                AccountId = person.AccountId.ToString(),
                Biography = person.Biography
            };
            
            return Task.FromResult(personReply);
        }
        catch (KeyNotFoundException e)
        {
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
        }
    }
    
    public override Task<GetListResponse> GetListPersons(
        GetListRequest request,
        ServerCallContext context)
    {
        var persons = personRepository.GetListAsync(
            gender: request.Gender == GenderGRpc.Unknown ? null : (Gender)request.Gender,
            firstName: request.FirstName,
            lastName: request.LastName,
            patronymic: request.Patronymic,
            birthDate: DateTime.Parse(request.BirthDate),
            deathDate: DateTime.Parse(request.DeathDate),
            page: request.Page,
            pageSize: request.PageSize).Result;

        var response = new GetListResponse();
        
        response.Persons.AddRange(
            persons.Select(p => new PersonReply
            {
                Id = p.Id.ToString(),
                Gender = (GenderGRpc)p.Gender,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Patronymic = p.Patronymic,
                BirthDate = p.BirthDate.ToString(),
                Birthplace = p.Birthplace,
                DeathDate = p.DeathDate.ToString(),
                DeathPlace = p.DeathPlace,
                FatherId = p.FatherId.ToString(),
                MotherId = p.MotherId.ToString(),
                AccountId = p.AccountId.ToString(),
                Biography = p.Biography
            }));
        
        return Task.FromResult(response);
    }

    public override Task<PersonReply> CreatePerson(
        CreateRequest request,
        ServerCallContext context)
    {
        try
        {
            var person = personRepository.CreateAsync(
                firstName: request.FirstName,
                lastName: request.LastName,
                gender: (Gender)request.Gender,
                patronymic: request.Patronymic,
                fatherId: Guid.Parse(request.FatherId),
                motherId: Guid.Parse(request.MotherId),
                accountId: Guid.Parse(request.AccountId)).Result;

            var personReply = new PersonReply
            {
                Id = person.Id.ToString(),
                Gender = (GenderGRpc)person.Gender,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Patronymic = person.Patronymic,
                BirthDate = person.BirthDate.ToString(),
                Birthplace = person.Birthplace,
                DeathDate = person.DeathDate.ToString(),
                DeathPlace = person.DeathPlace,
                FatherId = person.FatherId.ToString(),
                MotherId = person.MotherId.ToString(),
                AccountId = person.AccountId.ToString(),
                Biography = person.Biography
            };

            return Task.FromResult(personReply);
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
        }
    }

    public override Task<PersonReply> UpdatePerson(
        UpdateRequest request,
        ServerCallContext context)
    {
        try
        {
            var person = personRepository.UpdateAsync(
                id: Guid.Parse(request.Id),
                firstName: request.FirstName,
                lastName: request.LastName,
                patronymic: request.Patronymic,
                birthDate: DateTime.Parse(request.BirthDate),
                birthPlace: request.Birthplace,
                deathDate: DateTime.Parse(request.DeathDate),
                deathPlace: request.DeathPlace,
                fatherId: Guid.Parse(request.FatherId),
                motherId: Guid.Parse(request.MotherId),
                accountId: Guid.Parse(request.AccountId),
                biography: request.Biography).Result;

            var personReply = new PersonReply
            {
                Id = person.Id.ToString(),
                Gender = (GenderGRpc)person.Gender,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Patronymic = person.Patronymic,
                BirthDate = person.BirthDate.ToString(),
                Birthplace = person.Birthplace,
                DeathDate = person.DeathDate.ToString(),
                DeathPlace = person.DeathPlace,
                FatherId = person.FatherId.ToString(),
                MotherId = person.MotherId.ToString(),
                AccountId = person.AccountId.ToString(),
                Biography = person.Biography
            };

            return Task.FromResult(personReply);
        }
        catch (KeyNotFoundException e)
        {
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
        }
    }

    public override Task<Empty> DeletePerson(
        PersonIdRequest request,
        ServerCallContext context)
    {
        try
        {
            personRepository.DeleteAsync(
                Guid.Parse(request.Id));

            return Task.FromResult(new Empty());
        }
        catch (KeyNotFoundException e)
        {
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
        catch (Exception e)
        {
            throw new RpcException(new Status(StatusCode.Unknown, e.Message));
        }
    }
}
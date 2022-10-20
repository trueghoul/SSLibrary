using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSLibrary.API.CQRS.Persons.Commands.CreatePerson;
using SSLibrary.API.CQRS.Persons.Commands.DeletePerson;
using SSLibrary.API.CQRS.Persons.Commands.UpdatePerson;
using SSLibrary.API.CQRS.Persons.Queries.GetPerson;

namespace SSLibrary.API.Controllers;

[Route("api/[controller]")]
public class PersonController : BaseController
{
    private readonly IMapper _mapper;

    public PersonController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDetailsVm>> Get(Guid id)
    {
        var query = new GetPersonDetailsQuery
        {
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePersonCommand createPersonCommand)
    {
        var personId = await Mediator.Send(createPersonCommand);
        return Ok(personId);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdatePersonCommand updatePersonCommand)
    {
        await Mediator.Send(updatePersonCommand);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeletePersonCommand
        {
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteByFullName(
        [FromBody] DeletePersonByFullNameCommand deletePersonByFullNameCommand)
    {
        await Mediator.Send(deletePersonByFullNameCommand);
        return NoContent();
    }

}

using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contracts;

namespace WebApi.Controllers;
[ApiController]
[Route( "api/composition" )]
public class CompositionController : ControllerBase
{
    private readonly IRepository<Composition> _compositionRepository;

    // DI-контейнер
    public CompositionController( IRepository<Composition> compositionRepository )
    {
        _compositionRepository = compositionRepository;
    }

    //GET api/theater
    [HttpGet]
    public IActionResult GetCompositions()
    {
        IReadOnlyList<Composition> theaters = _compositionRepository.GetAll();
        return Ok( theaters );
    }
    //POST Theater
    [HttpPost]
    public IActionResult CreateComposition( [FromBody] CreateCompositionRequest request )
    {
        Composition newComposition = new Composition(
            name: request.Name,
            description: request.Description,
            charactersInfo: request.CharactersInfo,
            authorId: request.AuthorId );

        try
        {
            _compositionRepository.Create( newComposition );
        }
        catch ( DbUpdateException )
        {
            return BadRequest( $"No such author with Id = {request.AuthorId} exists\"" );
        }
        return Ok( newComposition );
    }

    //DELETE api/theater/{id}
    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeleteComposition( [FromRoute] int id )
    {
        Composition? composition = _compositionRepository.GetAll().FirstOrDefault( t => t.Id == id );
        if ( composition == null )
        {
            return BadRequest( $"No such theatre with Id = {id} exists" );
        }
        _compositionRepository.Delete( composition );
        return Ok();
    }
}

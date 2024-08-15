using Domain.Repositories;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;

namespace WebApi.Controllers;
[ApiController]
[Route( "api/author" )]
public class AuthorController : ControllerBase
{
    private readonly IRepository<Author> _authorRepository;

    public AuthorController( IRepository<Author> authorRepository )
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        IReadOnlyList<Author> authors = _authorRepository.GetAll();
        return Ok( authors );
    }
    //POST author
    [HttpPost]
    public IActionResult CreateAuthor( [FromBody] CreateAuthorRequest request )
    {
        Author author = new( request.Name, request.DateOfBirth );
        _authorRepository.Create( author );

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }
    //PUT api/author/{id}
    [HttpPut, Route( "{id:int}" )]
    public IActionResult UpdateAuthor( [FromRoute] int id, ModifyAuthorRequest request )
    {
        Author? author = _authorRepository.GetAll().FirstOrDefault( t => t.Id == id );
        if ( author == null )
        {
            return BadRequest( $"No such author with Id = {id} exists" );
        }
        author.Update(
            name: request.Name,
            dateOfBirth: request.DateOfBirth );
        _authorRepository.Save();
        return Ok( author );
    }

    //DELETE api/author/{id}
    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeleteAuthor( [FromRoute] int id )
    {
        Author? author = _authorRepository.GetAll().FirstOrDefault( t => t.Id == id );
        if ( author == null )
        {
            return BadRequest( $"No such theatre with Id = {id} exists" );
        }
        _authorRepository.Delete( author );
        return Ok();
    }
}

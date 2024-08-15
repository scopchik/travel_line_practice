using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Repositories;
using WebApi.Contracts;
using Infrastructure.Repositories;

namespace WebApi.Controllers;
[ApiController]
[Route( "api/theater" )]
public class TheaterController : ControllerBase
{
    private readonly IRepository<Theater> _theaterRepository;

    // DI-контейнер
    public TheaterController( IRepository<Theater> theaterRepository )
    {
        _theaterRepository = theaterRepository;
    }

    //GET api/theater
    [HttpGet]
    public IActionResult GetTheaters()
    {
        IReadOnlyList<Theater> theaters = _theaterRepository.GetAll();
        return Ok( theaters );
    }
    //POST Theater
    [HttpPost]
    public IActionResult CreateTheater( [FromBody] CreateTheaterRequest request )
    {
        Theater theater = new( request.Name, request.Address, request.PhoneNumber, request.Description, request.OpeningDate );
        _theaterRepository.Create( theater );

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }
    //PUT api/theater/{id}
    [HttpPut, Route( "{id:int}" )]
    public IActionResult UpdateTheater( [FromRoute] int id, ModifyTheaterRequest request )
    {
        Theater? theater = _theaterRepository.GetAll().FirstOrDefault( t => t.Id == id );
        if ( theater == null )
        {
            return BadRequest( $"No such theatre with Id = {id} exists" );
        }
        theater.Update(
            name: request.Name,
            phoneNumber: request.PhoneNumber,
            description: request.Description );
        _theaterRepository.Save();
        return Ok( theater );
    }

    //DELETE api/theater/{id}
    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeleteTheater( [FromRoute] int id )
    {
        Theater? theater = _theaterRepository.GetAll().FirstOrDefault( t => t.Id == id );
        if ( theater == null )
        {
            return BadRequest( $"No such theatre with Id = {id} exists" );
        }
        _theaterRepository.Delete( theater );
        return Ok();
    }
}

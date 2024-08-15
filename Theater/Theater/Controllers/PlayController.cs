using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contracts;

namespace WebApi.Controllers;
[ApiController]
[Route( "api/play" )]
public class PlayController : ControllerBase
{
    private IPlayRepository _repository;

    public PlayController( IPlayRepository repository )
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetPlays()
    {
        List<Play> plays = _repository.GetAll();
        return Ok( plays );
    }

    [HttpGet, Route( "time_period/start={start:datetime}&&end={end:datetime}" )]
    public IActionResult GetPlaysInTimePeriod( [FromRoute] DateTime start, [FromRoute] DateTime end )
    {
        List<Play> playsInTimePeriod = _repository.GetPlaysInTimePeriod( start, end );

        List<PlayTimePeriods> playsInfo = playsInTimePeriod
            .Select( p => new PlayTimePeriods
            {
                TheatreName = p.Theater.Name,
                PlayName = p.Name,
                PlayPrice = p.Price,
                PlayDescription = p.Description,
                CompositionDescription = p.Composition.Description,
                CompositionCharacterInfo = p.Composition.CharactersInfo
            }
        ).ToList();

        GetPlaysInTimePeriod playsWithTimePeriod = new GetPlaysInTimePeriod
        {
            StartTime = start,
            EndTime = end,
            playsInfo = playsInfo
        };

        return Ok( playsWithTimePeriod );
    }

    [HttpPost]
    public IActionResult CreatePLay( [FromBody] CreatePlay play )
    {
        Play newPlay = new Play(
            name: play.Name,
            startDate: play.StartDate,
            endDate: play.EndDate,
            price: play.Price,
            description: play.Description,
            theaterId: play.TheaterId,
            compositionId: play.CompositionId );

        try
        {
            _repository.Create( newPlay );
        }
        catch ( DbUpdateException )
        {
            return BadRequest( $"No such theatre with Id = {play.TheaterId} exists " +
                $"or no such composition with Id = {play.CompositionId} exists" );
        }

        return Ok( newPlay );
    }

    [HttpDelete, Route( "{id:int}" )]
    public IActionResult DeletePLay( [FromRoute] int id )
    {
        Play? play = _repository.GetAll().FirstOrDefault( p => p.Id == id );
        if ( play == null )
        {
            return BadRequest( $"No such play with Id = {id} exists" );
        }
        _repository.Delete( play );
        return Ok();
    }
}

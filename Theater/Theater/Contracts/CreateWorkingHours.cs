using Domain.Entities;
namespace WebApi.Contracts;

public class CreateWorkingHours
{
    public byte Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public int TheaterId { get; set; }
}

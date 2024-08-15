namespace WebApi.Contracts;

public class GetPlaysInTimePeriod
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<PlayTimePeriods> playsInfo { get; set; }
}

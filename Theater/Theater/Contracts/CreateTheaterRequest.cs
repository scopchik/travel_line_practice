namespace WebApi.Contracts;

public class CreateTheaterRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public DateTime OpeningDate { get; set; }
}

namespace WebApi.Contracts;

public class CreateCompositionRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public string CharactersInfo { get; set; }
}
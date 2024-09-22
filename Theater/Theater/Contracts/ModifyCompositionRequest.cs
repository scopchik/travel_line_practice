namespace WebApi.Contracts;

public class ModifyCompositionRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public string CharacterInfo { get; set; }
}
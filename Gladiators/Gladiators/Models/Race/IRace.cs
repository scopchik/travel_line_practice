namespace Fighters.Models.Fighters;

public interface IRace
{
    public int Damage { get; }
    public int Health { get; }
    public int Armor { get; }
    public string Race { get; }
}

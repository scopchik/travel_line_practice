namespace Fighters.Models.Fighters;
public class Rogue:StandartFighter
{
    public Rogue( IRace race, string name ) : base( race, name )
    { }

    public override string Class => "Rogue";
    public override int ClassDamage => 15;
    public override int ClassHealth => 10;
}

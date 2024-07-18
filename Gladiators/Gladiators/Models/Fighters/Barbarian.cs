using Fighters.Models.Fighters;

public class Barbarian : StandartFighter
{
    public Barbarian( IRace race, string name ) : base( race, name )
    { }

    public override string Class => "Barbarian";
    public override int ClassDamage => 7;
    public override int ClassHealth => 20;
}

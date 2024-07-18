using Fighters.Models.Fighters;

public class Knight : StandartFighter
{
    public Knight( IRace race, string name ) : base( race, name )
    { }

    public override string Class => "Knight";
    public override int ClassDamage => 5;
    public override int ClassHealth => 25;
}

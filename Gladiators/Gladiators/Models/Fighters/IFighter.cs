namespace Fighters.Models.Fighters;

public interface IFighter
{
    public string Name { get; }
    public IWeapon Weapon { get; }
    public IArmor Armor { get; }
    public IRace Race { get; }
    public IClass Class { get; }

    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    public void SetArmor( IArmor armor );
    public void SetWeapon( IWeapon weapon );

    public int CalculateDamage();
    public int CalculateArmor();
    public int TakeDamage( int damage );
    public bool IsAlive() => CurrentHealth > 0;
}
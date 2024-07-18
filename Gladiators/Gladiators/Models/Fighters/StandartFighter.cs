namespace Fighters.Models.Fighters;
public abstract class StandartFighter : IFighter
{
    private string _name;
    private readonly IRace _race;
    private IArmor _armor = new NoArmor();
    private IWeapon _weapon = new Fists();
    

    public StandartFighter( IRace race, string name )
    {
        _race = race;
        _name = name;
        CurrentHealth = this.MaxHealth;
    }

    public string Name => _name;
    public IWeapon Weapon => _weapon;
    public IArmor Armor => _armor;
    public IRace Race => _race;

    public abstract string Class { get; }
    public abstract int ClassDamage { get; }
    public abstract int ClassHealth { get; }

    public int MaxHealth => _race.Health + ClassHealth;
    public int CurrentHealth { get; private set; }

    public void SetArmor( IArmor armor )
    {
        _armor = armor;
    }
    public void SetWeapon( IWeapon weapon )
    {
        _weapon = weapon;
    }

    public int CalculateDamage()
    {
        var rand = new Random();
        const int MinExtraDamage = -20;
        const int MaxExtraDamage = 10;

        int fighterDamage = _race.Damage + ClassDamage + _armor.Armor;
        double extraDamage = rand.Next( MinExtraDamage, MaxExtraDamage ) / 100 * fighterDamage;

        fighterDamage += ( int )extraDamage;

        return fighterDamage;
    }

    public int CalculateArmor()
    {
        return _race.Armor + _armor.Armor;
    }

    public int TakeDamage( int damage )
    {
        if ( CurrentHealth == 0 )
        {
            return 0;
        }

        int receivedDamage = CalculateArmor() > damage ? 1 : damage - CalculateArmor();

        if ( receivedDamage > CurrentHealth )
        {
            receivedDamage = CurrentHealth;
            CurrentHealth = 0;
            return receivedDamage;
        }

        CurrentHealth -= receivedDamage;
        return receivedDamage;
    }
}

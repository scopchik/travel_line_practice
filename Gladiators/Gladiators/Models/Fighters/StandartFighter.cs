namespace Fighters.Models.Fighters;

public class StandartFighter : IFighter
{
    public string Name { get; private set; }
    public IRace Race { get; private init; }
    public IArmor Armor { get; set; } = new NoArmor();
    public IWeapon Weapon { get; set; } = new Fists();
    public IClass Class { get; private set; }

    public StandartFighter( string name, IRace race, IClass fightersClass, IArmor armor, IWeapon weapon )
    {
        Race = race;
        Name = name;
        Class = fightersClass;
        Armor = armor;
        Weapon = weapon;
        CurrentHealth = MaxHealth;
    }

    public int MaxHealth => Race.Health + Class.Health;
    public int CurrentHealth { get; private set; }

    public void SetArmor( IArmor armor )
    {
        Armor = armor;
    }
    public void SetWeapon( IWeapon weapon )
    {
        Weapon = weapon;
    }

    public int CalculateDamage()
    {
        var rand = new Random();
        const int MinExtraDamage = -20;
        const int MaxExtraDamage = 10;

        int fighterDamage = Race.Damage + Class.Damage + Armor.Armor;
        double extraDamage = rand.Next( MinExtraDamage, MaxExtraDamage ) / 100 * fighterDamage;

        fighterDamage += ( int )extraDamage;

        return fighterDamage;
    }

    public int CalculateArmor()
    {
        return Race.Armor + Armor.Armor;
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

    public override string ToString()
    {
        return $"{Name} - {Class.Name} of {Race.Race} race\n" +
               $"Health: {CurrentHealth}/{MaxHealth}\n" +
               $"Armor: {Armor.Name} ({CalculateArmor()})\n" +
               $"Weapon: {Weapon.Name} (Damage: {CalculateDamage()})";
    }
}

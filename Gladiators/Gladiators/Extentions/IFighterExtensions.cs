using Fighters.Models.Fighters;

namespace Fighters.Extensions;
public static class IFighterExtensions
{
    public static bool IsAlive( this IFighter fighter ) => fighter.CurrentHealth > 0;
    public static string Info( this IFighter fighter )
    {
        string info = $"Fighter name - {fighter.Name}. Fighter class - {fighter.Class}. Race - {fighter.Race}. Weapon - {fighter.Weapon}. Armor - {fighter.Armor}. ";
        if ( fighter.IsAlive() )
        {
            info += $"Status - alive. Current health - {fighter.CurrentHealth}";
        }
        else
        {
            info += "Dead";
        }
        return info;
    }
}
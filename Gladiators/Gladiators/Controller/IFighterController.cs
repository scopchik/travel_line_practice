using Fighters.Models.Fighters;

namespace Fighters.Controller;

public interface IFighterController
{
    public List<IFighter> GetFighters();
    public void CreateFighter();
    public void Fight();
    public void Clear();
}
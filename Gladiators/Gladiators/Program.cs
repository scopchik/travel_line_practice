using Fighters.Managers;

public class Program
{
    static void Main( string[] args )
    {
        IGameManager gameManager = new GameManager();
        gameManager.Play();
    }
}

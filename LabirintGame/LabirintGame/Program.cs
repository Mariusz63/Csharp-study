using static System.Console;
namespace LabirintGame
{
    public class Program
    {
        static void Main()
        {
            GameMenu menu = new GameMenu();

            SetWindowSize(menu.getScreenWidth(), menu.getScreenHeight());
            SetBufferSize(menu.getScreenWidth(), menu.getScreenHeight());
            CursorVisible = false;

            Player player = new Player(1.5, 1.5, 0); // Create a new player and set player's initial position and angle       
            menu.Start(player);

        }
    }
}
using static System.Console;
namespace LabirintGame
{
    public class Program
    {
        public static void Main()
        {
            GameMenu menu = new GameMenu();

            SetWindowSize(menu.getScreenWidth(), menu.getScreenHeight());
            SetBufferSize(menu.getScreenWidth(), menu.getScreenHeight());
            CursorVisible = false;


            // Choosing one answer
            Answer answer = new Answer();
            string currentPassword = answer.getCurrentPassword();
            WordsGame game = new WordsGame(5, currentPassword);
            Player player = new Player(1.5, 1.5, 0, game); // Create a new player and set player's initial position and angle       
            menu.Start(player);

        }
    }
}
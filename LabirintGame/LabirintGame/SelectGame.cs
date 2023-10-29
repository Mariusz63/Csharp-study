namespace LabirintGame
{
    public class SelectGame
    {
        private int select;
        private bool results;

        public SelectGame(int select)
        {
            this.select = select;
        }

        public static bool Switch(int select)
        {
            bool result = false;
            switch (select)
            {
                case 0:
                    MiniLabirintGame.Class game = new MiniLabirintGame.Class();
                    result = game.Game();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;

            }

            if (result)
            {
                return true;
            }
            return false;
        }
    }
}

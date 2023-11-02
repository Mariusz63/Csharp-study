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
                    MiniLabirintGame.Class game1 = new MiniLabirintGame.Class();
                    result = game1.Game();
                    return result;
                case 1:
                    GuessNumber.GuessNum game2 = new GuessNumber.GuessNum();
                    result = game2.Main();
                    return result;
                case 2:
                    break;
                default:
                    break;

            }
            return result;
        }
    }
}

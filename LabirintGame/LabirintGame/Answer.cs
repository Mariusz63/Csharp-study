namespace LabirintGame
{
    public class Answer
    {
        private List<string> passwords;
        private Random random;

        private string CurrentPassword;
        public string getCurrentPassword()
        {
            return CurrentPassword;
        }



        public Answer()
        {
            PasswordLoader wordListLoader = new PasswordLoader(@"F:\Projekty\C# study\Csharp-study\LabirintGame\LabirintGame\Words\Words.txt");
            passwords = wordListLoader.LoadPasswords();
            SetRandomPassword();
        }

        public void SetRandomPassword()
        {
            //int passCount = passwords.Count;
            //if (passCount > 0)
            //{
            //    random = new Random();
            //    int index = random.Next(0, passCount);
            //    CurrentPassword = passwords[index];
            //}
            //else
            //{
                
            //}
            CurrentPassword = "admin";
        }
    }

}

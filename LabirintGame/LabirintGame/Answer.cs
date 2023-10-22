namespace LabirintGame
{
    public class Answer
    {
        private List<string> passwords;
        private Random random;

        public string CurrentPassword { get; private set; }

        public Answer(List<string> passwords)
        {
            this.passwords = passwords;
            random = new Random();
            SetRandomPassword();
        }

        public void SetRandomPassword()
        {
            if (passwords.Count > 0)
            {
                int index = random.Next(passwords.Count);
                CurrentPassword = passwords[index];
            }
            else
            {
                CurrentPassword = "admin";
            }
        }
    }

}

namespace LabirintGame
{
    public class PasswordLoader
    {
        private string filename;
        private List<string> passwords;

        public PasswordLoader(string filename)
        {
            this.filename = filename;
            passwords = new List<string>();
        }

        public List<string> LoadPasswords()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        passwords.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd podczas wczytywania haseł z pliku: " + e.Message);
            }

            return passwords;
        }
    }
}
namespace LabirintGame
{
    public class WordListLoader
    {
        private List<string> wordList = new List<string>();
        private string filepath;

        public WordListLoader(string filePath)
        {
            this.filepath = filePath;
        }

        public List<string> LoadWords()
        {

            try
            {
                // Sprawdź, czy plik istnieje
                if (File.Exists(filepath))
                {
                    // Odczytaj wszystkie wiersze z pliku
                    string[] lines = File.ReadAllLines(filepath);

                    foreach (string line in lines)
                    {
                        // Dodaj każde słowo (oddzielone białymi znakami) do listy
                        string[] wordsInLine = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        wordList.AddRange(wordsInLine);
                    }

                    Console.WriteLine($"Wczytano {wordList.Count} słów z pliku.");
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas wczytywania pliku: {ex.Message}");
            }

            return wordList;
        }
    }
}

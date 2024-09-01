namespace laboration
{
    public class FileServiceSystem
    {
        private const string FilePath = "result.txt";

        public void SaveResult(string playerName, int attempts)
        {
            using (var writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine($"{playerName}#&#{attempts}");
            }
        }

        public List<PlayerData> LoadResults()
        {
            var results = new List<PlayerData>();

            if (!File.Exists(FilePath)) return results;

            using (var reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(new[] { "#&#" }, StringSplitOptions.None);
                    var name = data[0];
                    var guesses = int.Parse(data[1]);
                    var playerData = results.Find(p => p.Name == name);

                    if (playerData == null)
                    {
                        results.Add(new PlayerData(name, guesses));
                    }
                    else
                    {
                        playerData.Update(guesses);
                    }
                }
            }

            return results;
        }
    }
}
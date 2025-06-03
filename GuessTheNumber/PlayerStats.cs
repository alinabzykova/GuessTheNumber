using System.IO;
using Newtonsoft.Json;

namespace GuessTheNumber
{
    public class PlayerStats
    {
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int TotalAttempts { get; set; }

        private const string FilePath = "stats.json";

        public static PlayerStats Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<PlayerStats>(json);
            }
            return new PlayerStats();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(FilePath, json);
        }

        public void Update(int attempts)
        {
            GamesPlayed++;
            GamesWon++;
            TotalAttempts += attempts;
        }
    }
}

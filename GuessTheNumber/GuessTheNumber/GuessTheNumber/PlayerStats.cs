using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;


namespace GuessTheNumber
{
    public class PlayerStats
    {
        public string UserName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int TotalAttempts { get; set; }
        public int BestScore { get; set; } = int.MaxValue;

        private const string StatsFolder = "stats"; 

        public static PlayerStats Load(string userName)
        {
            if (!Directory.Exists(StatsFolder))
                Directory.CreateDirectory(StatsFolder);

            string path = Path.Combine(StatsFolder, $"{userName}.json");

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<PlayerStats>(json);
            }

            return new PlayerStats { UserName = userName };
        }

        public void Save(string userName)
        {
            if (!Directory.Exists(StatsFolder))
                Directory.CreateDirectory(StatsFolder);

            string path = Path.Combine(StatsFolder, $"{userName}.json");
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public void Update(int attempts)
        {
            GamesPlayed++;
            GamesWon++;
            TotalAttempts += attempts;
            if (attempts < BestScore)
                BestScore = attempts;
        }

        public static List<PlayerStats> LoadAllStats()
        {
            if (!Directory.Exists(StatsFolder))
                return new List<PlayerStats>();

            List<PlayerStats> list = new List<PlayerStats>();
            foreach (var file in Directory.GetFiles(StatsFolder, "*.json"))
            {
                string json = File.ReadAllText(file);
                var stats = JsonConvert.DeserializeObject<PlayerStats>(json);
                if (stats != null) list.Add(stats);
            }

            return list;
        }

        public static List<PlayerStats> GetTopPlayers(int topN = 5)
        {
            return LoadAllStats()
                .Where(p => p.BestScore < int.MaxValue)
                .OrderBy(p => p.BestScore)
                .Take(topN)
                .ToList();
        }
    }
}

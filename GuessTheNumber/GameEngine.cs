using System;

namespace GuessTheNumber
{
    public class GameEngine
    {
        private int secretNumber;
        public int Attempts { get; private set; }

        public void StartNewGame()
        {
            Random rnd = new Random();
            secretNumber = rnd.Next(1, 101);
            Attempts = 0;
        }

        public string CheckGuess(int guess)
        {
            Attempts++;
            if (guess < secretNumber) return "Больше";
            if (guess > secretNumber) return "Меньше";
            return "Угадал";
        }
    }
}

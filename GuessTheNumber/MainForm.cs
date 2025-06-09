using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheNumber
{
    public partial class MainForm : Form
    {
        private GameEngine engine = new GameEngine();
        private PlayerStats stats;
        private string userName;

        public MainForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;

            stats = PlayerStats.Load(userName);

            this.Text = $"Угадай число — {userName}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            engine.StartNewGame();
            resultLabel.Text = "";
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(inputBox.Text, out int guess))
            {
                if (guess < 1 || guess > 100)
                {
                    MessageBox.Show("Введите число от 1 до 100!");
                    return;
                }

                string result = engine.CheckGuess(guess);
                resultLabel.Text = result;

                if (result == "Угадал")
                {
                    stats.Update(engine.Attempts);
                    stats.Save(userName);

                    ResultForm rf = new ResultForm(engine.Attempts, stats);
                    rf.ShowDialog();

                    engine.StartNewGame();
                    inputBox.Clear();
                    resultLabel.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Введите целое число!");
            }
        }
    }
}

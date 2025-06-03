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
        GameEngine engine = new GameEngine();
        PlayerStats stats = PlayerStats.Load();

        public MainForm()
        {
            InitializeComponent();
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
                string result = engine.CheckGuess(guess);
                resultLabel.Text = result;

                if (result == "Угадал")
                {
                    stats.Update(engine.Attempts);
                    stats.Save();

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

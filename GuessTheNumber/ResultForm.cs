using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheNumber
{
    public partial class ResultForm : Form
    {
        public ResultForm(int attempts, PlayerStats stats)
        {
            InitializeComponent();
            label1.Text = $"Вы угадали за {attempts} попыток!";
            label2.Text = $"Всего игр: {stats.GamesPlayed}, Побед: {stats.GamesWon}, Попыток: {stats.TotalAttempts}";
        }
        public ResultForm()
        {
            InitializeComponent();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

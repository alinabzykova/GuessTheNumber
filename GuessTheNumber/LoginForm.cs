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
    public partial class LoginForm: Form
    {
        public string UserName { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text))
            {
                UserName = nameBox.Text.Trim();        
                DialogResult = DialogResult.OK;         
                Close();                               
            }
            else
            {
                MessageBox.Show("Введите ник!");
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            nameBox.Focus();
        }
    }
}

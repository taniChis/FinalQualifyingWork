using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace ДП
{
    public partial class Authorization : Form
    {
        ForSQL forSQL = new ForSQL();
        private bool see = true;
        public Authorization()
        {
            InitializeComponent();
        }
        private void Авторизация_Load(object sender, EventArgs e)
        {
            buttonEnter.Enabled = false;
            textBoxPassword.UseSystemPasswordChar = see;
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = PasswordHashing.hashPassword(textBoxPassword.Text);
            var PI = new PersonalData();
            if (PI.SetPersonalData(login, password))
            {
                MessageBox.Show("Вы успешно зашли!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainMenu mainMenu = new MainMenu();
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
                this.Hide();
                mainMenu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Логин и/или пароль неправильный. Попробуйте еще раз.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
            }
        }
        private void buttonSee_Click(object sender, EventArgs e)
        {
            see = !see;
            textBoxPassword.UseSystemPasswordChar = see;
            if (see) buttonSee.Image = Properties.Resources.показать;
            else buttonSee.Image = Properties.Resources.скрыть;
        }
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0) buttonEnter.Enabled = true;
            else buttonEnter.Enabled = false;
        }
        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

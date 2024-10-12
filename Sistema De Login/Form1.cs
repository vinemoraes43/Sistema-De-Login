using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sistema_De_Login
{
    public partial class Form1 : Form
    {

        private string correctUsername = "admin";
        private string correctPassword = "12345";

        public Form1()
        {
            InitializeComponent();

            tbUsername.KeyDown += new KeyEventHandler(tbUsername_KeyDown);
            tbPassword.KeyDown += new KeyEventHandler(tbUsername_KeyDown);

        }

        // Keydown entre os textos de username e de password e para ir direito
        // no botão de login

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                e.SuppressKeyPress = true;

                if (sender == tbUsername)
                {

                    if (!string.IsNullOrWhiteSpace(tbUsername.Text))
                    {
                        tbPassword.Focus();
                    }
                    else
                    {
                        MessageBox.Show("O campo de username não pode estar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else if (sender == tbPassword)
                {
                    btLogar.PerformClick();
                }

            }

            if(e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                if (sender == tbUsername)
                {
                    tbPassword.Focus();
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;

                if (sender == tbPassword)
                {
                    tbUsername.Focus();
                }
            }


        }

        private void btLogar_Click_1(object sender, EventArgs e)
        {
            // verificação do login

            string username = tbUsername.Text;
            string password = tbPassword.Text;

            bool loginSuccess = ValidateLogin(username, password);

            if (loginSuccess)
            {
                lbMensagemErro.Visible = false;

                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                lbMensagemErro.Text = "Usuário ou senha incorretos!";
                lbMensagemErro.ForeColor = System.Drawing.Color.Red;
                lbMensagemErro.Visible = true;

            }
        }

        private bool ValidateLogin(string username, string password) 
        {
            string correctUsername = "admin";
            string correctPassword = "12345";

            return username == correctUsername && password == correctPassword;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

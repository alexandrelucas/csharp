using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameRoom_test
{
    public partial class FrmLogin : Form
    {
        DbConnect dbConnect = new DbConnect();
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.txtUsername.Text = "lucasbacon";
            this.txtPw.Text = "luc4scunh4";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!User.islogged)
            {
                if(Application.OpenForms.Count == 0)
                Application.Exit();
            }
        }

        private void txtPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }
        private void Login()
        {
            bool logged = dbConnect.Login(txtUsername.Text, txtPw.Text);

            if (logged)
            {
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                this.Close();

            }
            else
                MessageBox.Show("Não foi possível efetuar o login.", "Game Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            Login();
        }
    }
}

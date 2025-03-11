using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_facturación
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pboxLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pboxLogIn_Click(object sender, EventArgs e)
        {
            Menu_principal form = new Menu_principal();
            form.Show();
        }

        private void pboxLogIn_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}

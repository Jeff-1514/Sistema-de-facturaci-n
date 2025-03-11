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

namespace Sistema_de_facturación
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Menu_principal form = new Menu_principal();
            form.Show();
            this.Close();
        }

        private void txtboxCodU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxNombreU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxClaveU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxPrecioU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxConClaveU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCelularU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCorreoU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxBuscarU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxTotalU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnNuevoU_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }

                if (ctrl is ComboBox)
                {
                    ctrl.Text = "";
                }
                this.NombreU.Focus();

                Conexion.conectar();
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(Cod_Usu as int)),0) +1 from Usuario", Conexion.conectar());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                CodigoU.Text = dt.Rows[0][0].ToString();
            }
        }
        public DataTable actualizarusuario()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Usuario order by Cod_Usu desc";
            SqlCommand cmd = new SqlCommand(query, Conexion.conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnGuardarU_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            string insert = "INSERT INTO Usuario(Cod_Usu,Nom_Usu, Cla_Usu, Cel_Usu, Cor_Usu) " +
                "VALUES (@Cod_Usu,@Nom_Usu, @Cla_Usu, @Cel_Usu, @Cor_Usu)";

            SqlCommand cmd = new SqlCommand(insert, Conexion.conectar());
            cmd.Parameters.AddWithValue("@Cod_Usu", int.Parse(CodigoU.Text));
            cmd.Parameters.AddWithValue("@Nom_Usu", NombreU.Text);
            cmd.Parameters.AddWithValue("@Cla_Usu", ClaveU.Text);
            cmd.Parameters.AddWithValue("@Cel_Usu", CelularU.Text);
            cmd.Parameters.AddWithValue("@Cor_Usu", CorreoU.Text);

            cmd.ExecuteNonQuery();
            DgvUsuario.DataSource = actualizarusuario();

            MessageBox.Show("Datos agregados con exito");
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataSet.Usuario' Puede moverla o quitarla según sea necesario.
            this.usuarioTableAdapter.Fill(this.facturacionDataSet.Usuario);

        }
    }
}

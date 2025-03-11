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
    public partial class Articulo : Form
    {
        public Articulo()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataSet.Articulo' Puede moverla o quitarla según sea necesario.
            this.articuloTableAdapter.Fill(this.facturacionDataSet.Articulo);
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.facturacionDataSet.Cliente);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            Menu_principal form = new Menu_principal();
            form.Show();
            this.Close();
        }

        private void txtboxCodA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxDesA_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxDesA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCostoA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxPrecioA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCantidadA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxExistenciaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCanMinimaA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxBuscarA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxTotalA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnNuevoA_Click(object sender, EventArgs e)
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
                this.DescripcionA.Focus();

                Conexion.conectar();
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(Cod_Art as int)),0) +1 from Articulo", Conexion.conectar());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                CodigoA.Text = dt.Rows[0][0].ToString();
            }
        }
        public DataTable actualizararticulos()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Articulo order by Cod_Art desc";
            SqlCommand cmd = new SqlCommand(query, Conexion.conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnGuardarA_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            string insert = "INSERT INTO Articulo(Cod_Art,Des_Art,Cos_Art,Pre_Art,Exi_Art,Can_Min) " +
                "VALUES (@Cod_Art,@Des_Art,@Cos_Art,@Pre_Art,@Exi_Art,@Can_Min)";

            SqlCommand cmd = new SqlCommand(insert, Conexion.conectar());
            cmd.Parameters.AddWithValue("@Cod_Art",CodigoA.Text);
            cmd.Parameters.AddWithValue("@Des_Art",DescripcionA.Text);
            cmd.Parameters.AddWithValue("@Cos_Art",CostoA.Text);
            cmd.Parameters.AddWithValue("@Pre_Art",PrecioA.Text);
            cmd.Parameters.AddWithValue("@Exi_Art",ExistenciaA.Text);
            cmd.Parameters.AddWithValue("@Can_Min",CanMinimaA.Text);

            cmd.ExecuteNonQuery();
            DgvArticulos.DataSource = actualizararticulos();

            MessageBox.Show("Datos agregados con exito");
        }
    }
}

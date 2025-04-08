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
    public partial class facturacion : Form
    {
        public facturacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void facturacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataSet.Temdetallefactura' Puede moverla o quitarla según sea necesario.
            this.temdetallefacturaTableAdapter.Fill(this.facturacionDataSet.Temdetallefactura);

            Articulo.Enabled = false;
            DescripcionF.Enabled = false;
            Precio.Enabled = false;
            Cantidad.Enabled = false;
            Subtotal1.Enabled = false;
            btnGuardarF.Enabled = false;
            btnImprimirF.Enabled = false;
            Descuento1.Text = "0";
            txtboxDesc2.Text = "0";
            Itbis1.Text = "0";
            txtboxItbis2.Text = "0";
            Eliminar_Grid();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Menu_principal form = new Menu_principal();
            form.Show();
            this.Close();
        }

        private void txtboxNoFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCliente_TextChanged(object sender, EventArgs e)
        {

        }
        //Buscar Cliente de la DataBase
        private void txtboxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                using (SqlConnection  conn = Conexion.Conectar())
                {
                    try
                    {
                        conn.Open();
                        string query = "select * from Cliente where Cod_Cli = @codigo";
                        using (SqlCommand comando = new SqlCommand(query,conn))
                        {
                            comando.Parameters.AddWithValue("@codigo", Cliente.Text.Trim());
                            using (SqlDataReader leer = comando.ExecuteReader())
                            {
                                if (leer.Read() == true)
                                {
                                    Nombre.Text = leer["Nom_Cli"].ToString();
                                }
                                else
                                {
                                    btnGuardarF.Enabled = false;
                                    MessageBox.Show("Registro no encontrado");

                                    foreach (Control ctrl in Controls)
                                    {
                                        if (ctrl is TextBox)
                                        {
                                            ctrl.Text = "";
                                        }
                                        if (ctrl is ComboBox)
                                        {
                                            ctrl.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void txtboxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        //Mostrar articulo de la base de datos
        private void txtboxArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                using (SqlConnection conn = Conexion.Conectar())
                {
                    try
                    {
                        conn.Open();
                        string query = "select * from Articulo where Cod_Art = @codigo";
                        using (SqlCommand comando = new SqlCommand(query, conn))
                        {
                            comando.Parameters.AddWithValue("@codigo", Articulo.Text.Trim());
                            using (SqlDataReader leer = comando.ExecuteReader())
                            {
                                if (leer.Read() == true)
                                {
                                    DescripcionF.Text = leer["Des_Art"].ToString();
                                    Precio.Text = leer["Pre_Art"].ToString();
                                }
                                else
                                {
                                    btnGuardarF.Enabled = false;
                                    MessageBox.Show("Registro no encontrado");

                                    foreach (Control ctrl in Controls)
                                    {
                                        if (ctrl is TextBox)
                                        {
                                            ctrl.Text = "";
                                        }
                                        if (ctrl is ComboBox)
                                        {
                                            ctrl.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void txtboxDesF_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxDesF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        //Actualizar DataGridView
        public DataTable llenardgvDF()
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                conn.Open();
                DataTable dt = new DataTable();
                string query = "Select * from temdetallefactura order by cod_art desc";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter Da = new SqlDataAdapter(comando))
                    {
                        Da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void txtboxCan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Calcular el subtotal 
            if (e.KeyChar == (char)(Keys.Enter))
            {

                if (string.IsNullOrWhiteSpace(NoFactura.Text) ||
                string.IsNullOrWhiteSpace(Articulo.Text) ||
                string.IsNullOrWhiteSpace(DescripcionF.Text) ||
                string.IsNullOrWhiteSpace(Cantidad.Text) ||
                string.IsNullOrWhiteSpace(Precio.Text))
                {
                    MessageBox.Show("Todos los campos deben estar llenos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                decimal pre = Convert.ToDecimal(Precio.Text);
                decimal can = Convert.ToDecimal(Cantidad.Text);

                decimal Subtotal = pre * can;
                Subtotal1.Text = Subtotal.ToString();

                //guardar de manera temporal en los detalles de factura y mostrar en DataGridView
                string query = "insert into Temdetallefactura (num_fac,cod_art,des_art,can_art,pre_art,sub_tot) values (@num_fac,@cod_art,@des_art,@can_art,@pre_art,@sub_tot)";
                using (SqlConnection conn = Conexion.Conectar())
                {
                    conn.Open();
                    using (SqlCommand comando = new SqlCommand(query, conn))
                    {
                        comando.Parameters.AddWithValue("@num_fac",NoFactura.Text);
                        comando.Parameters.AddWithValue("@cod_art",Articulo.Text);
                        comando.Parameters.AddWithValue("@des_art",DescripcionF.Text.Trim());
                        comando.Parameters.AddWithValue("@can_art",Cantidad.Text);
                        comando.Parameters.AddWithValue("@pre_art",Precio.Text);
                        comando.Parameters.AddWithValue("@sub_tot",Subtotal1.Text);
                        comando.ExecuteNonQuery();
                    }   
                }
                DgvFacturacion.DataSource = llenardgvDF();
                //Guardar en los detalles de factura
                query = "insert into Detallefactura (num_fac,cod_art,des_art,can_art,pre_art,sub_tot) values (@num_fac,@cod_art,@des_art,@can_art,@pre_art,@sub_tot)";

                using (SqlConnection conn = Conexion.Conectar())
                {
                    conn.Open();
                    using (SqlCommand comando = new SqlCommand(query, conn))
                    {
                        comando.Parameters.AddWithValue("@num_fac", NoFactura.Text.Trim());
                        comando.Parameters.AddWithValue("@cod_art", Articulo.Text.Trim());
                        comando.Parameters.AddWithValue("@des_art", DescripcionF.Text.Trim());
                        comando.Parameters.AddWithValue("@can_art", Cantidad.Text.Trim());
                        comando.Parameters.AddWithValue("@pre_art", Precio.Text.Trim());
                        comando.Parameters.AddWithValue("@sub_tot", Subtotal1.Text.Trim());
                        comando.ExecuteNonQuery();
                    }
                }
                //Disminuir el inventario 
                using (SqlConnection conn = Conexion.Conectar())
                {
                    string query1 = "UPDATE Articulo SET Exi_Art = Exi_Art - @existencia WHERE cod_art = @cod_art";
                    conn.Open();
                    using (SqlCommand comando = new SqlCommand(query1, conn))
                    {
                        comando.Parameters.AddWithValue("@existencia",Cantidad.Text);
                        comando.Parameters.AddWithValue("@cod_art",Articulo.Text);
                        comando.ExecuteNonQuery();
                    }
                }
                //sumar la columna subtotal
                double stf = 0;
                foreach (DataGridViewRow row in DgvFacturacion.Rows)
                    stf += Convert.ToDouble(row.Cells["sub_tot"].Value);
                Subtotal2.Text = Convert.ToString(stf);

                //sumar subtotal a total a pagar 
                double tap = 0;
                foreach (DataGridViewRow row in DgvFacturacion.Rows)
                    tap += Convert.ToDouble(row.Cells["sub_tot"].Value);
                TotalPagar.Text = Convert.ToString(tap);

                //limpiar textbox 
                Articulo.Text = "";
                DescripcionF.Text = "";
                Cantidad.Text = "";
                Precio.Text = "";
                Subtotal1.Text = "";

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSubtotal1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxSubtotal2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxDesc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                decimal descuentoA = 0;
                decimal DescuentoF = 0;
                decimal subt = 0;
                decimal itb = 0;
                decimal TotalF = 0;
                subt = Convert.ToDecimal(Subtotal2.Text);
                descuentoA = Convert.ToDecimal(Descuento1.Text);
                itb = Convert.ToDecimal(Itbis1.Text);
                DescuentoF = subt * (descuentoA / 100);
                txtboxDesc2.Text = DescuentoF.ToString();
                TotalF = (subt - DescuentoF) + itb;
                TotalPagar.Text = TotalF.ToString();

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        private void txtboxItbis1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                decimal pitb = 0;
                decimal iaf = 0;
                decimal daaf = 0;
                decimal stf = 0;
                decimal tif = 0;
                decimal tf = 0;
                decimal stnf = 0;

                daaf = Convert.ToDecimal(txtboxDesc2.Text);
                stf = Convert.ToDecimal(Subtotal2.Text);
                pitb = Convert.ToDecimal(Itbis1.Text);
                iaf = stf - daaf;
                tif = iaf * (pitb / 100);
                txtboxItbis2.Text = tif.ToString();
                stnf = stf - daaf;
                tf = stnf + tif;
                TotalPagar.Text = tf.ToString();

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        private void cmbBoxTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxTotalP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        //eliminar tabla temporal 

        public DataTable Eliminar_Grid()
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                conn.Open();
                DataTable dt = new DataTable();
                string query = "Delete Temdetallefactura";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        //Boton nuevo
        private void btnNuevoF_Click(object sender, EventArgs e)
        {
            Articulo.Enabled = true;
            DescripcionF.Enabled = true;
            Precio.Enabled = true;
            Cantidad.Enabled = true;
            Subtotal1.Enabled = true;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
                Descuento1.Text = "0";
                txtboxDesc2.Text = "0";
                Itbis1.Text = "0";
                txtboxItbis2.Text = "0";

                using (SqlConnection conn = Conexion.Conectar())
                {
                    conn.Open();
                    string query = "select isnull(max(cast(num_fac as int)),0) +1 from factura";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    NoFactura.Text = dt.Rows[0][0].ToString();
                    TipoFactura.Text = "Efectivo";
                    Cliente.Text = "1";
                    Nombre.Text = "Generico";
                    Articulo.Focus();
                    timer.Enabled = true;

                    btnGuardarF.Enabled = true;
                    btnImprimirF.Enabled = true;


                }
                Eliminar_Grid();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToString("hh:mm:ss");
            Fecha.Text = DateTime.Now.ToShortDateString();
        }
        //btnBuscar Cliente
        private void btnBuscarC_Click(object sender, EventArgs e)
        {
            Cliente form = new Cliente();
            form.Show();
        }
        //btnBuscar articulo
        private void btnBuscarA_Click(object sender, EventArgs e)
        {
            Articulo form = new Articulo();
            form.Show();
        }

        private void Articulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarF_Click(object sender, EventArgs e)
        {
            if  (Subtotal2.Text == string.Empty)
            {
                MessageBox.Show("No hay factura para procesar");
                Articulo.Focus();
            }
            //guardar 
            else
            {
                using (SqlConnection conn = Conexion.Conectar())
                {
                    conn.Open();
                    string query = "insert into Factura (num_fac, tipo_fac, fec_fac, hor_fac, cod_cli, nom_cli, des_fac, itb_fac, tot_fac, pdf_fac, pit_fac) values (@num_fac, @tipo_fac, @fec_fac, @hor_fac, @cod_cli, @nom_cli, @des_fac, @itb_fac, @tot_fac, @pdf_fac, @pit_fac)";
                    using (SqlCommand comando = new SqlCommand(query,conn))
                    {
                        comando.Parameters.AddWithValue("@num_fac",Convert.ToInt32(NoFactura.Text));
                        comando.Parameters.AddWithValue("@tipo_fac",TipoFactura.Text);
                        comando.Parameters.AddWithValue("@fec_fac",Fecha.Text);
                        comando.Parameters.AddWithValue("@hor_fac",Hora.Text);
                        comando.Parameters.AddWithValue("@cod_cli", Convert.ToInt32(Cliente.Text));
                        comando.Parameters.AddWithValue("@nom_cli",Nombre.Text);
                        //comando.Parameters.AddWithValue("@sub_tot_fac",Convert.ToDecimal(Subtotal1.Text));
                        comando.Parameters.AddWithValue("@des_fac", Convert.ToDecimal(Descuento1.Text));
                        comando.Parameters.AddWithValue("@itb_fac", Convert.ToDecimal(Itbis1.Text));
                        comando.Parameters.AddWithValue("@tot_fac", Convert.ToDecimal(TotalPagar.Text));
                        comando.Parameters.AddWithValue("@pdf_fac", Convert.ToDecimal(txtboxDesc2.Text));
                        comando.Parameters.AddWithValue("@pit_fac", Convert.ToDecimal(txtboxItbis2.Text));

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro Agregado");

                        
                    }
                }
            }
        }

        private void btnImprimirF_Click(object sender, EventArgs e)
        {
            V3P fn = new V3P();
            fn.numero.Text = this.NoFactura.Text;
            fn.ShowDialog();
        }
    }
}

﻿using System;
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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.facturacionDataSet.Cliente);
            // TODO: esta línea de código carga datos en la tabla 'facturacionDataSet.Articulo' Puede moverla o quitarla según sea necesario.
            this.articuloTableAdapter.Fill(this.facturacionDataSet.Articulo);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Menu_principal form = new Menu_principal();
            form.Show();
            Close();
        }

        private void txtboxSectorC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxCodC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                Conexion.conectar();
                string query1 = "SELECT * FROM Cliente WHERE Cod_Cli = " + CodigoC + "";
                SqlCommand cmd = new SqlCommand(query1, Conexion.conectar());

                SqlDataReader leer = cmd.ExecuteReader();
                
                    if (leer.Read() == true)
                    {
                        NombreC.Text = leer["Nom_Cli"].ToString();
                        ApellidoC.Text = leer["Ape_cli"].ToString();
                        DireccionC.Text = leer["Dir_Cli"].ToString();
                        SectorC.Text = leer["Sec_Cli"].ToString();
                        ProvinciaC.Text = leer["Pro_Cli"].ToString();
                        ContactoC.Text = leer["Con_Cli"].ToString();
                        CorreoC.Text = leer["Cor_Cli"].ToString();
                        btnGuardarC.Enabled = false;
                    }
                    else
                    {
                        btnGuardarC.Enabled = false;
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
                        e.Handled = true;
                        SendKeys.Send("{TAB}");
                    } 
            }
        }

        private void txtboxNombreC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxDirC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxSectorC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbBoxProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCelularC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxCorreoC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxBuscarC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtboxTotalC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevoC_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }

                if (ctrl is ComboBox)
                {
                    ctrl.Text = "";
                }
                this.NombreC.Focus();

                Conexion.conectar();
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(Cod_Cli as int)),0) +1 from Cliente", Conexion.conectar());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                CodigoC.Text = dt.Rows[0][0].ToString();
            }


        }

        public DataTable actualizarclientes()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Cliente order by Cod_Cli desc";
            SqlCommand cmd = new SqlCommand(query, Conexion.conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }   

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            string insert = "INSERT INTO Cliente(Cod_Cli, Nom_Cli, Ape_cli, Dir_Cli, Sec_Cli, Pro_Cli, Con_Cli, Cor_Cli) " +
                "VALUES (@Cod_Cli, @Nom_Cli, @Ape_cli, @Dir_Cli, @Sec_Cli, @Pro_Cli, @Con_Cli, @Cor_Cli)";
            
            SqlCommand cmd = new SqlCommand(insert, Conexion.conectar());
            cmd.Parameters.AddWithValue("@Cod_Cli",int.Parse(CodigoC.Text));
            cmd.Parameters.AddWithValue("@Nom_Cli",NombreC.Text);
            cmd.Parameters.AddWithValue("@Ape_cli",ApellidoC.Text);
            cmd.Parameters.AddWithValue("@Dir_Cli",DireccionC.Text);
            cmd.Parameters.AddWithValue("@Sec_Cli",SectorC.Text);
            cmd.Parameters.AddWithValue("@Pro_Cli",ProvinciaC.Text);
            cmd.Parameters.AddWithValue("@Con_Cli",ContactoC.Text);
            cmd.Parameters.AddWithValue("@Cor_Cli",CorreoC.Text);

            cmd.ExecuteNonQuery();
            DgvCliente.DataSource = actualizarclientes();

            MessageBox.Show("Datos agregados con exito");
        }

        private void txtboxCodC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

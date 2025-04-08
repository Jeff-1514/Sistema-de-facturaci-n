using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_facturación
{
    public partial class V3P : Form
    {
        public V3P()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                conn.Open();
                DataTable dt = new DataTable();
                string query = "select * from Ventas where num_fac = @numero";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@numero", numero.Text);
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        adt.Fill(dt);
                    }
                }
                ReportDocument reporte = CRVP.ReportSource as ReportDocument;
                reporte.SetDataSource(dt);
                CRVP.Refresh();
            }

        }
    }
}

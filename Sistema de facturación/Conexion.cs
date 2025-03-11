using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistema_de_facturación
{
    class Conexion
    {
        public static SqlConnection conectar ()
        {
            SqlConnection conect = new SqlConnection("SERVER= JEFFERSON\\SQLEXPRESS; DATABASE= Facturacion; Integrated security= true");
            conect.Open();
            return conect; 
        }
    }
}

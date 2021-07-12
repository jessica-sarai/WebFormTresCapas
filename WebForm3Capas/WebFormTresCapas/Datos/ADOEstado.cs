using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ADOEstado
    {
        private string _conexion;
        public ADOEstado()
        {
            _conexion = ConfigurationManager.ConnectionStrings["AlumnosTich"].ConnectionString;
        }

        public List<Estado> consultarEstado()
        {
            List<Estado> lstEstado = new List<Estado>();
            string query = "select id, nombre from Estados";
            try
            {
                using (SqlConnection con =new SqlConnection(_conexion))
                {
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Estado estado = new Estado();
                        estado.id = Convert.ToInt32(read["id"]);
                        estado.nombre =Convert.ToString(read["nombre"]);
                        lstEstado.Add(estado);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultatr Estado", ex);
            }
            return lstEstado;
        }

    }
}

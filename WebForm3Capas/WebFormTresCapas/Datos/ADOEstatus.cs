using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ADOEstatus
    {
        private string _conexion;
        public ADOEstatus()
        {
            _conexion = ConfigurationManager.ConnectionStrings["AlumnosTich"].ConnectionString;
        }

        public List<Estatus> consultarEstatus()
        {
            List<Estatus> lstEstatus = new List<Estatus>();
            string query = "select id, clave, nombre from EstatusAlumnos";
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Estatus estatusAlum = new Estatus();
                        estatusAlum.id = Convert.ToInt32(rd["id"]);
                        estatusAlum.clave = Convert.ToString(rd["clave"]);
                        estatusAlum.nombre = Convert.ToString(rd["nombre"]);
                        lstEstatus.Add(estatusAlum);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar", ex);
            }
            return lstEstatus;
        }

        public void agregarEstatus(string clave, string nombre)
        {
            List<Estatus> lstAgregar = new List<Estatus>();
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarEstatus", con);
                    Estatus estatusAlumnos = new Estatus();

                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar un nuevo Estatus", ex);
            }

        }

        public void actualizarEstatus(int id, string clave, string nombre)
        {
            List<Estatus> _lista = consultarEstatus();
            Estatus Obest = _lista.Find(li => li.id == id);
            if (clave == "")
            {
                clave = Obest.clave;
            }
            else if (nombre == "")
            {
                nombre = Obest.nombre;
            }
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    SqlCommand cmd = new SqlCommand("SP_ActualizarEstatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar", ex);
            }

        }

        public void eliminarEstatus(int id)
        {
            List<Estatus> lstEstatus = new List<Estatus>();
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    SqlCommand cmd = new SqlCommand("delete from EstatusAlumnos where id=" + id, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar registro", ex);
            }

        }

    }
}

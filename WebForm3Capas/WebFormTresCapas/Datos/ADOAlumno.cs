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
using Datos.WS_Alumno;

namespace Datos
{
    public class ADOAlumno
    {
        private string _conecion;
        WS_Alumno.WS_Alumno ws = new WS_Alumno.WS_Alumno();
        public ADOAlumno()
        {
            _conecion=ConfigurationManager.ConnectionStrings["AlumnosTich"].ConnectionString;
        }

        public List< AlumnoX> consultarTodosAlumnoLinq()
        {
            List<Alumno> lstAlumno = new List<Alumno>();
            List<Estado> lstEstado = new List<Estado>();
            List<Estatus> lstEstatus = new List<Estatus>();
            var innerAl =
                from Alumno a in lstAlumno
                join Estado e in lstEstado on a.idEstatus equals e.id
                join Estatus esa in lstEstatus on a.idEstatus equals esa.id
                select new AlumnoX { id = a.id, 
                                     nombre = a.nombre, 
                                     primerApellido= a.primerApellido, 
                                     segundoApellido= a.segundoApellido,
                                     correo= a.correo,
                                     fechaNacimiento= a.fechaNacimiento, 
                                     telefono=a.telefono,
                                     curp=a.curp, 
                                     estado=e.nombre, 
                                     estatus=esa.nombre};

            return innerAl.ToList<AlumnoX>();
        }

        public List<AlumnoX> consultarUnAlumnoLinq(int idL)
        {
            List<Alumno> lstAlumno = new List<Alumno>();
            List<Estado> lstEstado = new List<Estado>();
            List<Estatus> lstEstatus = new List<Estatus>();
            var innerAl =
                from Alumno a in lstAlumno
                join Estado e in lstEstado on a.idEstatus equals e.id
                join Estatus esa in lstEstatus on a.idEstatus equals esa.id
                where  a.id==idL
                select new AlumnoX
                {
                    id = a.id,
                    nombre = a.nombre,
                    primerApellido = a.primerApellido,
                    segundoApellido = a.segundoApellido,
                    correo = a.correo,
                    fechaNacimiento = a.fechaNacimiento,
                    telefono = a.telefono,
                    curp = a.curp,
                    estado = e.nombre,
                    estatus = esa.nombre
                };
            return innerAl.ToList<AlumnoX>();
        }

        public List<Alumno> consultarAlumno()
        {
            List<Alumno> lstAlumno = new List<Alumno>();           

            try
            {
                using (SqlConnection con = new SqlConnection(_conecion))
                {
                    SqlCommand cmd = new SqlCommand("Sp_VistaAlumnos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Alumno alumno = new Alumno();
                        Estado estado = new Estado();
                        Estatus estatus = new Estatus();
                        alumno.id = Convert.ToInt32(read["id"]);
                        alumno.nombre = Convert.ToString(read["nombre"]);
                        alumno.primerApellido = Convert.ToString(read["primerApellido"]);
                        alumno.segundoApellido = Convert.ToString(read["segundoApellido"]);
                        alumno.correo = Convert.ToString(read["correo"]);
                        alumno.fechaNacimiento = Convert.ToString(read["fechaNacimiento"]);
                        alumno.telefono = Convert.ToString(read["telefono"]);
                        alumno.curp = Convert.ToString(read["curp"]);
                        alumno.estado = Convert.ToString(read["estado"]);
                        alumno.estatus = Convert.ToString(read["estatus"]);
                        lstAlumno.Add(alumno);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Alumno",ex);
            }
            return lstAlumno;
        }

        public List<Alumno> consultarAlumno2()
        {
            List<Alumno> lstAlumno = new List<Alumno>();

            try
            {
                using (SqlConnection con = new SqlConnection(_conecion))
                {
                    SqlCommand cmd = new SqlCommand("SP_TodosAlumnos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Alumno alumno = new Alumno();
                        Estado estado = new Estado();
                        Estatus estatus = new Estatus();
                        alumno.id = Convert.ToInt32(read["id"]);
                        alumno.nombre = Convert.ToString(read["nombre"]);
                        alumno.primerApellido = Convert.ToString(read["primerApellido"]);
                        alumno.segundoApellido = Convert.ToString(read["segundoApellido"]);
                        alumno.correo = Convert.ToString(read["correo"]);
                        alumno.fechaNacimiento = Convert.ToString(read["fechaNacimiento"]);
                        alumno.telefono = Convert.ToString(read["telefono"]);
                        alumno.curp = Convert.ToString(read["curp"]);
                        alumno.idEstadoOrigen = Convert.ToInt32(read["idEstadoOrigen"]);
                        alumno.idEstatus = Convert.ToInt32(read["idEStatus"]);
                        lstAlumno.Add(alumno);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Alumno", ex);
            }
            return lstAlumno;
        }

        public List<Alumno> consultarUnAlumno()
        {
            List<Alumno> lstAlumno = new List<Alumno>();
            try
            {
                using (SqlConnection con =new SqlConnection(_conecion))
                {
                    SqlCommand cmd = new SqlCommand("SP_ConsultarUnAlumno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.id = Convert.ToInt32(read["id"]);
                        alumno.nombre = Convert.ToString(read["nombre"]);
                        alumno.primerApellido = Convert.ToString(read["primerApellido"]);
                        alumno.segundoApellido = Convert.ToString(read["segundoApellido"]);
                        alumno.correo = Convert.ToString(read["correo"]);
                        alumno.fechaNacimiento = Convert.ToString(read["fechaNacimiento"]);
                        alumno.telefono = Convert.ToString(read["telefono"]);
                        alumno.curp = Convert.ToString(read["curp"]);
                        alumno.estado = Convert.ToString(read["nombre"]);
                        alumno.estatus = Convert.ToString(read["nombre"]);
                        lstAlumno.Add(alumno);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar un ALumno", ex);
            }
            return lstAlumno;
        }

        public void agregarAlumno(string nombre, string primerApellido, string segundoApellido, string correo, string telefono, string fechaNacimiento, string curp, int idEstadoOrigen,int idEstatus)
        {
            try
            {
                using (SqlConnection con =new SqlConnection(_conecion))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarAlumnos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@nombre",nombre);
                    cmd.Parameters.AddWithValue("@primerApellido", primerApellido);
                    cmd.Parameters.AddWithValue("@segundoApellido", segundoApellido);
                    cmd.Parameters.AddWithValue("@correo",correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@fechaNacimiento",fechaNacimiento);
                    cmd.Parameters.AddWithValue("@curp",curp);
                    cmd.Parameters.AddWithValue("@idEstadoOrigen", idEstatus);
                    cmd.Parameters.AddWithValue("@idEstatus",idEstatus);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Alumno", ex);
            }

        }

        public void actualizarAlumno(int id, string nombre, string primerApellido, string segundoApellido, string correo, string telefono, string fechaNacimiento,  string curp, int idEstadoOrigen, int idEstatus)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conecion))
                {
                    SqlCommand cmd = new SqlCommand("SP_ActualizarAlumnos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@primerApellido", primerApellido);
                    cmd.Parameters.AddWithValue("@segundoApellido", segundoApellido);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@curp", curp);
                    cmd.Parameters.AddWithValue("@idEstadoOrigen", idEstadoOrigen);
                    cmd.Parameters.AddWithValue("@idEstatus", idEstatus);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Alumno", ex);
            }
        }

        public void eliminarAlumno(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_conecion))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarAlumno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar");
            }
        }

        public string eliminarConWebServices(int id) { return ws.eliminar2(id); }
        
    }
}

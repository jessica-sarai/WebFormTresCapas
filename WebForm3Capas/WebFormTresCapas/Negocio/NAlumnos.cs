using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;


namespace Negocio
{
    public class NAlumnos
    {
        ADOAlumno aADO = new ADOAlumno();
        ADOEstado eADO = new ADOEstado();
        ADOEstatus esADO = new ADOEstatus();

        List<Alumno> lstAlumno = new List<Alumno>();
        List<Estado> lstEstado = new List<Estado>();
        List<Estatus> lstEstatus = new List<Estatus>();

        public List<Alumno> consultar()
        {            
            return lstAlumno = aADO.consultarAlumno();

        }

        public List<Alumno> consultar2()
        {
            return lstAlumno = aADO.consultarAlumno2();

        }

        public List<Estado> consultarEstado()
        {           
            return lstEstado = eADO.consultarEstado();
        }

        public List<Estatus> consultarEstatus()
        {
            return lstEstatus = esADO.consultarEstatus();
        }

        public void agregar(string nombre, string primerApellido, string segundoApellido, string correo, string telefono, string fechaNacimiento, string curp, int idEstadoOrigen, int idEstatus)
        {
            aADO.agregarAlumno(nombre,primerApellido,segundoApellido, correo, telefono,fechaNacimiento,curp,idEstadoOrigen,idEstatus);
        }
        
        public void actualizar(int id,string nombre, string primerApellido, string segundoApellido, string correo, string telefono, string fechaNacimiento, string curp, int idEstadoOrigen, int idEstatus)
        {
            aADO.actualizarAlumno(id,nombre,primerApellido,segundoApellido,correo,telefono,fechaNacimiento, curp,idEstadoOrigen, idEstatus);
        }

        public void eliminar(int id)
        {
            aADO.eliminarAlumno(id);
        }

        public bool telefono(string telefono)
        {
            string numero = Convert.ToString(telefono);
            int num = numero.Length;
            if (num == 10)
            {
                return true;
            }
            else
            {
                return  false;
            }
        }

        public string eliminarConWebServices(int id)
        {
            
            return aADO.eliminarConWebServices(id); 
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentación.Formularios.Alumno
{
    public partial class Delete : System.Web.UI.Page
    {
        List<Entidades.Alumno> ltsEntidades = new List<Entidades.Alumno>();
        Entidades.Alumno ObjentiAl = new Entidades.Alumno();
        Negocio.NAlumnos ObjnegAlum = new Negocio.NAlumnos();

        int idSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            ltsEntidades = ObjnegAlum.consultar();

            idSeleccionado = Convert.ToInt32(Request.QueryString["id"]);

            Entidades.Alumno art = ltsEntidades.Find(ls => ls.id == idSeleccionado);

            lbId.Text = Convert.ToString(art.id);
            lbNombre.Text = art.nombre;
            lbPrimerApellido.Text = art.primerApellido;
            lbSegundoApellido.Text = art.segundoApellido;
            lbFechaNacimiento.Text = Convert.ToString(art.fechaNacimiento);
            lbCurp.Text = art.curp;
            lbCorreo.Text = art.correo;
            lbTelefono.Text = art.telefono;
            lbEstado.Text = Convert.ToString(art.estado);
            lbEstatus.Text = Convert.ToString(art.estatus);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idS = Convert.ToInt32(lbId.Text);
            ObjnegAlum.eliminar(idS);
            Response.Redirect($"Index.aspx", false);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Index.aspx", false);
        }

        protected void btnASMX_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(lbId.Text);
            
            lbRespuesta.Text= ObjnegAlum.eliminarConWebServices(id);
            Response.Redirect($"Index.aspx", false);
        }



    }
}
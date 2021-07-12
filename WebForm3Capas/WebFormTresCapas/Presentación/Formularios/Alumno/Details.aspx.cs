using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentación.Formularios.Alumno
{
    public partial class Details : System.Web.UI.Page
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
            lbFechaNacimiento.Text =Convert.ToString(art.fechaNacimiento);
            lbCurp.Text = art.curp;
            lbCorreo.Text = art.correo;
            lbTelefono.Text = art.telefono;
            lbEstado.Text =Convert.ToString(art.estado);
            lbEstatus.Text =Convert.ToString(art.estatus);

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Index.aspx", false);
        }
    }
}
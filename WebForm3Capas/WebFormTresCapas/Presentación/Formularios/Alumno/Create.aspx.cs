using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentación.Formularios.Alumno
{
    public partial class Create : System.Web.UI.Page
    {

        List<Entidades.Estado> lstEstado = new List<Entidades.Estado>();
        List<Entidades.Estatus> lstEstatus = new List<Entidades.Estatus>();
        Negocio.NAlumnos ObjNegAlum = new Negocio.NAlumnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                lstEstado = ObjNegAlum.consultarEstado();
                ddlEstado.DataSource = lstEstado;
                ddlEstado.DataValueField = "id";
                ddlEstado.DataTextField = "nombre";
                ddlEstado.DataBind();

                lstEstatus = ObjNegAlum.consultarEstatus();
                ddlEstatus.DataSource = lstEstatus;
                ddlEstatus.DataValueField = "id";
                ddlEstatus.DataTextField = "nombre";
                ddlEstatus.DataBind();
            }
          
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Index.aspx", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string primerApellido = txtPrimerApellido.Text;
            string segundoApellido = txtSegundoApellido.Text;
            string fechaNacimiento =txtFecha.Text;
            string curp = txtCurp.Text ;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            int idestado= Convert.ToInt32(ddlEstado.SelectedValue);
            int idestatus= Convert.ToInt32(ddlEstatus.SelectedValue);

            ObjNegAlum.agregar(nombre,
                               primerApellido,
                               segundoApellido,
                               correo,
                               telefono,
                               fechaNacimiento,
                               curp,                               
                               idestado,
                               idestatus);
            limpliar();
        }

        public void limpliar()
        {
           txtNombre.Text="";
           txtPrimerApellido.Text="";
           txtSegundoApellido.Text="";
           txtFecha.Text="";
           txtCurp.Text="";
           txtCorreo.Text="";
           txtTelefono.Text="";
           ddlEstado.DataBind();
           ddlEstatus.DataBind();
        }

    }
}
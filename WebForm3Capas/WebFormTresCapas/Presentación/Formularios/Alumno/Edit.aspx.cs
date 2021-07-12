using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentación.Formularios.Alumno
{
    public partial class Edit : System.Web.UI.Page
    {
        List<Entidades.Alumno> ltsEntidades = new List<Entidades.Alumno>();
        List<Entidades.Estado> lstEstado = new List<Entidades.Estado>();
        List<Entidades.Estatus> lstEstatus = new List<Entidades.Estatus>();
        Negocio.NAlumnos ObjNegAlum = new Negocio.NAlumnos();
        int idSeleccionado; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            ltsEntidades = ObjNegAlum.consultar2();

            idSeleccionado = Convert.ToInt32(Request.QueryString["id"]);

            Entidades.Alumno art = ltsEntidades.Find(ls => ls.id == idSeleccionado);

            txtId.Text = Convert.ToString(art.id);
            txtNombre.Text = art.nombre;
            txtPrimerApellido.Text = art.primerApellido;
            txtSegundoApellido.Text = art.segundoApellido;
            DateTime dt =Convert.ToDateTime(art.fechaNacimiento.ToString());
            txtFecha.Text = String.Format("{0:yyyy-MM-dd}", dt);
            txtCurp.Text = art.curp;
            txtCorreo.Text = art.correo;
            txtTelefono.Text = art.telefono;


            lstEstado = ObjNegAlum.consultarEstado();
            ddlEstado.DataSource = lstEstado;
            ddlEstado.DataValueField = "id";
            ddlEstado.DataTextField = "nombre";
            //ddlEstado.SelectedItem.Text = Convert.ToString(art.estado);
             ddlEstado.SelectedValue=Convert.ToString( art.idEstadoOrigen);
            ddlEstado.DataBind();
              
            lstEstatus = ObjNegAlum.consultarEstatus();
            ddlEstatus.DataSource = lstEstatus;
            ddlEstatus.DataValueField = "id";
            ddlEstatus.DataTextField = "nombre";
            //ddlEstatus.SelectedItem.Text = Convert.ToString(art.estatus);
                ddlEstatus.SelectedValue = Convert.ToString(art.idEstatus);
                ddlEstatus.DataBind();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
           
            int id =Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string primerApellido = txtPrimerApellido.Text;
            string segundoApellido = txtSegundoApellido.Text;
            string fechaNacimiento = txtFecha.Text;
            string curp = txtCurp.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            int idestado = Convert.ToInt32(ddlEstado.SelectedValue);
            int idestatus = Convert.ToInt32(ddlEstatus.SelectedValue);

            ObjNegAlum.actualizar(id,nombre,
                               primerApellido,
                               segundoApellido,
                               correo,
                               telefono,
                               fechaNacimiento,
                               curp,
                               idestado,
                               idestatus);
                if (txtCurp.Text == "")
                {

                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
             Response.Redirect($"Index.aspx", false);

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {          
            args.IsValid = ObjNegAlum.telefono(args.Value);        
        }

        public void limpliar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtFecha.Text = "";
            txtCurp.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            ddlEstado.DataBind();
            ddlEstatus.DataBind();
        }
    }
}
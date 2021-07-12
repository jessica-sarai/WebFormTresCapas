using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentación.Formularios.Alumno
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    gvAlumnosLLenado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="page")
            {
                return;
            }
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow select = gvAlumnos.Rows[index];
            TableCell idS = select.Cells[0];
            string id = idS.Text;

            switch (e.CommandName)
            {
                case "Detalle":
                    Response.Redirect($"Details?id={id}", false);
                    break;
                case "Editar":
                    Response.Redirect($"Edit?id={id}", false);
                    break;
                case "Eliminar":
                    Response.Redirect($"Delete?id={id}", false);
                    break;

            }
        }

        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvAlumnos.PageIndex = e.NewPageIndex;
                gvAlumnosLLenado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void gvAlumnosLLenado()
        {
            NAlumnos nAlumnos = new NAlumnos();
            gvAlumnos.DataSource=nAlumnos.consultar();
            gvAlumnos.DataBind();
  
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Create.aspx", false);
        }
    }
}
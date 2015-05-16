using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WSIC2010.WScoes_ManttoService;

namespace WSIC2010
{
    public partial class SeleccionarEquipo : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["in_app"] == null)
            {
                Response.Redirect("~/WebForm/Account/Login.aspx");
            }
            else
            {
                n_app in_app = (n_app)Session["in_app"];
                CascadingDropDown1.ContextKey = in_app.is_Empresas;
            }

            if (Session["i_ddlEmpresa"] != null)
            {                
                CascadingDropDown1.SelectedValue = Convert.ToString(Session["i_ddlEmpresa"]);
                try
                {
                    if (Session["i_ddlArea"] != null)
                        CascadingDropDown2.SelectedValue = Convert.ToString(Session["i_ddlArea"]);
                }
                catch
                { }
            }
        }
              

        protected void ddlEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxEquiCodi.Text = ddlEquipo.SelectedValue; 
            LabelEquipoElegido.Text = ddlEquipo.SelectedItem.Text;           
        }

        public int EQUICODI()
        {
           int li_resultado = 0;
           if (Int32.TryParse(TextBoxEquiCodi.Text, out li_resultado))
               return li_resultado;

           return li_resultado;
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["i_ddlEmpresa"] = ddlEmpresa.SelectedValue;
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["i_ddlArea"] = ddlArea.SelectedValue;
        }                
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSIC2010
{
    public partial class w_reclamos : System.Web.UI.Page
    {
        string sesionApp = "in_app";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[sesionApp] == null)
            {
                Response.Redirect("~/WebForm/Account/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    this.CargarDatos();
                }
            }
        }

        protected void CargarDatos()
        {
            n_app dao = (n_app)Session["in_app"];

            string page = String.Format("<iframe src='http://www.coes.org.pe/appReclamos/?user={0}' width='100%' height='1000' scrolling='auto' style='border:1px none'></iframe>", dao.is_UserLogin);

            this.lblContenido.Text = page;
        }
    }
}
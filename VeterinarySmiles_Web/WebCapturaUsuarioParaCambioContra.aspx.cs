using DifficilBankDAO.Implementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinarySmiles_Web
{
    public partial class WebCapturaUsuarioParaCambioContra : System.Web.UI.Page
    {

        UserImp2 impUse;

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        void compruebaExistenciaUsu()
        {

            if (txtUsuario.Text != "")
            {
                impUse = new UserImp2();
                DataTable user = impUse.CompruebaUsuExistente(txtUsuario.Text);

                if (user.Rows.Count != 0)
                {
                    DataTable idContra = impUse.devuelveContra(txtUsuario.Text);

                    id = Convert.ToInt32(idContra.Rows[0][0]);

                    Response.Redirect("WebCambioContraOlvidada.aspx?id=" + id);
                }



            }
            else
            {

            }


        }

        protected void btnIngresa_Click(object sender, EventArgs e)
        {
            compruebaExistenciaUsu();
        }
    }
}
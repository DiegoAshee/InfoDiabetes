using System;
using System.Web.UI;

namespace VeterinarySmiles_Web
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Puedes realizar inicializaciones u operaciones específicas cuando la página se carga por primera vez.
                CargarDatosInicio();
            }
        }

        private void CargarDatosInicio()
        {
            // Puedes agregar lógica para cargar datos específicos en la página de inicio.
            // Por ejemplo, obtener información relevante de una base de datos o servicios.
        }

        // Puedes agregar más métodos según las necesidades de tu página.
    }
}

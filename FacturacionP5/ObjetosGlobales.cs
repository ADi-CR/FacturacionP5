using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionP5
{
    public static class ObjetosGlobales
    {
        //esta clase se "auto instancia" al momento de inicializar la app
        //los atributos y fns que seas públicas serán visibles en la 
        //globalidad de la aplicación. 
        public static Logica.Models.Usuario MiUsuarioGlobal = new Logica.Models.Usuario();

        public static Form MiFormularioPrincipal = new Formularios.FrmMDIPrincipal();

        public static Formularios.FrmUsuariosGestion MiFormDeGestionDeUsuarios = new Formularios.FrmUsuariosGestion();

        public static Formularios.FrmFacturacion MiFormFacturador = new Formularios.FrmFacturacion();

    }
}

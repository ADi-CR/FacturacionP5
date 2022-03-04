using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionP5
{
    public static class ObjetosGlobales
    {
        //esta clase se "auto instancia" al momento de inicializar la app
        //los atributos y fns que seas públicas serán visibles en la 
        //globalidad de la aplicación. 

        public static Formularios.FrmUsuariosGestion MiFormDeGestionDeUsuarios = new Formularios.FrmUsuariosGestion();


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionP5.Formularios
{
    public partial class FrmUsuariosGestion : Form
    {
        //al igual que con cualquier otra clase se pueden escribir atributos para el form

        //en este caso vamos a tener un atributo de tipo usuario de fondo 
        //el cual me permite manipular los cambios que el usuario haga en todo momento
        public Logica.Models.Usuario MiUsuarioLocal { get; set; }
        
        public FrmUsuariosGestion()
        {
            InitializeComponent();

            //Paso 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();
        }

        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {
            ListarUsuariosActivos();

            CargarRolesDeUsuarioEnCombo();
        }

        private void CargarRolesDeUsuarioEnCombo()
        { 
            //crear un obj de tipo usuariorol 
            Logica.Models.UsuarioRol ObjRolDeUsuario = new Logica.Models.UsuarioRol();

            DataTable ListaRoles = new DataTable();

            ListaRoles = ObjRolDeUsuario.Listar();

            CboxTipoUsuario.ValueMember = "id";
            CboxTipoUsuario.DisplayMember = "d";

            CboxTipoUsuario.DataSource = ListaRoles;

            CboxTipoUsuario.SelectedIndex = -1;
        }

        private void ListarUsuariosActivos()
        { 
            //en la medida de lo posible deberiamos encapsular código que
            //tienda a ser reutilizable 

            //paso 1 y 1.1 de SdUsuariosListarActivos
            Logica.Models.Usuario MiUsuario = new Logica.Models.Usuario();

            //paso 2 y 2.5
            DataTable dt = MiUsuario.ListarActivos();

            //mostrar datos en el dgv
            DgvListaUsuarios.DataSource = dt;

            DgvListaUsuarios.ClearSelection();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //en la secuencia no se explica, pero se debe realizar una serie de validaciones de 
            //datos mínimos y de tipos y extensiones correctas para cada campo 

            //TODO: Agregar funcionalidad de validación 

            //TEMPORAL: se agregan los valores de los atributos del objeto local
            MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();
            MiUsuarioLocal.NombreUsuario = TxtEmail.Text.Trim();
            MiUsuarioLocal.Cedula = TxtCedula.Text.Trim();
            MiUsuarioLocal.Telefono = TxtTelefono.Text.Trim();
            MiUsuarioLocal.Contrasennia = TxtPassword.Text.Trim();
            MiUsuarioLocal.CorreoDeRespaldo = TxtEmailRespaldo.Text.Trim();
            MiUsuarioLocal.MiRol.IDUsuarioRol = Convert.ToInt32(CboxTipoUsuario.SelectedValue);
            
            //solo en este caso vamos a seguir la numeración de las secuencia "SeqUsuarioAgregar"

            //paso 1.1 y 1.2 está en el constructor 

            //paso 1.3 y 1.3.6 
            bool A = MiUsuarioLocal.ConsultarPorCedula();

            //paso 1.4 y 1.4.6
            bool B = MiUsuarioLocal.ConsultarPorEmail();

            //paso 1.5
            if (!A && !B)
            {
                //Paso 1.6, 1.6.6 y 1.7
                if (MiUsuarioLocal.Agregar())
                {
                    //paso 1.8
                    MessageBox.Show("Usuario agregado correctamente!", ":)", MessageBoxButtons.OK);
                }
                else
                {
                    //paso 1.8
                    MessageBox.Show("Ha ocurrido un error y el usuario no se guardó ", ":(", MessageBoxButtons.OK);
                }

                ListarUsuariosActivos();

                //TODO: Limpiar el formulario

            }
            else
            {
                //en este caso tenemos que indicar al usuario qué validación falló 
                if (A)
                {
                    MessageBox.Show("Ya existe un usuario con la Cédula digitada", "Error de Validación", MessageBoxButtons.OK);
                    TxtCedula.Focus();
                    TxtCedula.SelectAll();
                }
                if (B)
                {
                    MessageBox.Show("Ya existe un usuario con el Email digitado", "Error de Validación", MessageBoxButtons.OK);
                    TxtEmail.Focus();
                    TxtEmail.SelectAll();   
                }
            }
        }

        private void DgvListaUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvListaUsuarios.ClearSelection();
        }
    }
}

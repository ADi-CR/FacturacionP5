﻿using System.Data;

namespace Logica.Models
{
    public class Cliente
    {
        //atributos simples
        public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        //atributos compuestos
        ClienteTipo MiTipo { get; set; }

        //constructor de la clase para instanciar el atributo compuesto simple
        public Cliente()
        {
            //dentro de este ctor instanciamos los objetos compuestos
            MiTipo = new ClienteTipo();

        }

        //operaciones de la clase

        //NOTA: está función "agregar()" se usa acá con fines didácticos, ya que pasamos los valores
        //por medio de parametros. A mi en particular me gusta más agregar los valores directamente
        //en los atributos cuando creamos el objeto. 

        public bool Agregar(string pNombre, string pCedula, string pTelefono = "", string pEmail = "")
        {
            bool R = false;

            //cuando se usa esta forma el paso de valores se realiza por acá. 
            Nombre = pNombre;
            Cedula = pCedula;
            Telefono = pTelefono;
            Email = pEmail;

            //TODO: ejecutar el SP para el insert en tabla de cliente

            return R;
        }

        public bool Editar(int pIDCliente, string pNombre, string pCedula, string pTelefono = "", string pEmail = "")
        {
            bool R = false;



            return R;
        }

        public bool Eliminar(int pIDCliente)
        {
            bool R = false;



            return R;
        }

        public bool ConsultarPorCedula(string pCedula)
        {
            bool R = false;



            return R;

        }

        public bool ConsultarPorID(int pIDCliente)
        {
            bool R = false;



            return R;

        }

        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();



            return R;
        }

    }
}

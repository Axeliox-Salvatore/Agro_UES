using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Agro_UES.FormLogin;

namespace Agro_UES
{
    public partial class Inicio: Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarSesionUsuario();
        }

        private void CerrarSesionUsuario()
        {
            string cerrarSesion = "UPDATE usuarios SET sesion_activa = FALSE WHERE id_usuario = @idUsuario";

            using (MySqlConnection conexion = new ConexionDB().Conectar())
            {
                using (MySqlCommand comando = new MySqlCommand(cerrarSesion, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", UsuarioSesion.IdUsuarioActual);
                    comando.ExecuteNonQuery();
                }
            }

            Console.WriteLine("🔒 Sesión cerrada correctamente.");
        }
    }
}

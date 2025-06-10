using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Agro_UES
{
    class ConexionDB
    {
        private string conexionString = "server=localhost; database=AgroServicioDB; user=root; password=tu_contraseña;";

        public MySqlConnection Conectar()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(conexionString);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
                return null;
            }
        }

        public void CerrarConexion(MySqlConnection conexion)
        {
            if (conexion != null)
            {
                conexion.Close();
            }
        }

    }
}

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
        private string conexionString = "server=127.0.0.1; database=agroservicioDB; user=root; password=;";

        public MySqlConnection Conectar()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(conexionString);
                conexion.Open();
                Console.WriteLine("✅ Conexión exitosa con la base de datos.");
                return conexion;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"❌ Error de conexión a MySQL (Código {ex.Number}): {ex.Message}");
                return null;
            }
        }

        public void CerrarConexion(MySqlConnection conexion)
        {
            if (conexion != null)
            {
                conexion.Close();
                Console.WriteLine("🔒 Conexión cerrada correctamente.");
            }
        }
    }
}
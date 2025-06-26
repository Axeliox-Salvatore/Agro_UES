using Agro_UES.Formularios.FormCajero;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agro_UES
{
    public partial class FormLogin: Form
    {
        private int idUsuarioActual;
        private string nombreUsuarioActual;
        private string rolUsuarioActual;

        public FormLogin(int id, string nombre, string rol)
        {
            InitializeComponent();
            idUsuarioActual = id;
            nombreUsuarioActual = nombre;
            rolUsuarioActual = rol;


        }
        public FormLogin() : this(0, "", "")
        {
        }


        private string EncriptarPin(string pin)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pin);
                byte[] hash = sha.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (var b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Obtener el identificador que puede ser correo o nombre, y la contrasenia
            string identificador = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            // Encriptar la contrasña
            string contraEncriptada = EncriptarPin(contraseña);

            try
            {
                // Query pa validar el login (buscando por correo o nombre)
                string consulta = "SELECT u.id_usuario, u.nombre, u.correo, u.rol_id, r.nombre_rol " +
                               "FROM usuarios u INNER JOIN roles r ON u.rol_id = r.id_rol " +
                               "WHERE (u.correo = @id OR u.nombre = @id) " +
                               "AND u.contraseña_hash = @pass " +
                               "AND u.estado = 'activo'";

                // Conectar a la BD con la cadena de conexion
                using (MySqlConnection conectar = ConexionDB.Conexion())

                {
                    conectar.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conectar))
                    {
                        // Agregar parametros pa evitar SQL injection
                        cmd.Parameters.AddWithValue("@id", identificador);
                        cmd.Parameters.AddWithValue("@pass", contraEncriptada);
                        // Declarar las variables fuera del bloque para que tengan alcance en todo el metodo
                        int idUsuario = 0;
                        string nombreUsuario = "";
                        string rol = "";


                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                // Si se encuentra el usuario, se leen los datos
                                idUsuario = Convert.ToInt32(lector["id_usuario"]);
                                nombreUsuario = lector["nombre"].ToString();
                                rol = lector["nombre_rol"].ToString();


                                MessageBox.Show("Bienvenido " + nombreUsuario + " (" + rol + ")", "Login Exitoso");
                                // Cerrar el lector para poder ejecutar otra consulta en la misma conexion
                                lector.Close();
                                // Insertar en la tabla historial_acciones el registro de inicio de sesion
                                string consultaHistorial = "INSERT INTO historial_acciones (usuario_id, nombre_usuario, accion) " +
                                                           "VALUES (@usuario_id, @nombre_usuario, @accion)";
                                using (MySqlCommand cmdHist = new MySqlCommand(consultaHistorial, conectar))
                                {
                                    cmdHist.Parameters.AddWithValue("@usuario_id", idUsuario);
                                    cmdHist.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                                    cmdHist.Parameters.AddWithValue("@accion", "Inicio de sesión en el sistema");
                                    cmdHist.ExecuteNonQuery();
                                }



                                // Aqui redirigis al form segun el rol 
                                if (rol == "Cajero")
                                {
                                    new FormCajero0(idUsuario, nombreUsuario, rol).Show();
                                    this.Hide();
                                }
                                else if (rol == "Gerente")
                                {
                                    new FormGerente(idUsuario, nombreUsuario, rol).Show();
                                    this.Hide();
                                }
                                else if (rol == "Super Administrador")
                                {
                                    new FormSuperAdmin(idUsuario, nombreUsuario, rol).Show();
                                    this.Hide();
                                }
                                else if (rol == "Encargado de Almacen")
                                {
                                    new FormAlmacen(idUsuario, nombreUsuario, rol).Show();
                                    this.Hide();
                                }

                                else
                                {
                                    // Si el rol no coincide con los conocidos
                                    MessageBox.Show("Rol no reconocido", "Error");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Usuario o contrasenia incorrectos", "Error");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si algo fallo
                MessageBox.Show("Error: " + ex.Message, "Excepcion");
            }
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        /*Logica del link "Olvidaste tu contraseña?"*/
        private void label4_Click(object sender, EventArgs e)
        {  
           
         // Abrir el form pa recuperar la contraseñaa
         FormRecuperar frmRecup = new FormRecuperar();
         frmRecup.Show();
         // Ocultar este form
            this.Hide();
       
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Agro_UES.Formularios.FormAlmacen
{
    
    public partial class GestionCategorias: Form
    {
        private int idUsuarioActual;
        private string nombreUsuarioActual;
        public GestionCategorias(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
            nombreUsuarioActual = nombreUsuario;
        }
        private void GestionCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }
        private void CargarCategorias()
        {
            cmbcategorias.Items.Clear();

            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();
                    string sql = "SELECT id_categoria, nombre_categoria FROM categorias WHERE estado = 'Activa'";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbcategorias.Items.Add(new CategoriaComboItem
                            {
                                Id = reader.GetInt32("id_categoria"),
                                Nombre = reader.GetString("nombre_categoria")
                            });
                        }
                    }
                }
                if (cmbcategorias.Items.Count > 0)
                    cmbcategorias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        // Clase auxiliar para el ComboBox
        private class CategoriaComboItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString() => Nombre;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnsolicitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcategoria.Text))
            {
                MessageBox.Show("Ingrese el nombre de la nueva categoría.");
                return;
            }

            string nombreCategoria = txtcategoria.Text.Trim();

            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        // 1. Insertar en categorias con estado 'Inactiva'
                        string sqlCat = @"INSERT INTO categorias (nombre_categoria, estado) VALUES (@nombre, 'Inactiva')";
                        using (var cmdCat = new MySqlCommand(sqlCat, conn, trans))
                        {
                            cmdCat.Parameters.AddWithValue("@nombre", nombreCategoria);
                            cmdCat.ExecuteNonQuery();
                        }

                        // 2. Insertar solicitud en aprobaciones
                        string descripcion = $"Solicitud de nueva categoría: {nombreCategoria}";
                        string sqlAprob = @"INSERT INTO aprobaciones 
                    (tipo_proceso, descripcion, estado, usuario_id, nombre_usuario_aprueba, fecha_hora)
                    VALUES ('Nueva categoría', @desc, 'Pendiente', @uid, @nombre, NOW())";
                        using (var cmdAprob = new MySqlCommand(sqlAprob, conn, trans))
                        {
                            cmdAprob.Parameters.AddWithValue("@desc", descripcion);
                            cmdAprob.Parameters.AddWithValue("@uid", idUsuarioActual);
                            cmdAprob.Parameters.AddWithValue("@nombre", nombreUsuarioActual);
                            cmdAprob.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                }

                MessageBox.Show("Solicitud enviada. La categoría quedará inactiva hasta aprobación del gerente.");
                txtcategoria.Clear();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al solicitar la nueva categoría: " + ex.Message);
            }
        }

        private void GestionCategorias_Load_1(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

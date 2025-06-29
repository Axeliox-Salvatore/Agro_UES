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
    public partial class Registrarproducto : Form
    {
        private int idUsuarioActual;
        private string nombreUsuarioActual;

        public Registrarproducto(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
            nombreUsuarioActual = nombreUsuario;

            // Poblar el ComboBox de categorías
            cmbcategorias.Items.Clear();
            cmbcategorias.Items.Add("Fertilizantes"); // id 1
            cmbcategorias.Items.Add("Herramientas");  // id 2
            cmbcategorias.Items.Add("Semillas");      // id 3
            cmbcategorias.SelectedIndex = 0;
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (char.IsControl(e.KeyChar))
                return;
            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains('.'))
                    e.Handled = true;
                return;
            }
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            int index = txt.SelectionStart;
            string textoFinal = txt.Text.Insert(index, e.KeyChar.ToString());
            if (textoFinal.Contains('.'))
            {
                int decimales = textoFinal.Length - textoFinal.IndexOf('.') - 1;
                if (decimales > 2)
                    e.Handled = true;
            }
        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproducto.Text) ||
                string.IsNullOrWhiteSpace(txtdescripcion.Text) ||
                cmbcategorias.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtprecio.Text) ||
                string.IsNullOrWhiteSpace(txtstock.Text) ||
                string.IsNullOrWhiteSpace(mtxtvencimiento.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            string nombre = txtproducto.Text.Trim();
            string descripcionProd = txtdescripcion.Text.Trim();
            int categoriaId = cmbcategorias .SelectedIndex + 1; // 1: Fertilizantes, 2: Herramientas, 3: Semillas
            decimal precio = decimal.Parse(txtprecio.Text);
            int stock = int.Parse(txtstock.Text);
            string fechaVencimiento = mtxtvencimiento.Text.Trim();

            string descripcionAprob = $"Registro de producto: {nombre}, Precio: {precio}, Stock: {stock}, Categoría: {categoriaId}";

            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        // 1. Insertar en aprobaciones
                        string sqlAprob = @"INSERT INTO aprobaciones 
                            (tipo_proceso, descripcion, estado, usuario_id, nombre_usuario_aprueba, fecha_hora)
                            VALUES (@tipo, @desc, 'Pendiente', @uid, @nombre, NOW())";
                        using (var cmdAprob = new MySqlCommand(sqlAprob, conn, trans))
                        {
                            cmdAprob.Parameters.AddWithValue("@tipo", "Ingreso de producto");
                            cmdAprob.Parameters.AddWithValue("@desc", descripcionAprob);
                            cmdAprob.Parameters.AddWithValue("@uid", idUsuarioActual);
                            cmdAprob.Parameters.AddWithValue("@nombre", nombreUsuarioActual);
                            cmdAprob.ExecuteNonQuery();
                        }

                        // 2. Insertar en productos con categoria seleccionada y campos requeridos
                        string sqlProd = @"INSERT INTO solicitudes_productos 
                            (nombre, descripcion, categoria_id, precio, stock, fecha_vencimiento, alerta_bajo_stock, ruta_imagen, estado)
                            VALUES (@nombre, @descripcion, @categoria_id, @precio, @stock, @fecha_venc, NULL, NULL, 'Pendiente')";
                        using (var cmdProd = new MySqlCommand(sqlProd, conn, trans))
                        {
                            cmdProd.Parameters.AddWithValue("@nombre", nombre);
                            cmdProd.Parameters.AddWithValue("@descripcion", descripcionProd);
                            cmdProd.Parameters.AddWithValue("@categoria_id", categoriaId);
                            cmdProd.Parameters.AddWithValue("@precio", precio);
                            cmdProd.Parameters.AddWithValue("@stock", stock);
                            cmdProd.Parameters.AddWithValue("@fecha_venc", fechaVencimiento);
                            cmdProd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                }

                MessageBox.Show("Solicitud registrada correctamente. El producto estará disponible tras la aprobación del gerente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la solicitud: " + ex.Message);
            }
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
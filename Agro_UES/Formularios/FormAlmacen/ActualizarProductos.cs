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
    public partial class ActualizarProductos: Form
    {
        private int idUsuarioActual;
        private string nombreUsuarioActual;
        public ActualizarProductos(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
            nombreUsuarioActual = nombreUsuario;
        }

        private void ActualizarProductos_Load(object sender, EventArgs e)
        {
            cmbproductos.Items.Clear();

            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();
                    string sql = "SELECT id_producto, nombre, descripcion, precio, stock, fecha_vencimiento FROM productos WHERE estado = 'Activo'";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fechaVencimientoStr = "";
                            if (!reader.IsDBNull(reader.GetOrdinal("fecha_vencimiento")))
                            {
                                object fechaObj = reader["fecha_vencimiento"];
                                // Si es DateTime valido
                                if (fechaObj is DateTime dt)
                                {
                                    fechaVencimientoStr = dt.ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    // Si es string y es "0000-00-00"
                                    string raw = fechaObj.ToString();
                                    if (raw == "0000-00-00")
                                        fechaVencimientoStr = "";
                                    else
                                        fechaVencimientoStr = raw;
                                }
                            }

                            cmbproductos.Items.Add(new ProductoComboItem
                            {
                                Id = reader.GetInt32("id_producto"),
                                Nombre = reader.GetString("nombre"),
                                Descripcion = reader.GetString("descripcion"),
                                Precio = reader.GetDecimal("precio"),
                                Stock = reader.GetInt32("stock"),
                                FechaVencimiento = fechaVencimientoStr
                            });
                        }
                    }
                }
                if (cmbproductos.Items.Count > 0)
                    cmbproductos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        // Clase auxiliar para el ComboBox
        private class ProductoComboItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
            public string FechaVencimiento { get; set; }

            public override string ToString()
            {
                return $"{Nombre} - {Descripcion}";
            }
        }

        private void cmbproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbproductos.SelectedItem is ProductoComboItem item)
            {
                txtdescripcion.Text = item.Descripcion;
                txtprecio.Text = item.Precio.ToString("N2");
                txtstock.Text = item.Stock.ToString();
                mtxtvencimiento.Text = item.FechaVencimiento;
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            if (cmbproductos.SelectedItem is ProductoComboItem item)
            {
                if (string.IsNullOrWhiteSpace(txtdescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtprecio.Text) ||
                    string.IsNullOrWhiteSpace(txtstock.Text) ||
                    string.IsNullOrWhiteSpace(mtxtvencimiento.Text))
                {
                    MessageBox.Show("Complete todos los campos.");
                    return;
                }

                int idProducto = item.Id;
                string nuevaDescripcion = txtdescripcion.Text.Trim();
                decimal nuevoPrecio = decimal.Parse(txtprecio.Text);
                int nuevoStock = int.Parse(txtstock.Text);
                string nuevaFechaVenc = mtxtvencimiento.Text.Trim();

                string descripcionAprob = $"Actualización de producto ID {idProducto}: " +
                    $"Descripcion: {nuevaDescripcion}, Precio: {nuevoPrecio}, Stock: {nuevoStock}, Fecha de vencimiento: {nuevaFechaVenc}";

                try
                {
                    using (var conn = ConexionDB.Conexion())
                    {
                        conn.Open();
                        using (var trans = conn.BeginTransaction())
                        {
                            // 1. Insertar solicitud en aprobaciones
                            string sqlAprob = @"INSERT INTO aprobaciones 
                        (tipo_proceso, descripcion, estado, usuario_id, nombre_usuario_aprueba, fecha_hora)
                        VALUES (@tipo, @desc, 'Pendiente', @uid, @nombre, NOW())";
                            using (var cmdAprob = new MySqlCommand(sqlAprob, conn, trans))
                            {
                                cmdAprob.Parameters.AddWithValue("@tipo", "Actualizar producto");
                                cmdAprob.Parameters.AddWithValue("@desc", descripcionAprob);
                                cmdAprob.Parameters.AddWithValue("@uid", idUsuarioActual);
                                cmdAprob.Parameters.AddWithValue("@nombre", nombreUsuarioActual);
                                cmdAprob.ExecuteNonQuery();
                            }

                            // 2. Actualizar producto y ponerlo en estado 'Pendiente'
                            string sqlUpdate = @"UPDATE solicitudes_productos SET 
                        descripcion = @descripcion,
                        precio = @precio,
                        stock = @stock,
                        fecha_vencimiento = @fecha_venc,
                        estado = 'Pendiente'
                        WHERE id_producto = @id";
                            using (var cmdUpdate = new MySqlCommand(sqlUpdate, conn, trans))
                            {
                                cmdUpdate.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                                cmdUpdate.Parameters.AddWithValue("@precio", nuevoPrecio);
                                cmdUpdate.Parameters.AddWithValue("@stock", nuevoStock);
                                cmdUpdate.Parameters.AddWithValue("@fecha_venc", nuevaFechaVenc);
                                cmdUpdate.Parameters.AddWithValue("@id", idProducto);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            trans.Commit();
                        }
                    }

                    MessageBox.Show("Solicitud de actualizacion enviada. El producto quedara pendiente hasta aprobacion del gerente.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el producto: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto.");
            }
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

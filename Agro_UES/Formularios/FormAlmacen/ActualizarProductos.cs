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
                                // Si es DateTime válido
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

                if (!decimal.TryParse(txtprecio.Text, out decimal nuevoPrecio) ||
                    !int.TryParse(txtstock.Text, out int nuevoStock))
                {
                    MessageBox.Show("Verifique que precio y stock tengan valores numéricos.");
                    return;
                }

                if (!DateTime.TryParse(mtxtvencimiento.Text.Trim(), out DateTime nuevaFechaVenc))
                {
                    MessageBox.Show("La fecha de vencimiento no tiene un formato válido.");
                    return;
                }

                try
                {
                    using (var conn = ConexionDB.Conexion())
                    {
                        conn.Open();

                        string sql = @"
                    INSERT INTO aprobaciones_almacen (
                        id_producto,
                        descripcion,
                        precio,
                        stock,
                        fecha_vencimiento,
                        estado,
                        usuario_solicita,
                        nombre_solicita,
                        fecha_solicita
                    )
                    VALUES (
                        @id, @desc, @precio, @stock, @venc, 'Pendiente',
                        @uid, @nombre, NOW()
                    );";

                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idProducto);
                            cmd.Parameters.AddWithValue("@desc", nuevaDescripcion);
                            cmd.Parameters.AddWithValue("@precio", nuevoPrecio);
                            cmd.Parameters.AddWithValue("@stock", nuevoStock);
                            cmd.Parameters.AddWithValue("@venc", nuevaFechaVenc);
                            cmd.Parameters.AddWithValue("@uid", idUsuarioActual);
                            cmd.Parameters.AddWithValue("@nombre", nombreUsuarioActual);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("La solicitud fue registrada y está pendiente de aprobación.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la solicitud: " + ex.Message);
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

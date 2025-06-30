using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agro_UES.Formularios.FormAlmacen
{
    public partial class GenerarAlertas: Form
    {
        public GenerarAlertas()
        {
            InitializeComponent();
        }
        private class ProductoComboItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Stock { get; set; }
            public override string ToString() => Nombre;
        }
        private void CargarProductos()
        {
            cmbproductos.Items.Clear();
            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();
                    string sql = "SELECT id_producto, nombre, stock FROM productos";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbproductos.Items.Add(new ProductoComboItem
                            {
                                Id = reader.GetInt32("id_producto"),
                                Nombre = reader.GetString("nombre"),
                                Stock = reader.GetInt32("stock")
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


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GenerarAlertas_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void cmbproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbproductos.SelectedItem is ProductoComboItem item)
            {
                txtstock.Text = item.Stock.ToString();
            }
        }

        private void cbalerta_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbproductos.SelectedItem is ProductoComboItem item)
            {
                try
                {
                    using (var conn = ConexionDB.Conexion())
                    {
                        conn.Open();
                        string sql = "UPDATE productos SET alerta_bajo_stock = @alerta WHERE id_producto = @id";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@alerta", cbalerta.Checked ? 1 : 0);
                            cmd.Parameters.AddWithValue("@id", item.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Alerta actualizada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la alerta: " + ex.Message);
                }
            }
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

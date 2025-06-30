using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agro_UES;
using Agro_UES.Formularios.Formgerente;

using MySql.Data.MySqlClient;




namespace Agro_UES.Formularios.Formgerente
{
    public partial class FormSolicitudes : Form
    {
        private void lblSolicitudUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblTipoProceso_Click(object sender, EventArgs e)
        {

        }

        private void lblDescripción_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaSolicitud_Click(object sender, EventArgs e)
        {

        }

        private void btnAprobarProceso_Click_1(object sender, EventArgs e)
        {

        }

        private void lblStok_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaVencimiento_Click(object sender, EventArgs e)
        {

        }

        private void lblIngresosMensuales_Click(object sender, EventArgs e)
        {

        }

        private void lblVentasMensuales_Click(object sender, EventArgs e)
        {

        }

        private void dgvSolicitudesPendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHistorialSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int idAprobador;
        private string nombreAprobador;
        private string rolAprobador;


        public FormSolicitudes(int idUsuario, string nombreUsuario, string rol)
        {
            InitializeComponent();
            this.idAprobador = idUsuario;
            this.nombreAprobador = nombreUsuario;
            this.rolAprobador = rol;


            Load += FormSolicitudes_Load;
        }

        private void FormSolicitudes_Load(object sender, EventArgs e)
        {
            CargarPendientes();
            CargarHistorial();
        }
        private void RegistrarAccion(string descripcion)
        {
            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();
                    string sql = @"INSERT INTO historial_acciones 
                           (usuario_id, nombre_usuario, accion, fecha_hora)
                           VALUES (@id, @nombre, @accion, NOW())";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idAprobador);
                        cmd.Parameters.AddWithValue("@nombre", nombreAprobador);
                        cmd.Parameters.AddWithValue("@accion", descripcion);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                
            }

        }




        /**************Mostra detalless***********/

       




        private void CargarHistorial()
        {
            dgvHistorialSolicitudes.Rows.Clear();

            using (var conn = ConexionDB.Conexion())
            {
                conn.Open();
                string sql = @"
                    SELECT id_aprobacion, id_producto, descripcion, precio, stock, 
                           fecha_vencimiento, estado, nombre_solicita, fecha_solicita,
                           nombre_responde, fecha_respuesta
                    FROM aprobaciones_almacen
                    WHERE estado IN ('Aprobada','Rechazada')
                    ORDER BY fecha_respuesta DESC";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int idProducto = rdr.GetInt32("id_producto");
                        string descripcion = rdr.GetString("descripcion");
                        decimal precio = rdr.GetDecimal("precio");
                        int stock = rdr.GetInt32("stock");
                        string venc = rdr.IsDBNull(rdr.GetOrdinal("fecha_vencimiento"))
                                        ? "—"
                                        : rdr.GetDateTime("fecha_vencimiento").ToShortDateString();
                        string estado = rdr.GetString("estado");
                        string solicitadoPor = rdr.GetString("nombre_solicita");
                        string fechaSolicitud = rdr.GetDateTime("fecha_solicita").ToString("g");
                        string aprobadoPor = rdr.IsDBNull(rdr.GetOrdinal("nombre_responde"))
                                                ? "—"
                                                : rdr.GetString("nombre_responde");
                        string fechaRespuesta = rdr.IsDBNull(rdr.GetOrdinal("fecha_respuesta"))
                                                ? "—"
                                                : rdr.GetDateTime("fecha_respuesta").ToString("g");

                        int idx = dgvHistorialSolicitudes.Rows.Add();
                        var fila = dgvHistorialSolicitudes.Rows[idx];
                        fila.Cells["dgvHistIDProd"].Value = idProducto;
                        fila.Cells["dgvHistDescripcion"].Value = descripcion;
                        fila.Cells["dgvHistPrecio"].Value = precio;
                        fila.Cells["dgvHistStock"].Value = stock;
                        fila.Cells["dgvHistVencimiento"].Value = venc;
                        fila.Cells["dgvHistEstado"].Value = estado;
                        fila.Cells["dgvHistSolicita"].Value = solicitadoPor;
                        fila.Cells["dgvHistFechaSolicita"].Value = fechaSolicitud;
                        fila.Cells["dgvHistAprobador"].Value = aprobadoPor;
                        fila.Cells["dgvHistFechaRespuesta"].Value = fechaRespuesta;
                    }
                }
            }


        }



        //**************Cargar solicitudes pendientes***********/
        private void CargarPendientes()
        {
            dgvSolicitudesPendientes.Rows.Clear();

            using (var conn = ConexionDB.Conexion())
            {
                conn.Open();
                string sql = @"
                    SELECT id_aprobacion, id_producto, descripcion, precio, stock, 
                           fecha_vencimiento, nombre_solicita, fecha_solicita
                    FROM aprobaciones_almacen
                    WHERE estado = 'Pendiente'
                    ORDER BY fecha_solicita DESC";

                using (var cmd = new MySqlCommand(sql, conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int idAprobacion = rdr.GetInt32("id_aprobacion");
                        int idProducto = rdr.GetInt32("id_producto");
                        string descripcion = rdr.GetString("descripcion");
                        decimal precio = rdr.GetDecimal("precio");
                        int stock = rdr.GetInt32("stock");
                        string fechaVenc = rdr.IsDBNull(rdr.GetOrdinal("fecha_vencimiento"))
                                            ? "—"
                                            : rdr.GetDateTime("fecha_vencimiento").ToShortDateString();
                        string usuario = rdr.GetString("nombre_solicita");
                        string fechaSolicitud = rdr.GetDateTime("fecha_solicita").ToString("g");

                        int idx = dgvSolicitudesPendientes.Rows.Add();
                        var fila = dgvSolicitudesPendientes.Rows[idx];
                        fila.Cells["dgvIDProducto"].Value = idProducto;
                        fila.Cells["dgvDescripcion"].Value = descripcion;
                        fila.Cells["dgvPrecio"].Value = precio;
                        fila.Cells["dgvStock"].Value = stock;
                        fila.Cells["dgvFechaVencimiento"].Value = fechaVenc;
                        fila.Cells["dgvSolicita"].Value = usuario;
                        fila.Cells["dgvFechaSolicitud"].Value = fechaSolicitud;
                        fila.Tag = idAprobacion;
                    }
                }
            }


        }

        private void dgvSolicitudesPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dgvHistorialSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHistorialSolicitudes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AplicarAjusteProductoDesdeDescripcion(string descripcion, MySqlConnection conn)
        {
            try
            {
                int idProducto = int.Parse(descripcion.Split(new[] { "ID " }, StringSplitOptions.None)[1].Split(':')[0]);
                int nuevoStock = int.Parse(
                    descripcion.ToLower().Contains("stock:")
                        ? descripcion.Split(new[] { "Stock:" }, StringSplitOptions.None)[1].Split(',')[0].Trim()
                        : "0"
                );

                string sql = @"UPDATE productos 
                       SET stock = @stock, estado = 'Aprobado'
                       WHERE id_producto = @id";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    cmd.Parameters.AddWithValue("@stock", nuevoStock);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el ajuste de stock:\n{ex.Message}", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnAprobarProceso_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudesPendientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una solicitud para aprobar.");
                return;
            }

            var fila = dgvSolicitudesPendientes.SelectedRows[0];
            int idAprobacion = Convert.ToInt32(fila.Tag);

            using (var conn = ConexionDB.Conexion())
            {
                conn.Open();

                // 1) Leer datos de la solicitud en aprobaciones_almacen
                string sql = @"SELECT * FROM aprobaciones_almacen WHERE id_aprobacion = @id";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idAprobacion);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (!rdr.Read())
                {
                    MessageBox.Show("Solicitud no encontrada.");
                    return;
                }

                int idProducto = rdr.GetInt32("id_producto");
                string descripcion = rdr.GetString("descripcion");
                decimal precio = rdr.GetDecimal("precio");
                int stock = rdr.GetInt32("stock");

                // Correccion aqui: extraemos fecha_vencimiento de forma segura y compatible
                DateTime? vencimiento = null;
                int ordinalVenc = rdr.GetOrdinal("fecha_vencimiento");
                if (!rdr.IsDBNull(ordinalVenc))
                    vencimiento = rdr.GetDateTime(ordinalVenc);

                rdr.Close();

                // 2) Verificar si el producto ya existe
                sql = "SELECT COUNT(*) FROM productos WHERE id_producto = @id";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idProducto);
                long existe = (long)cmd.ExecuteScalar();

                if (existe == 0)
                {
                    // Insertar nuevo producto si no existe
                    sql = @"INSERT INTO productos 
                    (id_producto, descripcion, categoria_id, precio, stock, fecha_vencimiento)
                    VALUES (@id, @desc, 1, @precio, @stock, @fecha)";
                }
                else
                {
                    // Actualizar producto existente
                    sql = @"UPDATE productos 
                    SET descripcion = @desc,
                        precio = @precio,
                        stock = @stock,
                        fecha_vencimiento = @fecha
                    WHERE id_producto = @id";
                }

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idProducto);
                cmd.Parameters.AddWithValue("@desc", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@fecha", vencimiento.HasValue ? (object)vencimiento.Value : DBNull.Value);
                cmd.ExecuteNonQuery();

                // 3) Marcar la solicitud como Aprobada
                sql = @"UPDATE aprobaciones_almacen 
                SET estado = 'Aprobada', 
                    usuario_responde = @uId, 
                    nombre_responde = @nombre, 
                    fecha_respuesta = NOW()
                WHERE id_aprobacion = @idAprob";

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uId", idAprobador);
                cmd.Parameters.AddWithValue("@nombre", nombreAprobador);
                cmd.Parameters.AddWithValue("@idAprob", idAprobacion);
                cmd.ExecuteNonQuery();

                // 4) Historial de acción
                RegistrarAccion($"Aprob solicitud #{idAprobacion} – Producto ID: {idProducto}");
            }

            MessageBox.Show("La solicitud fue aprobada y el producto ha sido actualizado correctamente.", "Aprobacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarPendientes();
            CargarHistorial();

        }



        private void btnRechazarSolicitud_Click(object sender, EventArgs e)
        {
            if (dgvSolicitudesPendientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una solicitud para rechazar.");
                return;
            }

            var fila = dgvSolicitudesPendientes.SelectedRows[0];
            int idAprobacion = Convert.ToInt32(fila.Tag);

            string motivo = Microsoft.VisualBasic.Interaction.InputBox("Indica la razon del rechazo:", "Rechazar solicitud", "No especificado");
            if (string.IsNullOrWhiteSpace(motivo))
            {
                MessageBox.Show("Se requiere una observacion para rechazar.");
                return;
            }

            using (var conn = ConexionDB.Conexion())
            {
                conn.Open();

                string sql = @"UPDATE aprobaciones_almacen 
                       SET estado = 'Rechazada',
                           observacion = @obs,
                           usuario_responde = @id,
                           nombre_responde = @nombre,
                           fecha_respuesta = NOW()
                       WHERE id_aprobacion = @idAprob";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@obs", motivo);
                    cmd.Parameters.AddWithValue("@id", idAprobador);
                    cmd.Parameters.AddWithValue("@nombre", nombreAprobador);
                    cmd.Parameters.AddWithValue("@idAprob", idAprobacion);
                    cmd.ExecuteNonQuery();
                }

                RegistrarAccion($"Rechazo solicitud #{idAprobacion}. Motivo: {motivo}");
            }

            MessageBox.Show("La solicitud fue rechazada.", "Solicitud rechazada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            CargarPendientes();
            CargarHistorial();


        }
    }
}
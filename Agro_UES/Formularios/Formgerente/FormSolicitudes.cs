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
        
        private int idAprobacionSeleccionada = -1;
        private int idUsuarioGerente;
        private string nombreUsuarioGerente;

        // Constructor OBLIGATORIO
        public FormSolicitudes(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            idUsuarioGerente = idUsuario;
            nombreUsuarioGerente = nombreUsuario;
            this.Load += FormSolicitudes_Load;
        }




        private void dgvHistorialSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void FormSolicitudes_Load(object sender, EventArgs e)
        {
            CargarPendientes();
           
        }

        private void MostrarDetalles(int idAprob)
        {
            try
            {
                using (MySqlConnection conn = ConexionDB.Conexion())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string sql = @"
                SELECT aa.*, 
                       p.nombre AS nombre_producto,
                       u.nombre AS nombre_solicitante
                  FROM aprobaciones_almacen aa
                  JOIN productos p ON aa.id_producto = p.id_producto
                  JOIN usuarios u ON u.id_usuario = aa.usuario_solicita
                 WHERE aa.id_aprobacion = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idAprob);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (!rdr.HasRows)
                            {
                                MessageBox.Show("No se encontró ninguna solicitud con el ID indicado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            if (rdr.Read())
                            {
                                lblNombreSolicitante.Text = rdr["nombre_solicitante"].ToString();
                                lblTipoProceso.Text = "Actualizar producto";
                                lblEstado.Text = rdr["estado"].ToString();
                                lblFechaSolicitud.Text = Convert.ToDateTime(rdr["fecha_solicita"]).ToString("dd/MM/yyyy HH:mm");

                                lblProductoActualizado.Text = rdr["nombre_producto"].ToString();
                                lblNewDescripción.Text = rdr["descripcion"].ToString();
                                lblNewPrecioUnitario.Text = Convert.ToDecimal(rdr["precio"]).ToString("C2");
                                lblCantidadAñadida.Text = rdr["stock"].ToString();
                                lblNewFechaVencimiento.Text = Convert.ToDateTime(rdr["fecha_vencimiento"]).ToString("yyyy-MM-dd");

                                //lblDescripción.Text = $"Cambio solicitado para '{rdr["nombre_producto"]}':\n" +
                                  //                    $"- Nueva descripción: {rdr["descripcion"]}\n" +
                                    //                  $"- Nuevo precio: {Convert.ToDecimal(rdr["precio"]):C2}\n" +
                                      //                $"- Nuevo stock: {rdr["stock"]}\n" +
                                        //              $"- Fecha vencimiento: {Convert.ToDateTime(rdr["fecha_vencimiento"]):yyyy-MM-dd}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al mostrar los detalles:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CargarPendientes()
        {
            dgvSolicitudesPendientes.Rows.Clear();

            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = ConexionDB.Conexion();
                if (conn == null) return;

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = @"
            SELECT aa.id_aprobacion,
                   u.nombre AS usuario_nombre,
                   'Actualizar producto' AS tipo_proceso,
                   CONCAT('Producto ID ', aa.id_producto, 
                          ' | Nueva desc: ', aa.descripcion, 
                          ' | Precio: ', aa.precio,
                          ' | Stock: ', aa.stock,
                          ' | Vence: ', DATE_FORMAT(aa.fecha_vencimiento, '%Y-%m-%d')) AS descripcion,
                   aa.fecha_solicita
              FROM aprobaciones_almacen aa
              JOIN usuarios u ON aa.usuario_solicita = u.id_usuario
             WHERE aa.estado = 'Pendiente'
             ORDER BY aa.fecha_solicita DESC;";

                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int idAp = rdr.GetInt32("id_aprobacion");
                    string usuarioNom = rdr.GetString("usuario_nombre");
                    string tipo = rdr.GetString("tipo_proceso");
                    string desc = rdr.IsDBNull(rdr.GetOrdinal("descripcion")) ? "" : rdr.GetString("descripcion");
                    string fecha = rdr.GetDateTime("fecha_solicita").ToString("g");

                    int idx = dgvSolicitudesPendientes.Rows.Add();
                    dgvSolicitudesPendientes.Rows[idx].Cells["dgvUsuarioSolicitud"].Value = usuarioNom;
                    dgvSolicitudesPendientes.Rows[idx].Cells["dgvTipoProceso"].Value = tipo;
                    dgvSolicitudesPendientes.Rows[idx].Cells["dgvDescripcion"].Value = desc;
                    dgvSolicitudesPendientes.Rows[idx].Cells["dgvFechaSolicitud"].Value = fecha;
                    dgvSolicitudesPendientes.Rows[idx].Tag = idAp;
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show($"MySQL Error en CargarPendientes():\nCódigo: {mex.Number}\nMensaje: {mex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general en CargarPendientes():\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null && !rdr.IsClosed) rdr.Close();
                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
            }
        }

        

        

        private void dgvHistorialSolicitudes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTipoProceso_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        

        private void lblFechaSolicitud_Click(object sender, EventArgs e)
        {

        }

        private void dgvSolicitudesPendientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSolicitudesPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvSolicitudesPendientes.Rows[e.RowIndex];
            if (fila.Tag == null) return;

            int id = Convert.ToInt32(fila.Tag);
            idAprobacionSeleccionada = id;
            MostrarDetalles(id);
        }

        private void btnAprobarProceso_Click(object sender, EventArgs e)
        {
            if (idAprobacionSeleccionada < 0)
            {
                MessageBox.Show("Seleccione una solicitud primero.");
                return;
            }

            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();

                    // 1. Obtener la solicitud aprobada
                    string selectSql = @"
                SELECT id_producto, descripcion, precio, stock, fecha_vencimiento
                FROM aprobaciones_almacen
                WHERE id_aprobacion = @id";

                    int idProducto;
                    string nuevaDescripcion;
                    decimal nuevoPrecio;
                    int nuevoStock;
                    DateTime nuevaFechaVenc;

                    using (var cmd = new MySqlCommand(selectSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idAprobacionSeleccionada);

                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (!rdr.Read())
                            {
                                MessageBox.Show("No se encontró la solicitud.");
                                return;
                            }

                            idProducto = rdr.GetInt32("id_producto");
                            nuevaDescripcion = rdr.GetString("descripcion");
                            nuevoPrecio = rdr.GetDecimal("precio");
                            nuevoStock = rdr.GetInt32("stock");
                            nuevaFechaVenc = rdr.GetDateTime("fecha_vencimiento");
                        }
                    }

                    using (var trans = conn.BeginTransaction())
                    {
                        // 2. Actualizar el producto
                        string updateProducto = @"
                    UPDATE productos
                       SET descripcion = @desc,
                           precio = @precio,
                           stock = @stock,
                           fecha_vencimiento = @venc
                     WHERE id_producto = @idProd";

                        using (var cmdUpdate = new MySqlCommand(updateProducto, conn, trans))
                        {
                            cmdUpdate.Parameters.AddWithValue("@desc", nuevaDescripcion);
                            cmdUpdate.Parameters.AddWithValue("@precio", nuevoPrecio);
                            cmdUpdate.Parameters.AddWithValue("@stock", nuevoStock);
                            cmdUpdate.Parameters.AddWithValue("@venc", nuevaFechaVenc);
                            cmdUpdate.Parameters.AddWithValue("@idProd", idProducto);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        // 3. Marcar como aprobada
                        string updateEstado = @"
                    UPDATE aprobaciones_almacen
                       SET estado = 'Aprobada',
                           usuario_responde = @uid,
                           nombre_responde = @nombre,
                           fecha_respuesta = NOW()
                     WHERE id_aprobacion = @id";

                        using (var cmdAprob = new MySqlCommand(updateEstado, conn, trans))
                        {
                            cmdAprob.Parameters.AddWithValue("@id", idAprobacionSeleccionada);
                            cmdAprob.Parameters.AddWithValue("@uid", idUsuarioGerente);
                            cmdAprob.Parameters.AddWithValue("@nombre", nombreUsuarioGerente);
                            cmdAprob.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }

                    MessageBox.Show("Solicitud aprobada y producto actualizado correctamente.");

                    CargarPendientes(); // recargá el DataGridView
                    LimpiarLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aprobar la solicitud:\n" + ex.Message);
            }
        }

        private void btnRechazarSolicitud_Click(object sender, EventArgs e)
        {
            if (idAprobacionSeleccionada < 0)
            {
                MessageBox.Show("Seleccione una solicitud primero.");
                return;
            }

            try
            {
                using (var conn = ConexionDB.Conexion())
                {
                    conn.Open();

                    string sql = @"
                UPDATE aprobaciones_almacen
                   SET estado = 'Rechazada',
                       usuario_responde = @uid,
                       nombre_responde = @nombre,
                       fecha_respuesta = NOW(),
                       observacion = 'Rechazada por el gerente'
                 WHERE id_aprobacion = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idAprobacionSeleccionada);
                        cmd.Parameters.AddWithValue("@uid", idUsuarioGerente);
                        cmd.Parameters.AddWithValue("@nombre", nombreUsuarioGerente);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Solicitud rechazada.");

                    CargarPendientes();
                    LimpiarLabels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al rechazar la solicitud:\n" + ex.Message);
            }
        }

        private void LimpiarLabels()
        {
            lblNombreSolicitante.Text = "-";
            lblTipoProceso.Text = "-";
            lblEstado.Text = "-";
            lblFechaSolicitud.Text = "-";
            lblProductoActualizado.Text = "-";
            lblCantidadAñadida.Text = "-";
            lblNewDescripción.Text = "-";
            lblNewPrecioUnitario.Text = "-";
            lblNewFechaVencimiento.Text = "-";

            idAprobacionSeleccionada = -1;
        }
    }
}
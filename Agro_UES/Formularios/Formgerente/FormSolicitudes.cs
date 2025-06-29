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





        public FormSolicitudes()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormSolicitudes_Load);
        }

        private void FormSolicitudes_Load(object sender, EventArgs e)
        {
            CargarPendientes();
            CargarHistorial();
        }


        private void MostrarDetalles(int idAprob)
        {
            using (MySqlConnection conn = ConexionDB.Conexion())
            {
                // 1) Si el helper devolvió null, salimos
                if (conn == null)
                    return;

                // 2) Si no está abierta, la abrimos aquí
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                // 3) Tu consulta sigue igual
                string sql = @"
            SELECT a.usuario_id,
                   u.nombre       AS usuario_nombre,
                   a.tipo_proceso,
                   a.descripcion,
                   a.estado,
                   a.fecha_hora
              FROM aprobaciones a
              JOIN usuarios u ON a.usuario_id = u.id_usuario
             WHERE a.id_aprobacion = @id;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idAprob);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            lblSolicitudUsuario.Text = rdr.GetString("usuario_nombre");
                            lblTipoProceso.Text = rdr.GetString("tipo_proceso");
                            lblDescripción.Text = rdr.IsDBNull(rdr.GetOrdinal("descripcion"))
                                                        ? ""
                                                        : rdr.GetString("descripcion");
                            lblEstado.Text = rdr.GetString("estado");
                            lblFechaSolicitud.Text = rdr.GetDateTime("fecha_hora")
                                                           .ToString("g");
                        }
                    }
                }
            }
        }


        private void CargarHistorial()
        {
            dgvHistorialSolicitudes.Rows.Clear();

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
            SELECT a.id_aprobacion,
                   u.nombre      AS usuario_nombre,
                   a.tipo_proceso,
                   a.descripcion,
                   a.fecha_hora
              FROM aprobaciones a
              JOIN usuarios u ON a.usuario_id = u.id_usuario
             WHERE a.estado IN ('aprobado', 'rechazado')
             ORDER BY a.fecha_hora DESC;";

                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int idAp = rdr.GetInt32("id_aprobacion");
                    string usuario = rdr.GetString("usuario_nombre");
                    string tipo = rdr.GetString("tipo_proceso");
                    string desc = rdr.IsDBNull(rdr.GetOrdinal("descripcion")) ? "" : rdr.GetString("descripcion");
                    string fecha = rdr.GetDateTime("fecha_hora").ToString("g");

                    int idx = dgvHistorialSolicitudes.Rows.Add();
                    dgvHistorialSolicitudes.Rows[idx].Cells["dgvUsuarioSolicitud2"].Value = usuario;
                    dgvHistorialSolicitudes.Rows[idx].Cells["dgvTipoProceso2"].Value = tipo;
                    dgvHistorialSolicitudes.Rows[idx].Cells["dgvDescripcion2"].Value = desc;
                    dgvHistorialSolicitudes.Rows[idx].Cells["dgvFechaSolicitud2"].Value = fecha;
                    dgvHistorialSolicitudes.Rows[idx].Tag = idAp;
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show(
                    $"MySQL Error en CargarHistorial():\nCódigo: {mex.Number}\nMensaje: {mex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error general en CargarHistorial():\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null && !rdr.IsClosed) rdr.Close();
                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
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
                // 1) Obtengo la conexión
                conn = ConexionDB.Conexion();
                if (conn == null) return;  // si tu helper ya mostró el error, salgo

                // 2) Aseguro que esté abierta
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                // 3) Preparo la consulta
                string sql = @"
            SELECT a.id_aprobacion,
                   u.nombre      AS usuario_nombre,
                   a.tipo_proceso,
                   a.descripcion,
                   a.fecha_hora
              FROM aprobaciones a
              JOIN usuarios u ON a.usuario_id = u.id_usuario
             WHERE a.estado = 'pendiente'
             ORDER BY a.fecha_hora DESC;";

                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                // 4) Cargo filas
                while (rdr.Read())
                {
                    int idAp = rdr.GetInt32("id_aprobacion");
                    string usuarioNom = rdr.GetString("usuario_nombre");
                    string tipo = rdr.GetString("tipo_proceso");
                    string desc = rdr.IsDBNull(rdr.GetOrdinal("descripcion"))
                                        ? ""
                                        : rdr.GetString("descripcion");
                    string fecha = rdr.GetDateTime("fecha_hora").ToString("g");

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
                // Error específico de MySQL
                MessageBox.Show(
                    $"MySQL Error en CargarPendientes():\nCódigo: {mex.Number}\nMensaje: {mex.Message}",
                    "Error de Base de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Cualquier otro
                MessageBox.Show(
                    $"Error general en CargarPendientes():\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cleanup
                if (rdr != null && !rdr.IsClosed) rdr.Close();
                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void dgvSolicitudesPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvSolicitudesPendientes.Rows[e.RowIndex];
            if (fila.Tag == null) return;

            int id = Convert.ToInt32(fila.Tag);
            MostrarDetalles(id);
        }

        private void dgvHistorialSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHistorialSolicitudes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
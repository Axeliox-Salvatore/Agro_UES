using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Agro_UES.FormLogin;



namespace Agro_UES
{
    public partial class ReportesGenerales : Form
    {
        public ReportesGenerales()
        {
            InitializeComponent();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarSesionUsuario();
        }

        private void CerrarSesionUsuario()
        {
            string cerrarSesion = "UPDATE usuarios SET sesion_activa = FALSE WHERE id_usuario = @idUsuario";

            using (MySqlConnection conexion = new ConexionDB().Conectar())
            {
                using (MySqlCommand comando = new MySqlCommand(cerrarSesion, conexion))
                {
                    comando.Parameters.AddWithValue("@idUsuario", UsuarioSesion.IdUsuarioActual);
                    comando.ExecuteNonQuery();
                }
            }
            Console.WriteLine("🔒 Sesión cerrada correctamente.");
        }

        // Evento para cuando se hace clic en las celdas, si se necesita (puede quedar vacío)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Evento que se dispara al cambiar la selección en los ComboBox.
        private void ActualizarReporte()
        {
            // Por ejemplo, "2024" o "Todo" para el año; "Enero" o "Todo" para el mes.
            string anioSeleccionado = cbAños.SelectedItem.ToString();
            string mesSeleccionado = cbMeses.SelectedItem.ToString();
            CargarReporte(anioSeleccionado, mesSeleccionado);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMeses.SelectedIndex != -1)
                ActualizarReporte();
        }

        private void cbMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAños.SelectedIndex != -1)
                ActualizarReporte();
        }

        private void CargarReporte(string yearSelected, string monthSelected)
        {
            // Evita la autogeneración de columnas y limpia el DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();

            // Construcción de la consulta base con el cálculo de meses con ventas
            string consulta = @"
        SELECT 
            p.id_producto,
            p.nombre,
            SUM(dv.cantidad) AS cantidad_vendida,
            SUM(dv.cantidad * p.precio) AS total_ventas,
            COUNT(DISTINCT CONCAT(YEAR(v.fecha_venta), '-', MONTH(v.fecha_venta))) AS meses_con_ventas
        FROM ventas v
        JOIN detalle_ventas dv ON v.id_venta = dv.venta_id
        JOIN productos p ON dv.producto_id = p.id_producto";

            // Construir condiciones dinámicamente usando los filtros de los ComboBox.
            List<string> conditions = new List<string>();
            if (!yearSelected.Equals("Todo", StringComparison.OrdinalIgnoreCase))
            {
                conditions.Add("YEAR(v.fecha_venta) = @anio");
            }
            if (!monthSelected.Equals("Todo", StringComparison.OrdinalIgnoreCase))
            {
                conditions.Add("MONTH(v.fecha_venta) = @mes");
            }
            if (conditions.Count > 0)
            {
                consulta += " WHERE " + string.Join(" AND ", conditions);
            }
            consulta += " GROUP BY p.id_producto, p.nombre ORDER BY total_ventas DESC;";

            using (MySqlConnection conexion = new ConexionDB().Conectar())
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    // Agrega los parámetros según corresponda
                    if (!yearSelected.Equals("Todo", StringComparison.OrdinalIgnoreCase))
                    {
                        comando.Parameters.AddWithValue("@anio", Convert.ToInt32(yearSelected));
                    }
                    if (!monthSelected.Equals("Todo", StringComparison.OrdinalIgnoreCase))
                    {
                        int mesNumero = MesToNumber(monthSelected);
                        comando.Parameters.AddWithValue("@mes", mesNumero);
                    }
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            int idProducto = Convert.ToInt32(lector["id_producto"]);
                            string nombreProducto = lector["nombre"].ToString();
                            int productosVendidos = Convert.ToInt32(lector["cantidad_vendida"]);
                            decimal totalVentas = Convert.ToDecimal(lector["total_ventas"]);
                            int mesesConVentas = Convert.ToInt32(lector["meses_con_ventas"]);

                            // Calcular el promedio mensual dividiendo el total entre la cantidad de meses en que se registraron ventas
                            decimal promedioMensual = (mesesConVentas > 0) ? totalVentas / mesesConVentas : totalVentas;
                            decimal promedioSemanal = promedioMensual / 4;

                            // Agregar la fila al DataGridView respetando el orden definido:
                            // 0: dgvIdProducto, 1: dgNombreProducto, 2: dgvVentasTotales,
                            // 3: dgvPromedioVentasMensuales, 4: dgvPromedioVentasSemanales,
                            // 5: dgvProductosVendidos.
                            dataGridView1.Rows.Add(
                                idProducto,
                                nombreProducto,
                                totalVentas,
                                promedioMensual,
                                promedioSemanal,
                                productosVendidos
                            );
                        }
                    }
                }
            }
        }

        // Método auxiliar para convertir el nombre del mes a su número (Enero = 1, Febrero = 2, etc.)
        private int MesToNumber(string monthName)
        {
            Dictionary<string, int> meses = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Enero", 1},
                {"Febrero", 2},
                {"Marzo", 3},
                {"Abril", 4},
                {"Mayo", 5},
                {"Junio", 6},
                {"Julio", 7},
                {"Agosto", 8},
                {"Septiembre", 9},
                {"Octubre", 10},
                {"Noviembre", 11},
                {"Diciembre", 12}
            };

            return meses.ContainsKey(monthName) ? meses[monthName] : 0;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox de años: "Todo" + años desde 2022 hasta el año actual.
            cbAños.Items.Add("Todo");
            for (int año = 2022; año <= DateTime.Now.Year; año++)
            {
                cbAños.Items.Add(año.ToString());
            }

            // Llenar el ComboBox de meses: "Todo" + nombres de los meses.
            cbMeses.Items.Add("Todo");
            cbMeses.Items.AddRange(new string[] {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            });

            cbAños.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMeses.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configurar las columnas manualmente si aún no existen, respetando el orden adecuado.
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("dgvIdProducto", "ID Producto");
                dataGridView1.Columns.Add("dgNombreProducto", "Nombre del Producto");
                dataGridView1.Columns.Add("dgvVentasTotales", "Ventas Totales");
                dataGridView1.Columns.Add("dgvPromedioVentasMensuales", "Promedio Mensual");
                dataGridView1.Columns.Add("dgvPromedioVentasSemanales", "Promedio Semanal");
                dataGridView1.Columns.Add("dgvProductosVendidos", "Productos Vendidos");
            }
        }
    }
}
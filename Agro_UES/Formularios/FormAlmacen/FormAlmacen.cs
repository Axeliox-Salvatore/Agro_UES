using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agro_UES.Formularios.FormAlmacen;

namespace Agro_UES
{
    public partial class FormAlmacen : Form
    {
        private int idUsuarioActual;
        private string nombreUsuarioActual;
        private string rolUsuarioActual;

        public FormAlmacen(int id, string nombre, string rol)
        {
            InitializeComponent();
            idUsuarioActual = id;
            nombreUsuarioActual = nombre;
            rolUsuarioActual = rol;
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            var frm = new Registrarproducto(idUsuarioActual, nombreUsuarioActual);
            frm.ShowDialog();
            
        }

        private void btnactualizarinv_Click(object sender, EventArgs e)
        {
            var frm = new ActualizarProductos(idUsuarioActual, nombreUsuarioActual);
            frm.ShowDialog();
            
        }

        private void btncategorias_Click(object sender, EventArgs e)
        {
            var frm = new GestionCategorias(idUsuarioActual, nombreUsuarioActual);
            frm.ShowDialog();
            
        }

        private void btnalertas_Click(object sender, EventArgs e)
        {
            var frm = new GenerarAlertas();
            frm.ShowDialog();
           
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

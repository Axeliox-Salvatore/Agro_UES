using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agro_UES.Formularios.FormDevolucion
{
    public partial class FormDevoluciones: Form
    {
        private int idUsuarioActual;
        private string nombreUsuarioActual;
        private string rolUsuarioActual;

        public FormDevoluciones(int idUsuario, string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
            nombreUsuarioActual = nombreUsuario;
            rolUsuarioActual = rolUsuario;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agro_UES
{
    public partial class FormGerente: Form
    {
        private int idUsuarioActual;
        private string nombreUsuarioActual;
        private string rolUsuarioActual;
        public FormGerente(int id, string nombre, string rol)
        {
            InitializeComponent();
            idUsuarioActual = id;
            nombreUsuarioActual = nombre;
            rolUsuarioActual = rol;


        }
    }
}

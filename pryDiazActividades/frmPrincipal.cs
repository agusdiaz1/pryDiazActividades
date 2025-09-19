using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryDiazActividades
{
    public partial class frmPrincipal : Form
    {
        conexionBD conexion = new conexionBD();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar frmAgregar = new frmAgregar();
            frmAgregar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvActividades.Rows.Count > 0)
                {
                    dgvActividades.Rows.RemoveAt(dgvActividades.SelectedRows[0].Index);
                }
            }
            catch 
            {
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
                if (dgvActividades.Rows.Count > 0 && dgvActividades.CurrentRow != null)
                {
                    string id = dgvActividades.CurrentRow.Cells[0].Value.ToString();

                    int Id;
                    if (int.TryParse(id, out Id))
                    {
                        conexion.EliminarActividad(Id);
                        conexion.listarActividades(dgvActividades);
                    }
                    else
                    {
                        MessageBox.Show("El ID seleccionado no es válido.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una actividad primero.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar actividad: " + ex.Message);
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            conexion.listarActividades(dgvActividades);
        }
    }
}

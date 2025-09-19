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
    public partial class frmAgregar : Form
    {
        conexionBD conexion = new conexionBD();
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Actividad nuevaActividad = new Actividad();

            nuevaActividad.nombreActividad = txtActividad.Text;
            nuevaActividad.fechaVencimiento = dtpVencimiento.Value;
            nuevaActividad.observacion = txtObservacion.Text;

            try
            {
                if(txtActividad.Text != "")
                {
                    conexion.AgregarActividades(nuevaActividad);
                    MessageBox.Show("¡Actividad agregada correctamente!");
                    LimpiarCampos();
                    //conexion.listarActividades(dgvActividades);
                }
                else
                {
                    MessageBox.Show("Llenar el campo Actividad y elegir una fecha futura");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar actividad: " + ex.Message);
            }
        }

        public void LimpiarCampos()
        {
            txtActividad.Clear();
            txtObservacion.Clear();
        }
    }
}

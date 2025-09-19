using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryDiazActividades
{
    public class conexionBD
    {
        OleDbConnection conexion;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;

        string cadena;
        public conexionBD()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0 ;Data Source= ../../../BD/Actividades.accdb";
        }

        public void listarActividades(DataGridView dgvActividades)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Usuarios";

                DataTable tablaActividades = new DataTable();

                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(tablaActividades);

                dgvActividades.DataSource = tablaActividades;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AgregarActividades(Actividad nuevaActividad)
        {
            using (OleDbConnection conexion = new OleDbConnection(cadena))
            {
                using (OleDbCommand comando = new OleDbCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO Actividades (Asunto, Fecha, Observacion) " +
                               "VALUES (@Asunto, @Fecha, @Observacion)";

                    comando.Parameters.AddWithValue("@Asunto", nuevaActividad.nombreActividad);
                    comando.Parameters.AddWithValue("@Fecha", nuevaActividad.fechaVencimiento);
                    comando.Parameters.AddWithValue("@Observacion", nuevaActividad.observacion);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción (por ejemplo, mostrar un mensaje de error al usuario)
                        MessageBox.Show("Error al agregar la actividad: " + ex.Message);
                    }
                }
            }

        }

        public void EliminarActividad(int id)
        {
            using (OleDbConnection conexion = new OleDbConnection(cadena))
            {
                using (OleDbCommand comando = new OleDbCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = @"DELETE FROM Actividades WHERE Id = @id";

                    // Agregar el parámetro
                    comando.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Actividad eliminada correctamente.");

                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna actividad con el ID especificado.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar actividad: " + ex.Message);
                    }
                }
            }
        }
    }
}

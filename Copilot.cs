using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase3_BD_2022_Joel_Gramajo
{
    internal class Copilot
    {
        public Copilot()
        {

        }

        public void ShowErr(Form parent, string msg)
        {
            MessageBox.Show(parent, msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowInfo(Form parent, string msg)
        {
            MessageBox.Show(parent, msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DataTable ExecuteCommand(string command)
        {
            DataTable outputData = new DataTable();

            using (SqlConnection conex = new SqlConnection("Server=LAPTOP-GH0QKC17; Database=proyectoFinalBD; User Id=sa; Password=database;"))
            {
                // --- conexion con sql server ---
                conex.Open();
                SqlCommand comando = new SqlCommand(command, conex);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(outputData);
                // --- FIN  ---
            }

            return outputData;
        }

        public string GetFieldOfSelectedRowFromDataGridView(DataGridView gb, int indexOfField)
        {
            return gb.Rows[gb.SelectedCells[0].RowIndex].Cells[indexOfField].Value.ToString();
        }
    }
}

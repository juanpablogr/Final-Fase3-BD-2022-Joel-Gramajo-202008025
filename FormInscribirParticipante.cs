using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase3_BD_2022_Joel_Gramajo
{
    public partial class FormInscribirParticipante : Form
    {
        Copilot copilot = new Copilot();

        public FormInscribirParticipante()
        {
            InitializeComponent();
        }

        private void FormInscribirParticipante_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = copilot.ExecuteCommand("Select * From Torneo");
            dataGridView2.DataSource = copilot.ExecuteCommand("Select NickName From Participante");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string costo = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView1, 2);
                string nickname = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView2, 0);
                string idtorneo = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView1, 0);

                copilot.ExecuteCommand("Insert Into Inscribe (FechaRecibo, CantidadRecibida, NickName, Idtorneo) values (" +
                    "TO_DATE('" + DateTime.Now.ToString("d") + "', 'MM/DD/AAAA')," +
                    "" + costo + "," +
                    "'" + nickname + "'," +
                    "" + idtorneo + "" +
                    ")");

                DataTable dt = copilot.ExecuteCommand("Select * From Cliente Where NickName like '" + nickname + "'");

                FormRecibo f = new FormRecibo();
                f.labelNombre.Text = dt.Rows[0].Field<string>("PrimerNombre") + " " + dt.Rows[0].Field<string>("PrimerApellido");
                f.labelCantidad.Text = costo;
                f.ShowDialog();

                this.Dispose();
            }
            catch (Exception ex)
            {
                copilot.ShowErr(this, "Recuerde seleccionar un torneo y un participante!");
            }
        }
    }
}

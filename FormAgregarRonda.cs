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
    public partial class FormAgregarRonda : Form
    {
        Copilot copilot = new Copilot();

        public FormAgregarRonda()
        {
            InitializeComponent();
        }

        private void FormAgregarRonda_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = copilot.ExecuteCommand("Select * From Torneo");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string a = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView1, 0);
            DataTable dt = copilot.ExecuteCommand("Select * From Ronda Where IdTorneo=" + a);
            label1.Text = (dt.Rows.Count + 1) + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string c = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView1, 0);

                copilot.ExecuteCommand("Insert Into Ronda (NumeroRonda, DescripRonda, FechaHora, IdTorneo) values (" +
                    "" + label1.Text + "," +
                    "'" + textBox4.Text + "'," +
                    "TO_DATE('" +  DateTime.Parse(maskedTextBox1.Text) + "', 'MM/DD/AAAA HH:mm')," +
                    "" + c + "" +
                    ")");

                this.Dispose();
            }
            catch (Exception ex)
            {
                copilot.ShowErr(this, "Recuerde ingresar datos válidos!");
            }
        }
    }
}

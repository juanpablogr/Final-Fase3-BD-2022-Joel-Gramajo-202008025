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
    public partial class FormResultadoRonda : Form
    {
        Copilot copilot = new Copilot();

        public FormResultadoRonda()
        {
            InitializeComponent();
        }

        private void FormResultadoRonda_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = copilot.ExecuteCommand("Select * From Torneo");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string a = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView1, 0);
            dataGridView2.DataSource = copilot.ExecuteCommand("Select * From Ronda Where IdTorneo=" + a);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            string a = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView1, 0); // IdTorneo
            dataGridView3.DataSource = copilot.ExecuteCommand("Select * From Inscribe Where IdTorneo=" + a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string a = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView3, 3);
                string b = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView2, 0);


                copilot.ExecuteCommand("Insert Into Participa (PosicionFinRond, PunteoObtenido, NickName, IdRonda) values (" +
                    "" + 0 + "," +
                    "" + textBox5.Text + "," +
                    "'" + a + "'," +
                    "" + b + "," +
                    ")");

                this.Dispose();
            }
            catch (Exception ex)
            {
                copilot.ShowErr(this, "Por favor, Ingrese datos válidos!");
            }
        }
    }
}

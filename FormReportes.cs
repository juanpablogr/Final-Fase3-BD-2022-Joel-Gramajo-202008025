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
    public partial class FormReportes : Form
    {
        Copilot copilot = new Copilot();

        public FormReportes()
        {
            InitializeComponent();
        }

        void RefreshInforme1()
        {
            label4.Text = copilot.ExecuteCommand("Select Sum(CantidadRecibida) as T From Inscribe").Rows[0].Field<float>("T").ToString();
            dataGridView1.DataSource = copilot.ExecuteCommand("Select T.NombreTorneo, Sum(I.CantidadRecibida) Where T.IdTorneo=I.IdTorneo Group by T.NombreTorneo");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            RefreshInforme1();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
            RefreshInforme1();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            dataGridView7.DataSource = copilot.ExecuteCommand("Select * From Torneo");
            dataGridView6.DataSource = copilot.ExecuteCommand("Select * From Torneo");
            dataGridView4.DataSource = copilot.ExecuteCommand("Select NickName, Count(*) as Total From Participa Group by NickName Order by Total desc");
            dataGridView5.DataSource = copilot.ExecuteCommand("Select * From Torneo Where FechaRealiza <= CAST('" + DateTime.Now.ToString("d") + "' AS datetime");
        }

        private void dataGridView7_SelectionChanged(object sender, EventArgs e)
        {
            string idtorneo = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView7, 0);
            label12.Text = copilot.ExecuteCommand("Select Count(*) as T From Ronda Where IdTorneo=" + idtorneo).Rows[0].Field<int>("T").ToString();
        }

        private void dataGridView6_SelectionChanged(object sender, EventArgs e)
        {
            string idtorneo = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView6, 0);
            dataGridView2.DataSource = copilot.ExecuteCommand("Select * From Inscribe Where IdTorneo=" + idtorneo);
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            string nickname = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView2, 3);
            dataGridView3.DataSource = copilot.ExecuteCommand("Select * From Cliente Where NickName like '" + nickname +"'");
        }
    }
}

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
        bool ban = false;

        public FormReportes()
        {
            InitializeComponent();
        }

        void RefreshInforme1()
        {
            dataGridView8.DataSource = copilot.ExecuteCommand("Select Sum(CantidadRecibida) as Total From Inscribe Where FechaRecibo between '" + dateTimePicker1.Value.ToString("d") + "' and '" + dateTimePicker2.Value.ToString("d") + "'");
            dataGridView1.DataSource = copilot.ExecuteCommand("Select T.NombreTorneo, Sum(I.CantidadRecibida) From Torneo as T, Inscribe as I Where T.IdTorneo=I.IdTorneo and I.FechaRecibo between '" + dateTimePicker1.Value.ToString("d") + "' and '" + dateTimePicker2.Value.ToString("d") + "'" + " Group by T.NombreTorneo");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
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
            dataGridView5.DataSource = copilot.ExecuteCommand("Select * From Torneo Where FechaRealiza >= '" + DateTime.Now.ToString("d") + "'");
            ban = true;
        }

        private void dataGridView7_SelectionChanged(object sender, EventArgs e)
        {
            if (ban)
            {
                string idtorneo = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView7, 0);
                label12.Text = copilot.ExecuteCommand("Select Count(*) as T From Ronda Where IdTorneo=" + idtorneo).Rows[0].Field<int>("T").ToString();
            }
        }

        private void dataGridView6_SelectionChanged(object sender, EventArgs e)
        {
            if (ban)
            {
                string idtorneo = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView6, 0);
                dataGridView2.DataSource = copilot.ExecuteCommand("Select * From Inscribe Where IdTorneo=" + idtorneo);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (ban)
            {
                string nickname = copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView2, 3);
                dataGridView3.DataSource = copilot.ExecuteCommand("Select * From Cliente Where NickName like '" + nickname + "'");
            }
        }
    }
}

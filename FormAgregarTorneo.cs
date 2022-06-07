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
    public partial class FormAgregarTorneo : Form
    {
        Copilot copilot = new Copilot();

        public FormAgregarTorneo()
        {
            InitializeComponent();
        }

        private void FormAgregarTorneo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = copilot.ExecuteCommand("Select * From Videojuego");
            dataGridView2.DataSource = copilot.ExecuteCommand("Select * From Premio");
            dataGridView3.DataSource = copilot.ExecuteCommand("Select * From Premio");
            dataGridView4.DataSource = copilot.ExecuteCommand("Select * From Premio");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int idv = Convert.ToInt32(copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView1, 0));

                int w1 = Convert.ToInt32(copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView2, 0));
                int w2 = Convert.ToInt32(copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView3, 0));
                int w3 = Convert.ToInt32(copilot.GetFieldOfSelectedRowFromDataGridView(dataGridView4, 0));


                // agrega nuevo torneo
                copilot.ExecuteCommand("Insert Into Torneo (NombreTorneo, CostoInscrip, FechaApertInsc, FechaFinInsc, FechaRealiza, DescTorneo, NumeroRondas, IdVideojuego) values (" +
                    "'" + textBox1.Text + "'," +
                    "" + textBox2.Text + "," +
                    "'" + dateTimePicker1.Value.ToString("d") + "'," +
                    "'" + dateTimePicker2.Value.ToString("d") + "'," +
                    "'" + dateTimePicker3.Value.ToString("d") + "'," +
                    "'" + textBox3.Text + "'," +
                    "" + 0 + "," +
                    "" + idv + "" +
                    ")");

                MessageBox.Show("Torneo agregado con exito!");


                DataTable a = copilot.ExecuteCommand("Select * From Torneo");
                int b = a.Rows[a.Rows.Count - 1].Field<int>("IdTorneo");

                // asigna premios a torneo
                copilot.ExecuteCommand("Insert Into Otorga (OtorgaAPosicion, IdTorneo, IdPremio) values (" +
                    "" + 1 + "," +
                    "" + b + "," +
                    "" + w1 + "" +
                    ")");

                copilot.ExecuteCommand("Insert Into Otorga (OtorgaAPosicion, IdTorneo, IdPremio) values (" +
                    "" + 2 + "," +
                    "" + b + "," +
                    "" + w2 + "" +
                    ")");

                copilot.ExecuteCommand("Insert Into Otorga (OtorgaAPosicion, IdTorneo, IdPremio) values (" +
                    "" + 3 + "," +
                    "" + b + "," +
                    "" + w3 + "" +
                    ")");

                this.Dispose();
            }
            catch (Exception ex)
            {
                copilot.ShowErr(this, "Recuerde ingresar datos válidos y seleccionar premios para cada posición determinada");
            }
        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregarTorneo f = new FormAgregarTorneo();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAgregarRonda f = new FormAgregarRonda();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormResultadoRonda f = new FormResultadoRonda();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormInscribirParticipante f = new FormInscribirParticipante();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormReportes f = new FormReportes();
            f.ShowDialog();
        }
    }
}

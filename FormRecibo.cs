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
    public partial class FormRecibo : Form
    {
        public FormRecibo()
        {
            InitializeComponent();
        }

        private void FormRecibo_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("G");
        }
    }
}

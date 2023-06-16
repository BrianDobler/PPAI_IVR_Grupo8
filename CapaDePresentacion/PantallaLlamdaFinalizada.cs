using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR_Grupo8.CapaDePresentacion
{
    public partial class PantallaLlamdaFinalizada : Form
    {
        public PantallaLlamdaFinalizada()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progresBar.Width += 20;
            if (progresBar.Width > 465)
            {
                timer1.Stop();
                this.Dispose();
            }
        }

    }
}

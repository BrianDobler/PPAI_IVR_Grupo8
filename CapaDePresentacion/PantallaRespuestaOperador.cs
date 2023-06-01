using PPAI_IVR_Grupo8.EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR_Grupo8
{
    public partial class PantallaRespuestaOperador : Form
    {
        public PantallaRespuestaOperador()
        {
            InitializeComponent();

            Estado estado1 = new Estado("INICIADO");
            Estado estado2 = new Estado("EnCurso");
            CambioEstado cestado1 = new CambioEstado(DateTime.Today.AddDays(-1), estado1);
            CambioEstado cestado2 = new CambioEstado(DateTime.Today.AddDays(10), estado2);
            CambioEstado cestado3 = new CambioEstado(DateTime.Today.AddDays(-15), estado2);

            List<CambioEstado> lcestadoTEST = new List<CambioEstado>();
            lcestadoTEST.Add(cestado1);
            lcestadoTEST.Add(cestado2);
            lcestadoTEST.Add(cestado3);

            MessageBox.Show((DateTime.Today.Subtract(Llamada.obtenerFechaHoraMinima(lcestadoTEST)).ToString()));

        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MenuV2_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }


        private void btnColgarLlamada_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de desea finalizar la llamada?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}

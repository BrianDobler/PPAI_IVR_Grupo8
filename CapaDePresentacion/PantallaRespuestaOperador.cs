using PPAI_IVR_Grupo8.EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using PPAI_IVR_Grupo8.CapaLogicaDeNegocio;
using System.Xml.Linq;
using System.Windows.Controls;
using Windows.UI.Xaml.Controls;

namespace PPAI_IVR_Grupo8
{
    public partial class PantallaRespuestaOperador : Form
    {
 
        Stopwatch sW = new Stopwatch();
        GestorRespuestaOperador GestorRO;
        public PantallaRespuestaOperador()
        {
            InitializeComponent();
            cambiarFormatoDataGrid();
            // generarNroAleatorio();
            GestorRO = new GestorRespuestaOperador();

        }

        #region MetodosDeInterfaz

        private void cambiarFormatoDataGrid()
        {
            txtbDescripcion.Height = 100;
            txtbDescripcion.Enabled = true;
            cmbAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            dgValidacion.DefaultCellStyle.BackColor = Color.White;
            dgValidacion.DefaultCellStyle.ForeColor = Color.Black;
            dgValidacion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 110, 86);
            dgValidacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgValidacion.DefaultCellStyle.SelectionBackColor = Color.White;
            dgValidacion.DefaultCellStyle.SelectionForeColor = Color.Black;

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

        private void PantallaRespuestaOperador_Load(object sender, EventArgs e)
        {
            sW.Start();
            Dictionary<string,object> dicci = new Dictionary<string,object>();

            OpcionLlamada opcLlamada = new OpcionLlamada();
            CategoriaLlamada catLlamada = new CategoriaLlamada();
            SubOpcionLlamada subOpcLlamada = new SubOpcionLlamada();
            dicci = GestorRO.validarOpcSeleccionada();

            foreach (KeyValuePair<string, object> datos in dicci)
            {
              if (datos.Key == "Nom_cliente")
                {
                    lblNombreCliente.Text = datos.Value.ToString();
                }
                else if (datos.Key == "Opcion")
                {

                    opcLlamada = (OpcionLlamada)datos.Value;
                    lblOpcion.Text = opcLlamada.NroOrden.ToString();
                }
               else if (datos.Key == "Categoria")
                {
                    catLlamada = (CategoriaLlamada)datos.Value;
                    lblCategoria.Text = catLlamada.NroOrden.ToString();
                }
               
              else if (datos.Key == "Orden_sopc")
                {
                    lblSubOpcion.Text = datos.Value.ToString();
                }
            }

        }
        private void LlenarGrilla(IList<Validacion> validacion)
        {
            respuestaCmbBox.DisplayMember = "Text";
            respuestaCmbBox.ValueMember = "Value";

            List<ComboBoxItem> list = new List<ComboboxItem>();

            ComboboxItem item = new ComboboxItem();
            item.Text = "choose a server...";
            item.Value = "-1";
            list.Add(item);
            dgValidacion.Rows.Clear();
            foreach (Validacion val in validacion)
            {
                DataGridViewComboBoxColumn cell = new DataGridViewComboBoxColumn();
                dgValidacion.Rows.Add(new object[]
                {
                    val.Nombre.ToString(),
                    //LlenarComboColumn(respuestaCmbBox, val.OpcValidaciones, "Descripción")
                });
                dgValidacion.Rows[0].Cells[0].Value = Nombre[contadorUsuarios + 1] = respuestaCmbBox.Text;
                dgValidacion.Rows[filas].Cells["fila1"].Value = valor;
            }
            dgValidacion.ClearSelection();
        }

        private DataGridViewComboBoxCell LlenarComboColumn(DataGridViewComboBoxColumn cbo, object source, string display)
        {
            DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
            cbo.DisplayMember = display;
            cell.DataSource = source;
            return cell;
        }

        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)sW.ElapsedMilliseconds);

            lblHora.Text = ts.Hours.ToString().PadLeft(2, '0');
            lblMinut.Text = ts.Minutes.ToString().PadLeft(2, '0');
            lblSeg.Text = ts.Seconds.ToString().PadLeft(2, '0');
        }

        #endregion
        private void generarNroAleatorio()
        {
            Random random = new Random();

            // Genera un número aleatorio entre 0 y 1
            int numeroAleatorio = random.Next(2);

            // Asigna el valor 1 o 10 según el número aleatorio generado
            int valor = numeroAleatorio == 0 ? 1 : 10;

            if (valor == 0 )
            {
                MessageBox.Show("El cliente finalizo la llamada..", "Finalizando Llamada", MessageBoxButtons.OK , MessageBoxIcon.Information );
                Application.Exit();
            }
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

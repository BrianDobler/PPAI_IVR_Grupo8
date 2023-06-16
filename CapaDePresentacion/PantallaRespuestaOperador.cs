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
using PPAI_IVR_Grupo8.EntityLayer;
using System.Diagnostics.Eventing.Reader;
using System.Management.Instrumentation;
using System.Drawing.Text;
using Newtonsoft.Json.Linq;
//using Windows.UI.Xaml.Controls;

namespace PPAI_IVR_Grupo8.CapaDePresentacion
{
    public partial class PantallaRespuestaOperador : Form
    {
 
        Stopwatch sW = new Stopwatch();
        GestorRespuestaOperador GestorRO;
        DataTable dt1 = new DataTable();
        private static PantallaRespuestaOperador instance = new PantallaRespuestaOperador(); //Implemento el Singleton
        public PantallaRespuestaOperador()
        {
            InitializeComponent();
            //generarNroAleatorio();
            GestorRO = new GestorRespuestaOperador();
            dgValidacion.Rows.Clear();

        }
        public static PantallaRespuestaOperador GetInstance()
        {
            if (instance == null)
                instance = new PantallaRespuestaOperador();
            return instance;
        }

        #region MetodosDeInterfaz

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
          
            //int segundos = Convert.ToInt32(lblSeg.Text);

            if (numeroAleatorio == 0)
            {
                MessageBox.Show("El cliente finalizo la llamada..", "Finalizando Llamada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new PantallaLlamdaFinalizada().ShowDialog();
                this.Close();
            }

        }


        private void PantallaRespuestaOperador_Load(object sender, EventArgs e)
        {
            sW.Start();
            Dictionary<string, object> dicci = new Dictionary<string, object>();
            GestorRO.validarOpcSeleccionada();

        }

        public void mostrarDatosLlamadaValidacion(Dictionary<string, object> dicci)
        {
            OpcionLlamada opcLlamada = new OpcionLlamada();
            CategoriaLlamada catLlamada = new CategoriaLlamada();
            SubOpcionLlamada subOpcLlamada = new SubOpcionLlamada();

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
                else if (datos.Key == "listValidacion")
                {
                    setValidaciones((List<Validacion>)datos.Value);
                }
            }
        }
      
        private void btnColgarLlamada_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de desea finalizar la llamada?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                new PantallaLlamdaFinalizada().ShowDialog();
                Application.Exit();
            }
        }

        //METODO VIEJO OBSOLTO TENIA CIERTOS ERRORES
        /*private void btnValidar_Click(object sender, EventArgs e)
        {
            Validacion val = dgValidacion.SelectedRows[0].DataBoundItem as Validacion;
            bool valida;
            Dictionary<Validacion,string> dic = new Dictionary<Validacion,string>();
            foreach (DataGridViewRow row in dgValidacion.Rows)
            {
                //DataGridViewComboBoxCell cboCell = (DataGridViewComboBoxCell)row.Cells[1];
                val = dgValidacion.Rows[row.Index].DataBoundItem as Validacion;
                if (row.Cells[2].Value != null)
                {
                    val = dgValidacion.Rows[row.Index].DataBoundItem as Validacion;
                    var pregunta = row.Cells[2].Value.ToString();
                    dic.Add(val, pregunta);
                    MessageBox.Show(row.Cells[2].Value.ToString());
                    //GestorRO.tomarRstaValidacion()
                }
                else
                {
                    MessageBox.Show("Se deben cargar todas las respuestas antes de enviar a validar, por favor verifique y vuelva a intentar nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
            }
            valida = GestorRO.tomarRstaValidacion(dic);

            if (valida)
                {
                    MessageBox.Show("Se validaron las preguntas correctamente, por favor ingrese una descripción y seleccione una acción." +
                        " A continuación presione el botón CONFIRMAR.","Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
                { 
                    MessageBox.Show("Alguna/s de las preguntas fue Inválida, por lo cuál esta llamada finalizara", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    new PantallaLlamdaFinalizada().ShowDialog();
                    this.Close();
                }
           
        }*/

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Dictionary<Validacion, string> dic = new Dictionary<Validacion, string>();
            foreach (DataGridViewRow row in dgValidacion.Rows)
            {
                Validacion val = row.DataBoundItem as Validacion;
                if (row.Cells[2].Value != null)
                {
                    var pregunta = row.Cells[2].Value.ToString();
                    dic.Add(val, pregunta);
                    //GestorRO.tomarRstaValidacion()
                }
                else
                {
                    MessageBox.Show("Se deben cargar todas las respuestas antes de enviar a validar, por favor verifique y vuelva a intentar nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            bool valida = GestorRO.tomarRstaValidacion(dic);

            if (valida)
            {
                MessageBox.Show("Se validaron las preguntas correctamente, por favor ingrese una descripción y seleccione una acción. A continuación presione el botón CONFIRMAR.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarPanelDescripcion();

            }
            else
            {
                MessageBox.Show("Alguna/s de las preguntas fue Inválida, por lo cuál esta llamada finalizará pronto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new PantallaLlamdaFinalizada().ShowDialog();
                this.Close();
            }
        }

        public void setValidaciones(List<Validacion> validacion)
        {

            List<Validacion> listValid = new List<Validacion>();
            foreach (Validacion valid in validacion)
            {
                listValid.Add(new Validacion(valid.NroOrden,valid.Nombre,valid.OpcValidaciones));
            }
            dgValidacion.Columns.Clear();
            dgValidacion.DataSource = listValid;
            dgValidacion.Columns["NroOrden"].Visible = false;

            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

            column.CellTemplate = dgValidacion.Columns[1].CellTemplate;
            column.AutoSizeMode = dgValidacion.Columns[1].AutoSizeMode;
            dgValidacion.Columns.Add(column);
            dgValidacion.Columns[2].HeaderCell.Value = "Pregunta";
        }

        private void dgValidacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                string valor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la respuesta del cliente para validar", "Valor");
                if (!string.IsNullOrEmpty(valor)) {
                  dgValidacion.Rows[e.RowIndex].Cells[2].Value = valor;
                }
            }
            else
            {
                dgValidacion.Columns[1].ReadOnly = true;
            }
        }
       
        public void mostrarAcciones(IList<Accion> acciones)
        {
            cmbAccion.DataSource = acciones;
            cmbAccion.DisplayMember = "Descripcion";
            cmbAccion.SelectedIndex = 0;
        }

        private void dgValidacion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string valor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la respuesta del cliente para validar", "Valor");
                if (!string.IsNullOrEmpty(valor))
                {
                    dgValidacion.Rows[e.RowIndex].Cells[2].Value = valor;
                }
            }
            else
            {
                dgValidacion.Columns[1].ReadOnly = true;
            }
        }

        private void panelDeConfirmar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Enabled == false)
            {
                MessageBox.Show("Esta deshabilitado, por favor valide primero las preguntas!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void habilitarPanelDescripcion()
        {
            txtDescripcion.Enabled = true;
            cmbAccion.Enabled = true;
            cmbAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            btnConfirmar.ActiveLineColor = Color.FromArgb(30, 137, 70);
            btnConfirmar.ActiveFillColor = Color.FromArgb(30, 137, 70);
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Enabled == false)
            {
                MessageBox.Show("Esta deshabilitado, por favor valide primero las preguntas!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var accion = cmbAccion.SelectedItem as Accion;
                var descripcion = txtDescripcion.Text;
                GestorRO.tomarConfirmacion(accion);
                GestorRO.tomarDescripcionOperador(descripcion);
                MessageBox.Show("Usted confirmo los cambios del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

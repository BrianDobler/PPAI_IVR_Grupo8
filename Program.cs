using PPAI_IVR_Grupo8.CapaDePresentacion;
using PPAI_IVR_Grupo8.CapaLogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR_Grupo8
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PantallaLlamadaEntrante());
            
            Application.Run(PantallaRespuestaOperador.GetInstance());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class CategoriaLlamada
    {
        private int nroOrden;
        private string nombre;
        private List<OpcionLlamada> lopcionLlamada;



        public int NroOrden { get => nroOrden; set => nroOrden = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<OpcionLlamada> LopcionLlamada { get => lopcionLlamada; set => lopcionLlamada = value; }
        public CategoriaLlamada() { }

        public CategoriaLlamada(int nroOrden, string nombre, List<OpcionLlamada> lopcionLlamada)
        {
            this.nroOrden = nroOrden;
            this.nombre = nombre;
            this.lopcionLlamada = lopcionLlamada;
        }

        public static bool esCategoriaSeleccionada(OpcionLlamada opcSeleccionada,CategoriaLlamada cat)
        {
            bool res = false;
            foreach(OpcionLlamada opcLlamada in cat.LopcionLlamada)
            { 
                if (opcLlamada.Equals(opcSeleccionada))
                {
                    res = true;
                }
            }
            return res;
        }
    }
}

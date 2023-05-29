using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class OpcionLlamada
    {
        private int nroOrden;
        private string nombre;
        private List<SubOpcionLlamada> lsubopcLlamada;
        private List<Validacion> lvalidacion;


        public int NroOrden { get => nroOrden; set => nroOrden = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<SubOpcionLlamada> LsubopcLlamada { get => lsubopcLlamada; set => lsubopcLlamada = value; }
        public List<Validacion> Lvalidacion { get => lvalidacion; set => lvalidacion = value; }

        public OpcionLlamada() { }

        public OpcionLlamada(int nroOrden, string nombre, List<SubOpcionLlamada> lsubopcLlamada, List<Validacion> lvalidacion)
        {
            this.nroOrden = nroOrden;
            this.nombre = nombre;
            this.lsubopcLlamada = lsubopcLlamada;
            this.lvalidacion = lvalidacion;
        }
    }
}

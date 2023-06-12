using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class Accion
    {
        private string descripcion;
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Accion() { }

        public Accion(string descripcion)
        {
            this.Descripcion = descripcion;
        }


    }
}

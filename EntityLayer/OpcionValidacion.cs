using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class OpcionValidacion
    {
        private bool correcta;
        private string descripcion;

        public bool Correcta { get => correcta; set => correcta = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public OpcionValidacion()
        {
        }
        public OpcionValidacion(bool correcta, string descripcion)
        {
            this.correcta = correcta;
            this.descripcion = descripcion;
        }


        public bool esCorrecta(OpcionValidacion val, string respuesta)
        {
            if (val.Correcta == true && val.descripcion.ToUpper().Equals(respuesta.ToUpper())) 
            {
                return true;
            }
            else { return false; }
            return false;
        }

    }
}

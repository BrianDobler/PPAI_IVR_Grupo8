using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class Validacion
    {
        private int nroOrden;
        private string nombre;
        private List<OpcionValidacion> opcValidaciones;
        public int NroOrden { get => nroOrden; set => nroOrden = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<OpcionValidacion> OpcValidaciones { get => opcValidaciones; set => opcValidaciones = value; }


        public Validacion(int nroOrden, string nombre, List<OpcionValidacion> opcValidaciones)
        {
            this.nroOrden = nroOrden;
            this.nombre = nombre;
            this.opcValidaciones = opcValidaciones;
        }

        public bool esRstaCorrecta(Validacion val,string respuesta)
        {
            foreach(OpcionValidacion opcValidacion in val.OpcValidaciones)
            {
                if (opcValidacion.esCorrecta(opcValidacion, respuesta))
                    return true;
            }
            return false;
        }

    }
}

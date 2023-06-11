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

        public Validacion()
        {
        }

        public Validacion(int nroOrden, string nombre, List<OpcionValidacion> opcValidaciones)
        {
            this.nroOrden = nroOrden;
            this.nombre = nombre;
            this.opcValidaciones = opcValidaciones;
        }

        public bool esRstaCorrecta(Validacion val,string respuesta)
        {
            //OpcionValidacion res = new OpcionValidacion();
            bool res = false;
            foreach(OpcionValidacion opcValidacion in val.OpcValidaciones)
            {
                res = opcValidacion.esCorrecta(opcValidacion, respuesta); //ideadoi para buscar una sola respuesta correcta entre muchas opciones validacion. si es ok me trae el objeto
               
            }
            return res;

            //if (res.Descripcion.Equals(respuesta))
            //{
            //    return true;
            //}
            //else { return false; }
        }

    }
}

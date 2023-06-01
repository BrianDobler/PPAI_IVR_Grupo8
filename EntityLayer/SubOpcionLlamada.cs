using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public  class SubOpcionLlamada
    {
        private int nroOrden;
        private string nombre;
        private List<Validacion> lValidacion;



        public int NroOrden { get => nroOrden; set => nroOrden = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<Validacion> LValidacion { get => lValidacion; set => lValidacion = value; }

        public SubOpcionLlamada() { }
        public SubOpcionLlamada(int nroOrden, string nombre, List<Validacion> lValidacion)
        {
            this.nroOrden = nroOrden;
            this.nombre = nombre;
            this.lValidacion = lValidacion;
        }

        public Dictionary<String, object> getDatosSubOpc(SubOpcionLlamada subOpcionLlamadaSeleccionada)
        {
            Dictionary<String, object> dictionary = new Dictionary<string, object>();
            foreach (var validacion in subOpcionLlamadaSeleccionada.lValidacion)
            {   
                dictionary.Add(this.Nombre, validacion);
            }
            return dictionary;
        }


        public static bool ObtenerRstasValidacion(Dictionary<Validacion, OpcionValidacion> param)
        {
            bool res = false;
            foreach(KeyValuePair<Validacion, OpcionValidacion> validacion in param) {

                res = Validacion.esRstaCorrecta(validacion.Key, validacion.Value);
            }

            return res;
        }

    }
}

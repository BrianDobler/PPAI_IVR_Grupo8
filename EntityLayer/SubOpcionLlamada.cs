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
            dictionary.Add("Nombre_sopc", subOpcionLlamadaSeleccionada.Nombre);
            dictionary.Add("Orden_sopc", subOpcionLlamadaSeleccionada.NroOrden);
            //var count = 0;
            dictionary.Add("listValidacion", subOpcionLlamadaSeleccionada.LValidacion);

            //foreach (var validacion in subOpcionLlamadaSeleccionada.lValidacion)
            //{
            //    count += 1;

            //    dictionary.Add("Validacion"+count.ToString(), validacion);
            //}
            return dictionary;
        }


        public bool ObtenerRstasValidacion(Dictionary<Validacion, string> param)
        {
            bool res = false;
            foreach(KeyValuePair<Validacion, string> validacion in param) {
                Validacion valid = validacion.Key;
                res = valid.esRstaCorrecta(validacion.Key, validacion.Value);
            }

            return res;
        }

    }
}

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
            Dictionary<String, object> diccionarioDatosSubOpcion = new Dictionary<string, object>();
            diccionarioDatosSubOpcion.Add("Nombre_sopc", subOpcionLlamadaSeleccionada.Nombre);
            diccionarioDatosSubOpcion.Add("Orden_sopc", subOpcionLlamadaSeleccionada.NroOrden);
            diccionarioDatosSubOpcion.Add("listValidacion", subOpcionLlamadaSeleccionada.LValidacion);

            return diccionarioDatosSubOpcion;
        }

        public bool ObtenerRstasValidacion(Dictionary<Validacion, string> param)
        {
            bool res = false;
            foreach(KeyValuePair<Validacion, string> validacion in param) {
                Validacion valid = validacion.Key;
                res = valid.esRstaCorrecta(validacion.Key, validacion.Value);
                if (!res) break;
            }
            return res;
        }

    }
}

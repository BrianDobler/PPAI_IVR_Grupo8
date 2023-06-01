using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class Llamada
    {
        private string descripcionOperador;
        private string detalleAccionRequerida;
        private DateTime duracion;
        private string observacionAuditor;
        private Cliente cliente;
        private List<CambioEstado> lcambioestado;
        private OpcionLlamada seleccionadaopc;
        private SubOpcionLlamada seleccionadaSubopc;


  

        public string DescripcionOperador { get => descripcionOperador; set => descripcionOperador = value; }
        public string DetalleAccionRequerida { get => detalleAccionRequerida; set => detalleAccionRequerida = value; }
        public DateTime Duracion { get => duracion; set => duracion = value; }
        public string ObservacionAuditor { get => observacionAuditor; set => observacionAuditor = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public List<CambioEstado> Lcambioestado { get => lcambioestado; set => lcambioestado = value; }
        public OpcionLlamada Seleccionadaopc { get => seleccionadaopc; set => seleccionadaopc = value; }
        public SubOpcionLlamada SeleccionadaSubopc { get => seleccionadaSubopc; set => seleccionadaSubopc = value; }
      public Llamada()
        {
        }
        public Llamada(string descripcionOperador, 
                      string detalleAccionRequerida, 
                      DateTime duracion, 
                      string observacionAuditor, 
                      Cliente cliente, 
                      List<CambioEstado> lcambioestado, 
                      OpcionLlamada seleccionadaopc, 
                      SubOpcionLlamada seleccionadaSubopc)
        {
            this.descripcionOperador = descripcionOperador;
            this.detalleAccionRequerida = detalleAccionRequerida;
            this.duracion = duracion;
            this.observacionAuditor = observacionAuditor;
            this.cliente = cliente;
            this.lcambioestado = lcambioestado;
            this.seleccionadaopc = seleccionadaopc;
            this.seleccionadaSubopc = seleccionadaSubopc;
        }


        public static Llamada esDeTuCliente(List<Llamada> lLlamada, Cliente clt)
        {
            Llamada actualLLamada = new Llamada();
            foreach (Llamada ll in lLlamada)
            {
                if (ll.Cliente.Equals(clt))
                {
                    actualLLamada = ll;
                }

            }
            return actualLLamada;
        }

        public static void setLlamadaEnCurso(Llamada actualLlamada, Estado enCurso)
        {
            actualLlamada.Lcambioestado.Add(new CambioEstado(DateTime.Today,enCurso));

        }

        public static void finalizar(Llamada actualLlamada, Estado finalizado)
        {
            actualLlamada.Lcambioestado.Add(new CambioEstado(DateTime.Today, finalizado));

        }


        public static void calcularDuracion(Llamada actualLlamada, DateTime fechafinalizacion) 
        {
            var fechamin = obtenerFechaHoraMinima(actualLlamada.Lcambioestado);
            var duracion = fechafinalizacion.Subtract(fechamin);
            actualLlamada.Duracion = Convert.ToDateTime(duracion);
        }

        public static DateTime obtenerFechaHoraMinima(List<CambioEstado> lCestado) 
        {

            DateTime cEstadofechaMin = lCestado
                              //.Select(x => x.FechaHoraInicio < fechaInicio).FirstOrDefault();
                              .Min(x => x.FechaHoraInicio);
            //var fechaMin = cEstadofechaMin.FechaHoraInicio;

            return cEstadofechaMin;
        
        }

        /*
        public Llamada tomarDatosLlamada()
        {
            getNombreClienteLlamada()
        }        

        public String getNombreClienteLlamada()
        {
            return this.cliente.getNombreClienteLlamada; // donde esta la instancia de este cliente ? 
        }
        */
        

    }
}

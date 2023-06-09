﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class Llamada
    {
        private string descripcionOperador;
        private string detalleAccionRequerida;
        private int duracion;
        private string observacionAuditor;
        private Cliente cliente;
        private List<CambioEstado> lcambioestado;
        private OpcionLlamada seleccionadaopc;
        private SubOpcionLlamada seleccionadaSubopc;
        private Accion accionRequerida;


  

        public string DescripcionOperador { get => descripcionOperador; set => descripcionOperador = value; }
        public string DetalleAccionRequerida { get => detalleAccionRequerida; set => detalleAccionRequerida = value; }
        public int Duracion { get => duracion; set => duracion = value; }
        public string ObservacionAuditor { get => observacionAuditor; set => observacionAuditor = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public List<CambioEstado> ListaCambioEstado { get => lcambioestado; set => lcambioestado = value; }
        public OpcionLlamada seleccionada { get => seleccionadaopc; set => seleccionadaopc = value; }
        public SubOpcionLlamada SeleccionadaSubopc { get => seleccionadaSubopc; set => seleccionadaSubopc = value; }
        public Accion AccionRequerida { get => accionRequerida; set => accionRequerida = value; }

        public Llamada(string descripcionOperador, 
                      string detalleAccionRequerida, 
                      int duracion, 
                      string observacionAuditor, 
                      Cliente cliente, 
                      List<CambioEstado> lcambioestado, 
                      OpcionLlamada seleccionadaopc, 
                      SubOpcionLlamada seleccionadaSubopc,
                      Accion accionRequerida)
        {
            this.descripcionOperador = descripcionOperador;
            this.detalleAccionRequerida = detalleAccionRequerida;
            this.duracion = duracion;
            this.observacionAuditor = observacionAuditor;
            this.cliente = cliente;
            this.lcambioestado = lcambioestado;
            this.seleccionadaopc = seleccionadaopc;
            this.seleccionadaSubopc = seleccionadaSubopc;
            this.AccionRequerida = accionRequerida;
        }

        public Llamada()
        {
        }

        public void setLlamadaEnCurso(Llamada actualLlamada,Estado enCurso, DateTime fechaHoraActual)
        {
            actualLlamada.ListaCambioEstado.Add(new CambioEstado(fechaHoraActual, enCurso));
        }

        public void finalizar(Llamada actualLlamada, Estado finalizado)
        {
            actualLlamada.ListaCambioEstado.Add(new CambioEstado(DateTime.Today, finalizado));

        }


        public void calcularDuracion(Llamada actualLlamada, DateTime fechafinalizacion) 
        {
            var fechamin = obtenerFechaHoraMinima(actualLlamada.ListaCambioEstado);
            var duracion = fechafinalizacion.Subtract(fechamin);
            actualLlamada.Duracion = (int)duracion.TotalMinutes;
        }

        public DateTime obtenerFechaHoraMinima(List<CambioEstado> lCestado) 
        {
            DateTime cEstadofechaMin = lCestado.Min(x => x.FechaHoraInicio);

            return cEstadofechaMin;
        
        }

        public Dictionary<String, object> tomarDatosLlamada(Llamada actualLlamada, List<CategoriaLlamada> cat)
        {
            Dictionary<string,object> dic = new Dictionary<string,object>();

            var nombreCliente = getNombreClienteLlamada(actualLlamada.Cliente);
            var listaOpcion = actualLlamada.seleccionada;
            var cte = seleccionada.esCategoriaCte(listaOpcion, cat); 

            dic.Add("Nom_cliente", nombreCliente);
            dic.Add("Opcion", listaOpcion);
            dic.Add("Categoria", cte);

           return dic;
        }        

        public static String getNombreClienteLlamada(Cliente cliente)
        {
            return cliente.NombreCompleto1; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_Grupo8.EntityLayer; //ADD
using PPAI_IVR_Grupo8.CapaDePresentacion;//ADD
using System.ServiceModel.Channels;
using System.Windows;
//using System.DateTime;

namespace PPAI_IVR_Grupo8.CapaLogicaDeNegocio
{
    public class GestorRespuestaOperador
    {
        #region LISTAS

        Cliente clienteAct;
        List<CambioEstado> listCambioEstado = new List<CambioEstado>();
        List<Estado>ListaDeEstados = new List<Estado>();
        CambioEstado cambioEstado1;
        Estado estadoIniciada;
        Estado estadoEnCurso;
        Estado estadoFinalizado;

        #region LISTAS VALIDACIONES Y OPCVALID

        OpcionValidacion opcionValidacion1;
        OpcionValidacion opcionValidacion2;
        OpcionValidacion opcionValidacion3;
        List<OpcionValidacion> listOpcionValidaciones1 = new List<OpcionValidacion>();

        OpcionValidacion opcionValidacion4;
        OpcionValidacion opcionValidacion5;
        OpcionValidacion opcionValidacion6;
        List<OpcionValidacion> listOpcionValidaciones2 = new List<OpcionValidacion>();

        OpcionValidacion opcionValidacion7;
        OpcionValidacion opcionValidacion8;
        OpcionValidacion opcionValidacion9;
        List<OpcionValidacion> listOpcionValidaciones3 = new List<OpcionValidacion>();

        OpcionValidacion opcionValidacion10;
        OpcionValidacion opcionValidacion11;
        OpcionValidacion opcionValidacion12;
        List<OpcionValidacion> listOpcionValidaciones4 = new List<OpcionValidacion>();

        OpcionValidacion opcionValidacion13;
        OpcionValidacion opcionValidacion14;
        OpcionValidacion opcionValidacion15;
        List<OpcionValidacion> listOpcionValidaciones5 = new List<OpcionValidacion>();

        OpcionValidacion opcionValidacion16;
        OpcionValidacion opcionValidacion17;
        OpcionValidacion opcionValidacion18;
        List<OpcionValidacion> listOpcionValidaciones6 = new List<OpcionValidacion>();

        Validacion validacion1;
        Validacion validacion2;
        Validacion validacion3;
        Validacion validacion4;
        Validacion validacion5;
        Validacion validacion6;
        #endregion

        #region LISTAS OPCIONES SUBOPCIONES

        List<Validacion> listValidaciones1 = new List<Validacion>();
        SubOpcionLlamada subopcion1;
        SubOpcionLlamada subopcion2;
        SubOpcionLlamada subopcion3;
        SubOpcionLlamada subopcion4;
        List<SubOpcionLlamada> listSubOpcionLlamada1 = new List<SubOpcionLlamada>();
        SubOpcionLlamada subopcion5;
        SubOpcionLlamada subopcion6;
        SubOpcionLlamada subopcion7;
        SubOpcionLlamada subopcion8;
        List<SubOpcionLlamada> listSubOpcionLlamada2 = new List<SubOpcionLlamada>();
        SubOpcionLlamada subopcion9;
        SubOpcionLlamada subopcion10;
        SubOpcionLlamada subopcion11;
        List<SubOpcionLlamada> listSubOpcionLlamada3 = new List<SubOpcionLlamada>();
        OpcionLlamada opcionLlamada1;
        OpcionLlamada opcionLlamada2;
        OpcionLlamada opcionLlamada3;
        List<OpcionLlamada> listOpcionLlamada1 = new List<OpcionLlamada>();
        OpcionLlamada opcionLlamada4;
        OpcionLlamada opcionLlamada5;
        List<OpcionLlamada> listOpcionLlamada2 = new List<OpcionLlamada>();
        OpcionLlamada opcionLlamada6;
        OpcionLlamada opcionLlamada7;
        OpcionLlamada opcionLlamada8;
        List<OpcionLlamada> listOpcionLlamada3 = new List<OpcionLlamada>();
        OpcionLlamada opcionLlamada9;
        OpcionLlamada opcionLlamada10;
        List<OpcionLlamada> listOpcionLlamada4 = new List<OpcionLlamada>();
        CategoriaLlamada categoriaLlamada1;
        CategoriaLlamada categoriaLlamada2;
        CategoriaLlamada categoriaLlamada3;
        CategoriaLlamada categoriaLlamada4;
        CategoriaLlamada categoriaLlamada5;
        List<CategoriaLlamada> listaDeCategoriaLlamada = new List<CategoriaLlamada>();
        Accion accion1;
        Accion accion2;
        Accion accion3;
        List<Accion> accionList = new List<Accion>();
        #endregion

        #endregion

        Llamada llamadaActual; //Esta es la llamada en curso

        public GestorRespuestaOperador ()//PantallaRespuestaOperador pantalla)
        {
            // listaDeEstados
            //listaDeCategorias
            //listaDeAcciones

            //this.Pantalla = pantalla;
            #region Objetos Hardcode


            //Carga de las acciones
            accion1 = new Accion("Comunicar Saldo");
            accion2 = new Accion("Dar de baja la tarjeta");
            accion3 = new Accion("Denunciar un Robo o extravio");

            //Cliente
            clienteAct = new Cliente(38985699, "Javier Zanetti", 3513482979);

            #region ESTADOS
            accionList.Add(accion1);
            accionList.Add(accion2);
            accionList.Add(accion3);

            //Seteo de cada uno de los estados posibles
            estadoIniciada = new Estado("Iniciada");
            estadoEnCurso = new Estado("enCurso");
            estadoFinalizado = new Estado("Finalizada");

            //Cambio de estadio inicial con el que viene la llamada
            cambioEstado1 = new CambioEstado(DateTime.Today.AddMinutes(-2), estadoIniciada);

            listCambioEstado.Add(cambioEstado1);

            //llenamos la lista de todos los estados
            ListaDeEstados.Add(estadoEnCurso);
            ListaDeEstados.Add(estadoFinalizado);
            ListaDeEstados.Add(estadoIniciada);
            #endregion

            #region OPCIONES VALIDACION
            //aca levanta la pregunta o es la que le ofrecemos al cliente 

            //OPCION VALIDACION 1
            //Tiene extencion en la cuenta de la tarjeta 
            opcionValidacion1 = new OpcionValidacion(true, "2");
            opcionValidacion2 = new OpcionValidacion(false, "1");
            opcionValidacion3 = new OpcionValidacion(false, "0");
            //Se carga lista con opcValidacion7
            listOpcionValidaciones1.Add(opcionValidacion1);
            listOpcionValidaciones1.Add(opcionValidacion2);
            listOpcionValidaciones1.Add(opcionValidacion3);
            ///////////////////////////////////////////////////////////////////////////////////////////
            //OPCION VALIDACION 2
            //Corresponde a la validacion que edad tiene actualmente
            opcionValidacion4 = new OpcionValidacion(true, "30");
            opcionValidacion5 = new OpcionValidacion(false, "10");
            opcionValidacion6 = new OpcionValidacion(false, "15");
            //Se carga la lista con las opcvalidaciones1
            listOpcionValidaciones2.Add(opcionValidacion4);
            listOpcionValidaciones2.Add(opcionValidacion5);
            listOpcionValidaciones2.Add(opcionValidacion6);
            ///////////////////////////////////////////////////////////////////////////////////////////
            //OPCION VALIDACION 3
            //Estas opciones responde a la validacion de cuantas cuentas propias tiene en la cuenta 
            opcionValidacion7 = new OpcionValidacion(true, "2");
            opcionValidacion8 = new OpcionValidacion(false, "5");
            opcionValidacion9 = new OpcionValidacion(false, "1");
            //Se carga la lista con las opcvalidaciones2
            listOpcionValidaciones2.Add(opcionValidacion7);
            listOpcionValidaciones2.Add(opcionValidacion8);
            listOpcionValidaciones2.Add(opcionValidacion9);
            ///////////////////////////////////////////////////////////////////////////////////////////
            //OPCION VALIDACION 4
            //Fecha de la ultima transaccion hecha
            opcionValidacion10 = new OpcionValidacion(true, "03/06/2023");
            opcionValidacion11 = new OpcionValidacion(false, "31/05/2023");
            opcionValidacion12 = new OpcionValidacion(false, "31/04/2023");
            //Se carga la lista con opcvalidaciones3
            listOpcionValidaciones3.Add(opcionValidacion10);
            listOpcionValidaciones3.Add(opcionValidacion11);
            listOpcionValidaciones3.Add(opcionValidacion12);
            ///////////////////////////////////////////////////////////////////////////////////////////
            //OPCION VALIDACION 5
            //Año en que pidio la extencion de la tarjeta
            opcionValidacion13 = new OpcionValidacion(true, "2023");
            opcionValidacion14 = new OpcionValidacion(false, "2022");
            opcionValidacion15 = new OpcionValidacion(false, "2020");
            //Se carga lista con opcValidacion6
            listOpcionValidaciones5.Add(opcionValidacion13);
            listOpcionValidaciones5.Add(opcionValidacion14);
            listOpcionValidaciones5.Add(opcionValidacion15);
            ///////////////////////////////////////////////////////////////////////////////////////////
            //OPCION VALIDACION 6
            //Mes en que pidio la tarjeta 
            opcionValidacion16 = new OpcionValidacion(true, "Junio");
            opcionValidacion17 = new OpcionValidacion(false, "Septiembre");
            opcionValidacion18 = new OpcionValidacion(false, "Febrero");
            //Se carga lista con opcValidacion5
            listOpcionValidaciones6.Add(opcionValidacion16);
            listOpcionValidaciones6.Add(opcionValidacion17);
            listOpcionValidaciones6.Add(opcionValidacion18);

            #endregion

            #region VALIDACIONES

            //VALIDACIONES
            //con un listado 

            validacion1 = new Validacion(1, "¿Cuantas extenciones tiene en la cuenta de la tarjeta?", listOpcionValidaciones1);
            validacion2 = new Validacion(2, "¿Que edad tiene actualmente?", listOpcionValidaciones2);
            validacion3 = new Validacion(3, "¿Cuantas cuentas propias tiene en la cuenta?", listOpcionValidaciones3);
            validacion4 = new Validacion(4, "¿Fecha de la ultima transaccion hecha?", listOpcionValidaciones4);
            validacion5 = new Validacion(5, "¿En que año abrio la cuenta?", listOpcionValidaciones5);
            validacion6 = new Validacion(6, "¿Mes en que pidio la tarjeta?", listOpcionValidaciones6);

            //Se cargan las lista de validacion
            listValidaciones1.Add(validacion1);
            listValidaciones1.Add(validacion2);
            listValidaciones1.Add(validacion3);
            listValidaciones1.Add(validacion4);
            listValidaciones1.Add(validacion5);
            listValidaciones1.Add(validacion6);

            #endregion

            #region OPCIONES Y SUBOPCIONES LLAMADA

            //SUBOPCIONES

            //para la primera opcion de la primera categoria 
            subopcion1 = new SubOpcionLlamada(4, "Si cuenta con los datos de la tarjeta marque 1", listValidaciones1);
            subopcion2 = new SubOpcionLlamada(2, "Si no cuenta con los datos de la tarjeta marque 2", null);
            subopcion3 = new SubOpcionLlamada(3, "Si desea comunicarse con un responsable de atencion al cliente marque 3", null);
            subopcion4 = new SubOpcionLlamada(4, "Si desea finalizar la llamada marque 4", null);

            //Se carga la lista de subopc1
            listSubOpcionLlamada1.Add(subopcion1);
            listSubOpcionLlamada1.Add(subopcion2);
            listSubOpcionLlamada1.Add(subopcion3);
            listSubOpcionLlamada1.Add(subopcion4);



            //para la primera opcion de la carta categoria 

            subopcion5 = new SubOpcionLlamada(1, "Si desea aumentar el limite de la tarjeta de credito VISA marque 1", null);
            subopcion6 = new SubOpcionLlamada(2, "Si desea aumentar el limite de la tarjeta de credito MASTERCARD marque 2", null);
            subopcion7 = new SubOpcionLlamada(3, "Si desea aumentar el limite de la extencion de la tarjeta de credito VISA marque 3", null);
            subopcion8 = new SubOpcionLlamada(4, "Si desea finalizar la llamada marque 4", null);
            //Se carga la lista con subopc2
            listSubOpcionLlamada2.Add(subopcion5);
            listSubOpcionLlamada2.Add(subopcion6);
            listSubOpcionLlamada2.Add(subopcion7);
            listSubOpcionLlamada2.Add(subopcion8);

            //para la primera opcion de la tercera categoria 
            subopcion9 = new SubOpcionLlamada(1, "Si conoce el numero de compra marque 1", null);
            subopcion10 = new SubOpcionLlamada(2, "Si no conoce le numero de compra marque 2 ", null);
            subopcion11 = new SubOpcionLlamada(3, "Si desea finalizar la llamada marque 4 ", null);
            //Se carga la lista con las subopc3
            listSubOpcionLlamada3.Add(subopcion9);
            listSubOpcionLlamada3.Add(subopcion10);
            listSubOpcionLlamada3.Add(subopcion11);


            //OPCIONES
            //para la primera categoria 
            opcionLlamada1 = new OpcionLlamada(2, "Si desea informar un robo y solicitar una nueva tarjeta marque 1", listSubOpcionLlamada1, listValidaciones1);
            opcionLlamada2 = new OpcionLlamada(2, "Si desea informar un robo y anular tarjeta marque 2", listSubOpcionLlamada1, listValidaciones1);
            opcionLlamada3 = new OpcionLlamada(3, "Si desea finalizar llamada marque 3", null, null);

            listOpcionLlamada1.Add(opcionLlamada1);
            listOpcionLlamada1.Add(opcionLlamada2);
            listOpcionLlamada1.Add(opcionLlamada3);
            //para la segunda categoria 
            opcionLlamada4 = new OpcionLlamada(1, "Si desea desbloquear la tarjeta marque 1 ", null, listValidaciones1);
            opcionLlamada5 = new OpcionLlamada(2, "Si quiere dar de baja la tarjeta y generar una nueva marque 2 ", null, listValidaciones1);

            listOpcionLlamada2.Add(opcionLlamada4);
            listOpcionLlamada2.Add(opcionLlamada5);
            //para la tercera categoria
            opcionLlamada6 = new OpcionLlamada(1, "Si quiere desconocer un pago en la tarjeta marque 1", listSubOpcionLlamada1, listValidaciones1);
            opcionLlamada7 = new OpcionLlamada(2, "Si quiere conocer su estado de deuda marque 2", null, listValidaciones1);
            opcionLlamada8 = new OpcionLlamada(3, "Si quiere saber la fecha de su proximo cierre de la tarjeta marque 3 ", listSubOpcionLlamada1, listValidaciones1);

            listOpcionLlamada3.Add(opcionLlamada6);
            listOpcionLlamada3.Add(opcionLlamada7);
            listOpcionLlamada3.Add(opcionLlamada8);
            //para la cuarta categoria 
            opcionLlamada9 = new OpcionLlamada(1, "Si desea aumentar el limite de la tarjeta marque 1", listSubOpcionLlamada2, listValidaciones1);
            opcionLlamada10 = new OpcionLlamada(2, "Si desea disminuir el limite de la tarjeta marque 2", null, listValidaciones1);

            listOpcionLlamada4.Add(opcionLlamada9);
            listOpcionLlamada4.Add(opcionLlamada10);

            //categoria de llamada 

            categoriaLlamada1 = new CategoriaLlamada(1, "Si quiere informar un robo marque 1", listOpcionLlamada1);
            categoriaLlamada2 = new CategoriaLlamada(2, "Si su tarjeta esta bloqueada marque 2", listOpcionLlamada2);
            categoriaLlamada3 = new CategoriaLlamada(3, "Si quiere realiizar consultas sobre operaciones de la tarjeta marque 3", listOpcionLlamada3);
            categoriaLlamada4 = new CategoriaLlamada(4, "Si desea realizar modificaciones en los limites de la tarjeta marque 4", listOpcionLlamada4);
            categoriaLlamada5 = new CategoriaLlamada(5, "Si desea finalizar la llamada marque 5", null);

            listaDeCategoriaLlamada.Add(categoriaLlamada1);
            listaDeCategoriaLlamada.Add(categoriaLlamada2);
            listaDeCategoriaLlamada.Add(categoriaLlamada3);
            listaDeCategoriaLlamada.Add(categoriaLlamada4);
            listaDeCategoriaLlamada.Add(categoriaLlamada5);
            #endregion 

            llamadaActual = new Llamada(
                null,
                null,
                0,
                "se realizo los procedimientos correctamente ",
                clienteAct,
                listCambioEstado,
                opcionLlamada1,
                subopcion1,
                null);

            #endregion

        }

        public void validarOpcionSeleccionada()
        {
            var diccionarioDatosLlamada = new Dictionary<string, object>();
            Estado estadoEnCurso = obtenerEstadoEnCurso(ListaDeEstados); //Cambiar nombre en el diadrama de sec
            marcarllamadaEnCurso(estadoEnCurso);

            diccionarioDatosLlamada = buscarDatosLlamada();
            PantallaRespuestaOperador.GetInstance().mostrarDatosLlamadaValidacion(diccionarioDatosLlamada);//Pantalla.mostrarDatosLlamadaValidacion(dicDatosLlamada);//Pantalla.mostrarDatosLlamadaValidacion(dicDatosLlamada);
        }

        private Estado obtenerEstadoEnCurso(List<Estado> listaDeEstados)
        {
            foreach(Estado estado in listaDeEstados) {
                if (estado.esEnCurso()) 
                    return estado;
            }
            return null;
        }

        private void marcarllamadaEnCurso(Estado estadoEnCurso)
        {
            llamadaActual.setLlamadaEnCurso(llamadaActual, estadoEnCurso, this.obtenerFechaHoraActual());
        }

        private DateTime obtenerFechaHoraActual()
        {
            return DateTime.Today;
        }

        private Dictionary<string,object> buscarDatosLlamada()
        {
            Dictionary<string,object> diccionarioDatosLlamada = new Dictionary<string,object>();

            diccionarioDatosLlamada = llamadaActual.tomarDatosLlamada(llamadaActual, listaDeCategoriaLlamada);
            //el metodo para traer el nombre de la categoria ver si realmente es necesario porque ya aca le puedo pasar el nombre al front.
            foreach (KeyValuePair<string, object> subopcSel in llamadaActual.SeleccionadaSubopc.getDatosSubOpc(llamadaActual.SeleccionadaSubopc))
            {
                diccionarioDatosLlamada.Add(subopcSel.Key, subopcSel.Value); // hago la union de los dos diccionarios, los dos del mismo tipo clave,valor
            }

            return diccionarioDatosLlamada;
        }

        public  bool tomarRstaValidacion(Dictionary<Validacion, string> respuesta)
        {
            PantallaRespuestaOperador.GetInstance().mostrarAcciones(accionList);
            return validarRespuesta(respuesta);
        }

        private bool validarRespuesta(Dictionary<Validacion, string> dicc)
        {
            return llamadaActual.SeleccionadaSubopc.ObtenerRstasValidacion(dicc);
        }

        public void tomarConfirmacion(Accion accion)
        {
            llamarCURegistrarAccionRequerida(accion);
        }

        public void llamarCURegistrarAccionRequerida(Accion accion)
        {
            llamadaActual.AccionRequerida = accion;// se instancia al caso de uso 28 //COMPLETAR
        }


        public void tomarDescripcionOperador(string descripcion)
        {
            Estado finalizado = buscarEstadoFinalizado(ListaDeEstados);
            registrarFinalizacionLlamada(finalizado, descripcion);

        }

        private Estado buscarEstadoFinalizado(List<Estado> lestado)
        {
            Estado finalizado = new Estado();
            finalizado = finalizado.esFinalizada(lestado);
            return finalizado;
        }

        private void registrarFinalizacionLlamada(Estado finalizado, String descripcionOperador)
        {
            DateTime fechaActual = obtenerFechaHoraActual();
            llamadaActual.finalizar(llamadaActual, finalizado);
            llamadaActual.calcularDuracion(llamadaActual, fechaActual);
            llamadaActual.DescripcionOperador = descripcionOperador;
    
        }

    }
}
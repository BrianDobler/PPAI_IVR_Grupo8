using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_Grupo8.EntityLayer; //ADD
using PPAI_IVR_Grupo8.CapaDePresentacion;//ADD
//using System.DateTime;

namespace PPAI_IVR_Grupo8.CapaLogicaDeNegocio
{
    public class GestorRespuestaOperador
    {
        Cliente clienteAct;
        List<CambioEstado> listCambioEstado = new List<CambioEstado>();
        List<Estado>ListEstados = new List<Estado>();
        CambioEstado cambioEstado1;
        Estado estadoIniciada;
        Estado estadoEnCurso;
        Estado estadoFinalizado;
        OpcionValidacion opcionValidacion3;
        OpcionValidacion opcionValidacion4;
        OpcionValidacion opcionValidacion5;
        List<OpcionValidacion> listOpcionValidaciones1 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion6;
        OpcionValidacion opcionValidacion7;
        OpcionValidacion opcionValidacion8;
        List<OpcionValidacion> listOpcionValidaciones2 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion9;
        OpcionValidacion opcionValidacion10;
        OpcionValidacion opcionValidacion11;
        List<OpcionValidacion> listOpcionValidaciones3 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion15;
        OpcionValidacion opcionValidacion16;
        OpcionValidacion opcionValidacion17;
        List<OpcionValidacion> listOpcionValidaciones4 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion18;
        OpcionValidacion opcionValidacion19;
        OpcionValidacion opcionValidacion20;
        List<OpcionValidacion> listOpcionValidaciones5 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion21;
        OpcionValidacion opcionValidacion22;
        OpcionValidacion opcionValidacion23;
        List<OpcionValidacion> listOpcionValidaciones6 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion1;
        OpcionValidacion opcionValidacion2;
        List<OpcionValidacion> listOpcionValidaciones7 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion12;
        List<OpcionValidacion> listOpcionValidaciones8 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion13;
        List<OpcionValidacion> listOpcionValidaciones9 = new List<OpcionValidacion>();
        OpcionValidacion opcionValidacion14;
        List<OpcionValidacion> listOpcionValidaciones10 = new List<OpcionValidacion>();
        Validacion validacion2;
        Validacion validacion3;
        Validacion validacion4;
        Validacion validacion8;
        Validacion validacion9;
        Validacion validacion10;
        Validacion validacion1;
        Validacion validacion5;
        Validacion validacion6;
        Validacion validacion7;
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
        List<CategoriaLlamada> listCategoriaLlamada1 = new List<CategoriaLlamada>();

        
        Llamada llamadaAct; //Esta es la llamada en curso

        public GestorRespuestaOperador()
        {
            //Seteo de cada uno de los estados posibles
            estadoIniciada = new Estado("Iniciada");
            estadoEnCurso = new Estado("enCurso");
            estadoFinalizado = new Estado("Finalizada");

            //Cambio de estadio inicial con el que viene la llamada
            cambioEstado1 = new CambioEstado(DateTime.Today.AddMinutes(-2), estadoIniciada);

            listCambioEstado.Add(cambioEstado1);

            //llenamos la lista de todos los estados
            ListEstados.Add(estadoEnCurso);
            ListEstados.Add(estadoFinalizado);
            ListEstados.Add(estadoIniciada);


            clienteAct = new Cliente(38985699, "matias comba", 3513482979);
         
            //aca levanta la pregunta o es la que le ofrecemos al cliente 

            //corresponde a la validacion que edad tiene actualmente
            opcionValidacion3 = new OpcionValidacion(false, "10");
            opcionValidacion4 = new OpcionValidacion(false, "15");
            opcionValidacion5 = new OpcionValidacion(true, "25");
            //Se carga la lista con las opcvalidaciones1
            listOpcionValidaciones1.Add(opcionValidacion3);
            listOpcionValidaciones1.Add(opcionValidacion4);
            listOpcionValidaciones1.Add(opcionValidacion5);


            //estas opciones responde a la validacion de cuantas cuentas propias tiene en la cuenta 
            opcionValidacion6 = new OpcionValidacion(false, "5");
            opcionValidacion7 = new OpcionValidacion(true, "2");
            opcionValidacion8 = new OpcionValidacion(false, "1");
            //Se carga la lista con las opcvalidaciones2
            listOpcionValidaciones2.Add(opcionValidacion6);
            listOpcionValidaciones2.Add(opcionValidacion7);
            listOpcionValidaciones2.Add(opcionValidacion8);
            // fecha de la ultima transaccion hecha
            opcionValidacion9 = new OpcionValidacion(false, "31/05/2023");
            opcionValidacion10 = new OpcionValidacion(false, "31/04/2023");
            opcionValidacion11 = new OpcionValidacion(true, "24/05/2023");
            //Se carga la lista con opcvalidaciones3
            listOpcionValidaciones3.Add(opcionValidacion9);
            listOpcionValidaciones3.Add(opcionValidacion10);
            listOpcionValidaciones3.Add(opcionValidacion11);

            //codigo postal de su ultimo domicilio registrado
            opcionValidacion15 = new OpcionValidacion(true, "5000");
            opcionValidacion16 = new OpcionValidacion(false, "5010");
            opcionValidacion17 = new OpcionValidacion(false, "5010");
            //Se carga lista con opcvalidaciones4
            listOpcionValidaciones4.Add(opcionValidacion15);
            listOpcionValidaciones4.Add(opcionValidacion16);
            listOpcionValidaciones4.Add(opcionValidacion17);

            //mes en que pidio la tarjeta 
            opcionValidacion18 = new OpcionValidacion(true, "junio");
            opcionValidacion19 = new OpcionValidacion(false, "septiembre");
            opcionValidacion20 = new OpcionValidacion(false, "febrero");

            //Se carga lista con opcValidacion5
            listOpcionValidaciones5.Add(opcionValidacion18);
            listOpcionValidaciones5.Add(opcionValidacion19);
            listOpcionValidaciones5.Add(opcionValidacion20);
            //año en que pido la extencion de la tarjeta
            opcionValidacion21 = new OpcionValidacion(true, "2023");
            opcionValidacion22 = new OpcionValidacion(true, "2022");
            opcionValidacion23 = new OpcionValidacion(true, "2020");
            //Se carga lista con opcValidacion6
            listOpcionValidaciones6.Add(opcionValidacion21);
            listOpcionValidaciones6.Add(opcionValidacion22);
            listOpcionValidaciones6.Add(opcionValidacion23);

            //tiene extencion en la cuenta de la tarjeta 
            opcionValidacion1 = new OpcionValidacion(true, "tiene actualmente 2 extenciones de la tarjeta");
            opcionValidacion2 = new OpcionValidacion(false, "tiene actualmente 1 extenciones de la tarjeta");

            //Se carga lista con opcValidacion7
            listOpcionValidaciones7.Add(opcionValidacion1);
            listOpcionValidaciones7.Add(opcionValidacion2);

            //hizo alguna transaccion esta semana 
            opcionValidacion12 = new OpcionValidacion(true, "NO");
            listOpcionValidaciones8.Add(opcionValidacion12);
            //la cuenta la abrio este año
            opcionValidacion13 = new OpcionValidacion(true, "NO");
            listOpcionValidaciones9.Add(opcionValidacion13);
            //la tarjeta es de caracter compartida 
            opcionValidacion14 = new OpcionValidacion(true, "SI");
            listOpcionValidaciones10.Add(opcionValidacion14);

            //VALIDACIONES
            //con un listado 

            validacion2 = new Validacion(2, "que edad tiene actualmente", listOpcionValidaciones1);
            validacion3 = new Validacion(3, "cuantas cuentas propias tiene en la cuenta ", listOpcionValidaciones2);
            validacion4 = new Validacion(4, "fecha de la ultima transaccion hecha", listOpcionValidaciones3);
            validacion8 = new Validacion(8, "codigo postal de su ultimo domicilio registrado", listOpcionValidaciones4);
            validacion9 = new Validacion(9, "mes en que pidio la tarjeta", listOpcionValidaciones5);
            validacion10 = new Validacion(10, "tiene extencion en la cuenta de la tarjeta", listOpcionValidaciones6);
            validacion1 = new Validacion(1, "tiene extencion en la cuenta de la tarjeta", listOpcionValidaciones7);
            validacion5 = new Validacion(5, "hizo alguna transaccion esta semana ", listOpcionValidaciones8);
            validacion6 = new Validacion(6, "la cuenta la abrio este año", listOpcionValidaciones9);
            validacion7 = new Validacion(7, "la tarjeta es de caracter compartida", listOpcionValidaciones10);

            //Se cargan las lista de validacion
            listValidaciones1.Add(validacion1);
            listValidaciones1.Add(validacion2);
            listValidaciones1.Add(validacion3);
            listValidaciones1.Add(validacion4);
            listValidaciones1.Add(validacion5);
            listValidaciones1.Add(validacion6);
            listValidaciones1.Add(validacion7);
            listValidaciones1.Add(validacion8);
            listValidaciones1.Add(validacion9);
            listValidaciones1.Add(validacion10);

            //SUBOPCIONES

            //para la primera opcion de la primera categoria 
            subopcion1 = new SubOpcionLlamada(1, "Si cuenta con los datos de la tarjeta marque 1", listValidaciones1);
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
            subopcion9 = new SubOpcionLlamada(1, "si conoce el numero de compra marque 1", null);
            subopcion10 = new SubOpcionLlamada(2, "si no conoce le numero de compra marque 2 ", null);
            subopcion11 = new SubOpcionLlamada(3, "Si desea finalizar la llamada marque 4 ", null);
            //Se carga la lista con las subopc3
            listSubOpcionLlamada3.Add(subopcion9);
            listSubOpcionLlamada3.Add(subopcion10);
            listSubOpcionLlamada3.Add(subopcion11);


            //OPCIONES
            //para la primera categoria 
            opcionLlamada1 = new OpcionLlamada(1, "Si desea informar un robo y solicitar una nueva tarjeta marque 1", listSubOpcionLlamada1, listValidaciones1);
            opcionLlamada2 = new OpcionLlamada(2, "Si desea informar un robo y anular tarjeta marque 2", listSubOpcionLlamada1, listValidaciones1);
            opcionLlamada3 = new OpcionLlamada(3, "Si desea finalizar llamada marque 3", null, null);

            listOpcionLlamada1.Add(opcionLlamada1);
            listOpcionLlamada1.Add(opcionLlamada2);
            listOpcionLlamada1.Add(opcionLlamada3);
            //para la segunda categoria 
            opcionLlamada4 = new OpcionLlamada(1, "si desea desbloquear la tarjeta marque 1 ", null, listValidaciones1);
            opcionLlamada5 = new OpcionLlamada(2, "si quiere dar de baja la tarjeta y generar una nueva marque 2 ", null, listValidaciones1);

            listOpcionLlamada2.Add(opcionLlamada4);
            listOpcionLlamada2.Add(opcionLlamada5);
            //para la tercera categoria
            opcionLlamada6 = new OpcionLlamada(1, "si quiere desconocer un pago en la tarjeta marque 1", listSubOpcionLlamada1, listValidaciones1);
            opcionLlamada7 = new OpcionLlamada(2, "si quiere conocer su estado de deuda marque 2", null, listValidaciones1);
            opcionLlamada8 = new OpcionLlamada(3, "si quiere saber la fecha de su proximo cierre de la tarjeta marque 3 ", listSubOpcionLlamada1, listValidaciones1);

            listOpcionLlamada3.Add(opcionLlamada6);
            listOpcionLlamada3.Add(opcionLlamada7);
            listOpcionLlamada3.Add(opcionLlamada8);
            //para la cuarta categoria 
            opcionLlamada9 = new OpcionLlamada(1, "si desea aumentar el limite de la tarjeta marque 1", listSubOpcionLlamada2, listValidaciones1);
            opcionLlamada10 = new OpcionLlamada(2, "si desea disminuir el limite de la tarjeta marque 2", null, listValidaciones1);

            listOpcionLlamada4.Add(opcionLlamada9);
            listOpcionLlamada4.Add(opcionLlamada10);

            //categoria de llamada 

            categoriaLlamada1 = new CategoriaLlamada(1, "Si quiere informar un robo marque 1", listOpcionLlamada1);
            categoriaLlamada2 = new CategoriaLlamada(2, "si su tarjeta esta bloqueada marque 2", listOpcionLlamada2);
            categoriaLlamada3 = new CategoriaLlamada(3, "si quiere realiizar consultas sobre operaciones de la tarjeta marque 3", listOpcionLlamada3);
            categoriaLlamada4 = new CategoriaLlamada(4, "si desea realizar modificaciones en los limites de la tarjeta marque 4", listOpcionLlamada4);
            categoriaLlamada5 = new CategoriaLlamada(5, "si desea finalizar la llamada marque 5", null);

            listCategoriaLlamada1.Add(categoriaLlamada1);
            listCategoriaLlamada1.Add(categoriaLlamada2);
            listCategoriaLlamada1.Add(categoriaLlamada3);
            listCategoriaLlamada1.Add(categoriaLlamada4);
            listCategoriaLlamada1.Add(categoriaLlamada5);

            llamadaAct = new Llamada(
                null,
                null,
                0,
                "se realizo los procedimientos correctamente ",
                clienteAct,
                listCambioEstado,
                opcionLlamada1,
                subopcion1
                );



            //Llamada llamada2 = new Llamada(
            //    null,
            //    null,
            //    0,
            //    "se realizo los procedimientos correctamente ",
            //    cliente,
            //    null,
            //    opcionLlamada9,
            //    subopcion8
            //    );

        }
        public Dictionary<string,object> validarOpcSeleccionada()
        {
            var dicDatosLlamada = new Dictionary<string, object>();

            Estado eEnCurso = new Estado();
            eEnCurso = obtenerLlamadaActual(ListEstados);
            marcarllamadaEnCurso(eEnCurso);

            dicDatosLlamada = buscarDatosLlamada();

            return dicDatosLlamada;
        }

        private Estado obtenerLlamadaActual(List<Estado> lestado)
        {
            Estado state = new Estado();
            foreach (Estado estado in lestado)
            {
                if (Estado.esEnCurso(estado))
                {
                    state = estado;
                    break;
                }
            }
            return state;// deberiamos llamara al metodo esEnCurso
            // deberiamos llamara al metodo esDeTucliente
        }

        private void marcarllamadaEnCurso(Estado estEnCurso)
        {
            Llamada.setLlamadaEnCurso(llamadaAct, estEnCurso);
        }

        private DateTime obtenerFechaHoraActual()
        {
            return DateTime.Today; //revisar si esta bien aplicado el patron altacohesion porque esto lo esta obteniendo en la clase
        }

        private Dictionary<string,object> buscarDatosLlamada()
        {
            Dictionary<string,object> dicDatosLlamada = new Dictionary<string,object>();

            dicDatosLlamada = Llamada.tomarDatosLlamada(llamadaAct, listCategoriaLlamada1);
            //el metodo para traer el nombre de la categoria ver si realmente es necesario porque ya aca le puedo pasar el nombre al front.
            foreach (KeyValuePair<string, object> subopcSel in SubOpcionLlamada.getDatosSubOpc(llamadaAct.SeleccionadaSubopc))
            {
                dicDatosLlamada.Add(subopcSel.Key, subopcSel.Value); // hago la union de los dos diccionarios, los dos del mismo tipo clave,valor
            }

            return dicDatosLlamada;
        }

        public void tomarRstaValidacion()
        {
            Dictionary<Validacion, OpcionValidacion> dic = new Dictionary<Validacion, OpcionValidacion>();

        }

        private bool validarRespuesta(Dictionary<Validacion, OpcionValidacion> dicc)
        {
            return SubOpcionLlamada.ObtenerRstasValidacion(dicc);
        }

        public void tomarDescripcionAccion()
        {

        }

        public void tomarConfirmacion()
        {

        }

        public void llamarCURegistrarAccionRequerida()
        {
            // se instancia al caso de uso 28
        }
    }

}
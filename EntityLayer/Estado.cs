using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class Estado
    {
        private string nombre;

        public string Nombre { get => nombre; set => nombre = value; }

        public Estado()
        {
        }

        public Estado(string nombre)
        {
            Nombre = nombre;
        }

        public Boolean esFinalizada()
        {
            return (this.nombre.Equals("Finalizada")) ? true : false;
            
            /*
            Estado finalizado = new Estado();
            foreach (Estado estado in lestado)
            {
                if (estado.Equals("Finalizada"))
                {
                    finalizado = estado;
                    break;
                }
            }
            return finalizado;*/
        }

        public Boolean esIniciada()
        {
            return false;
        }

        /*
        public Estado esEnCurso (List<Estado> lestado)
        {
            Estado state = new Estado();
            foreach (Estado estado in lestado)
            {
                if (estado.Equals("EnCurso"))
                {
                    state = estado;
                    break;
                }
            }
            return state;
        }*/

        public Boolean esEnCurso() {
            return (this.nombre.Equals("enCurso")) ? true : false;
        }

    }
}

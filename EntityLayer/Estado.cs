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

        public Boolean esFinalizada(Estado est)
        {
            if (est.nombre == "Finalizada")
            {
                return true;

            }
            return false;
        }

        public static Boolean esIniciada()
        {
            return false;
        }

        public Boolean esEnCurso (Estado est)
        {
            if (est.nombre == "enCurso")
            {
                return true;

            }
            return false;
        }

    }
}

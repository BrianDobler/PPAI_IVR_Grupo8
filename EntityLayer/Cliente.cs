using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_Grupo8.EntityLayer
{
    public class Cliente
    {
        private int Dni;
        private string NombreCompleto;
        private int nroCelular;


        public int Dni1 { get => Dni; set => Dni = value; }
        public string NombreCompleto1 { get => NombreCompleto; set => NombreCompleto = value; }
        public int NroCelular { get => nroCelular; set => nroCelular = value; }


        public Cliente(int dni, string nombreCompleto, int nroCelular)
        {
            Dni = dni;
            NombreCompleto = nombreCompleto;
            this.nroCelular = nroCelular;
        }

        public Cliente()
        {
        }
    }
}

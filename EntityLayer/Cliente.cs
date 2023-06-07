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
        private UInt32 nroCelular;


        public int Dni1 { get => Dni; set => Dni = value; }
        public string NombreCompleto1 { get => NombreCompleto; set => NombreCompleto = value; }
        public UInt32 NroCelular { get => nroCelular; set => nroCelular = value; }


        public Cliente(int dni, string nombreCompleto, UInt32 nroCelular)
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

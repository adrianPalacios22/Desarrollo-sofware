using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreaker.Biblioteca
{
    public class Cliente
    {
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public tipoEmpresa tipo { get; set; }
        public actividadEmpresa actividad { get; set; }

        public Cliente()
        {
                
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreaker.Biblioteca
{
    public class Cliente
    {
        private string _rut;
        public string Rut
        {
            get { return _rut; }
            set
            {
                if (validarRut(value))
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("El rut ingresado no es valido");
                }
            }
        }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public tipoEmpresa tipo { get; set; }
        public actividadEmpresa actividad { get; set; }

        public Cliente()
        {
                
        }
        private bool validarRut(string rut)
        {
            bool validacion = false;

            rut = rut.ToUpper();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                validacion = true;
            }

            return validacion;
        }

    }
}

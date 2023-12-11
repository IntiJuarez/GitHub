using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reparar
{
    public class CObrero : CEmpleado
    {
        private string oficio;
        private string categoria;

        public CObrero(uint leg, string ape, string nom, string ofi, string cat) : base(leg, ape, nom)
        {
            this.oficio = ofi;
            this.categoria = cat;
        }

        public string GetOficio() { return this.oficio; }
        public string GetCategoria() { return this.categoria; }

        public override string GetInfo()
        {
            return base.GetInfo() + " Oficio: " + this.oficio + " Categoria: " + this.categoria;
        }

        public virtual float calcularHaberMensual(float montoSindicato)
        {
            if (this.categoria == "Oficial")
            {
                return montoSindicato = CEmpleado.GetMontoSindicato();
            }
            else if (this.categoria == "Medio-Oficiales")
            {
                return montoSindicato = CEmpleado.GetMontoSindicato() * 0.65F;
            }
            else if (this.categoria == "Aprendiz")
            {
                return montoSindicato = CEmpleado.GetMontoSindicato() * 0.25F;
            }
            return 0;
        }
    }
}

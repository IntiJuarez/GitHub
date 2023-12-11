using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reparar
{
    public class CProfesional : CEmpleado
    {
        private ulong matricula;
        private string titulo;
        private string ConsejoProfesional;
        private static float canonUniversal;
        private uint porcentajeNegociado;

        public CProfesional(uint leg, string ape, string nom, ulong matri, string titu, string consejo, uint porce) : base(leg, ape, nom)
        {
            this.matricula = matri;
            this.titulo = titu;
            this.ConsejoProfesional = consejo;
            this.porcentajeNegociado = porce;
        }

        public ulong GetMatricula() { return this.matricula; }
        public string GetTitulo() { return this.titulo; }
        public string GetConsejoProf() { return this.ConsejoProfesional; }

        public void SetPorcentaje(uint porce)
        {
            this.porcentajeNegociado = porce;
        }
        public float GetPorcentaje() { return this.porcentajeNegociado; }

        public override string GetInfo()
        {
            return base.GetInfo() + " Matricula: " + this.matricula.ToString() + " Título: " + this.titulo + " Consejo Profesional: " + this.ConsejoProfesional;
        }

        public static void SetCanonUniversal(float canon)
        {
            canonUniversal = canon;
        }

        public static float GetCanonUniversal()
        {
            return canonUniversal;
        }

    }

}

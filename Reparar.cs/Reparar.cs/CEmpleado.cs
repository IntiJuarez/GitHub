using System;


namespace Reparar
{
    public class CEmpleado :IComparable
    {
        private uint legajo;
        private string apellido;
        private string nombre;
        private static float sindicatoMonto;

        public CEmpleado(uint leg, string ape, string nom)
        {
            this.legajo = leg;
            this.apellido = ape;
            this.nombre = nom;
        }

        public virtual uint GetLegajo() { return this.legajo; }
        public virtual string GetApellido() { return this.apellido; }
        public virtual string GetNombre() { return this.nombre; }
        public static void SetMontoSindicato(float monto) { sindicatoMonto = monto; }
        public static float GetMontoSindicato() { return sindicatoMonto; }

        public virtual string GetInfo()
        {
            return " Legajo: " + this.legajo.ToString() + " Apellido: " + this.apellido + " Nombre: " + this.nombre;
        }

        public int CompareTo(object Empleado)
        {
            return this.apellido.CompareTo(((CEmpleado)Empleado).GetApellido());
        }
    }
}

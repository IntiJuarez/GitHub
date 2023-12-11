using System;
using System.Collections;


namespace Reparar
{
     public class Empresa
    {
        private ArrayList lista_obreros_en_obra = new ArrayList(0);
        private ArrayList lista_profesionales = new ArrayList(0);
        private ArrayList lista_obras = new ArrayList(0);
        //private static float montoSindicato;

        public Empresa()
        {
        }

        //public static void asignarMonto(float monto)
        //{
        //    Empresa.montoSindicato = monto;
        //}

        //public static float GetMontoSindicato() { return Empresa.montoSindicato; }


        /*Buscar Obra*/
        public CObra buscar(string cod)
        {
            foreach(CObra obra in this.lista_obras)
            {
                if(obra.GetCodigo() == cod)
                {
                    return obra;
                }
            }
            return null;
        }

        /*Crear Obra*/
        public bool crear(string codigo, string direccion, uint leg)
        {
            CObra obraAux = this.buscar(codigo);
            if(obraAux == null)
            {
                if (profesionalEnObra(leg) == false)
                {
                    CProfesional profAux = this.buscarProfesional(leg);
                    if (profAux != null)
                    {
                        this.lista_obras.Add(new CObra(codigo, direccion, profAux));
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        /*Buscar Obrero*/
        public CObrero buscar(uint legajo)
        {
            foreach(CObrero obrero in this.lista_obreros_en_obra)
            {
                if(obrero.GetLegajo() == legajo)
                {
                    return obrero;
                }
            }
            return null;
        }

        public bool legajoUnicoRegistrado(uint leg)
        {
            foreach(CProfesional profesional in this.lista_profesionales)
            {
                if(profesional.GetLegajo() == leg)
                {
                    return true;
                }
            }
            foreach(CObrero obrero in this.lista_obreros_en_obra)
            {
                if(obrero.GetLegajo() == leg)
                {
                    return true;
                }
            }
            return false;
        }

        public bool obraYaRegistrada(string codigoObra)
        {
            foreach(CObra obra in this.lista_obras)
            {
                if(obra.GetCodigo()==codigoObra)
                {
                    return true;
                }
            }
            return false;
        }

        /*Crear obrero*/
        public bool crear(uint leg, string ape, string nom, string ofi, string cat)
        {
            CObrero obreroAux = this.buscar(leg);
            if(obreroAux == null)
            {
                this.lista_obreros_en_obra.Add(new CObrero(leg, ape, nom, ofi, cat));
                return true;
            }
            return false;
        }

        /*El obrero esta en la obra?*/
        public bool obreroEnObra(uint leg)
        {
            foreach(CObra obra in this.lista_obras)
            {
                if(obra.obreroAsignado(leg) == true)
                {
                    return true;
                }
            }
            return false;
        }

        /*Asignar obrero en obra*/
        public bool asignar(string cod, uint leg)
        {
            CObra obraAux = this.buscar(cod);
            if(obraAux!=null)
            {
                CObrero obrero = this.buscar(leg);
                if(obrero != null)
                {

                    if(obreroEnObra(leg)== false)
                    {
                        obraAux.asignarObero(obrero);
                        return true;
                    }
                }
            }
            return false;
        }


        public bool profesionalEnObra(uint leg)
        {
            foreach(CObra obra in this.lista_obras)
            {
                if (obra.GetProfesional().GetLegajo() == leg)
                {
                    return true;
                }
            }
            return false;
        }

        public CProfesional buscarProfesional(uint legajo)
        {
            foreach (CProfesional profesional in this.lista_profesionales)
            {
                if (profesional.GetLegajo() == legajo)
                {
                    return profesional;
                }
            }
            return null;
        }

        /*Crear Profesional*/
        public bool crear(uint leg, string ape, string nom, string titu, ulong matri, string consejo, uint porcentaje)
        {
            CProfesional profesional = buscarProfesional(leg);
            if(profesional == null)
            {
                this.lista_profesionales.Add(new CProfesional(leg, ape, nom, matri, titu, consejo, porcentaje));
                return true;
            }
            return false;
        }

        /*Eliminar Profesional*/

        public bool eliminar(uint leg)
        {
            CProfesional profesional = this.buscarProfesional(leg);
            if(profesional != null)
            {
                foreach (CObra obra in this.lista_obras)
                {
                    if (obra.GetProfesional().GetLegajo() == leg)
                    {
                        /*Esta en una obra*/
                        return false;
                    }
                }
                /*No esta en una obra*/
                this.lista_profesionales.Remove(profesional);
                return true;
            }
            return false;
        }

        /*Modiicar Profesional*/
        public bool modificar(string codigo, uint leg)
        {
            foreach(CObra obra in this.lista_obras)
            {
                if(obra.GetCodigo()==codigo)
                {
                    foreach(CProfesional profesional in this.lista_profesionales)
                    {
                        if(profesional.GetLegajo()==leg)
                        {
                            obra.SetProfesional(profesional);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
 
        /*Datos obra*/
        public string datosObras(string codigo)
        {
            string dato = "";
            CObra obra = this.buscar(codigo);
            if(obra != null)
            {
                dato += obra.GetDatoObra();
                dato += "\n\n";
                return dato;
            }
            else
            {
                return "Obra inexistente.";
            }
        }

        /*Datos Empleados*/
        public string datosEmpleados()
        {
            this.lista_obreros_en_obra.Sort();
            this.lista_profesionales.Sort();
            string datos = "";
            foreach(CObrero obreros in this.lista_obreros_en_obra)
            {
                float montoSindicato = 0;
            
                datos += obreros.GetInfo();
                datos += " Sueldo: ";
                datos += obreros.calcularHaberMensual(montoSindicato).ToString();
                datos += "\n\n";
            }
            foreach(CProfesional profesionales in this.lista_profesionales)
            {
                float monto = 0;
                float canon = 0;
                if(profesionalEnObra(profesionales.GetLegajo()) == true)
                {
                    canon = CProfesional.GetCanonUniversal();
                }
                monto = CProfesional.GetMontoSindicato() + (CProfesional.GetMontoSindicato() / 100 * profesionales.GetPorcentaje() + canon);
                datos += profesionales.GetInfo();
                datos += " Sueldo: ";
                datos += monto.ToString();
                datos += "\n\n";
            }
            return datos;
        }
    }
}

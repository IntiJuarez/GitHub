using System;
using System.Collections;

namespace Reparar
{
     public class CObra
    {
        private string codigo;
        private string direccion;
        private ArrayList lista_obreros = new ArrayList(0);
        private CProfesional profesional;


        public CObra(string cod, string dire, CProfesional prof)
        {
            this.codigo = cod;
            this.direccion = dire;
            this.profesional = prof;
        }

        public string GetCodigo() { return this.codigo; }
        public string GetDireccion() { return this.direccion; }

        public CProfesional GetProfesional()
        {
            return this.profesional;
            
        }
        public void SetProfesional(CProfesional prof)
        {
            this.profesional = prof;
        }

        public string GetDatoObra()
        {
            string prof = "Profesional sin designar.";
            if(this.profesional != null)
            {
                prof = this.profesional.GetInfo();
            }
            string datos = "";
            foreach(CObrero obrero in this.lista_obreros)
            {
                datos += obrero.GetInfo() + "\n";
            }
            return " Código Obra: " + this.codigo + " Dirección: " + this.direccion + "\n\nProfesional: " + prof + "\n\nObreros: " + "\n"+datos;
        }

        public CObrero buscarObrero(uint leg)
        {
            foreach(CObrero obrero in this.lista_obreros)
            {
                if(obrero.GetLegajo()== leg)
                {
                    return obrero;
                }
            }
            return null;
        }
        
        /*Me fijo si esta asignado en una obra.*/
        public bool obreroAsignado(uint leg)
        {
            foreach(CObrero obrero in this.lista_obreros)
            {
                if(obrero.GetLegajo() == leg)
                {
                    return true;
                }
            }
            return false;
        }

        public bool asignarObero(CObrero obrero)
        {
            CObrero obreroAux = this.buscarObrero(obrero.GetLegajo());
            if(obreroAux == null)
            {
                this.lista_obreros.Add(obrero);
                return true;
            }
            return false;
        }

        //public string  ObrerosEnObra()
        //{
        //    string datos = "";
        //    foreach(CObrero obrero in this.lista_obreros)
        //    {
        //        datos += obrero.GetInfo();
        //        datos += "\n\n";
        //    }
        //    if(datos != "")
        //    {
        //        this.lista_obreros.Sort();
        //    }
        //    return datos;
        //}

        //public string DatoObra()
        //{
        //    string datos = this.GetDatoObra();
        //    datos += "\n\n";
        //    if(this.ObrerosEnObra() == "")
        //    {
        //        datos += "Obra sin obreros.";
        //    }
        //    else
        //    {
        //        datos += this.ObrerosEnObra();
        //    }
        //    return datos;
        //}

    }
}

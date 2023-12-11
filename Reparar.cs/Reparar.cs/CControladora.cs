using System;
using System.Collections;

namespace Reparar
{
    public class CControladora
    {
        public static void Main()
        {
            char opcion;
            Empresa empresa = new Empresa();
            float monto;
            ulong canonMatricula, matri;
            uint porcentajeRef;
            string cat = "";

            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                uint leg;
                string ape, nom, cod;

                switch (opcion)
                {
                    case 'W':
                        string tipoEmp = CInterfaz.PedirDato("1-Obrero          2-Profesional");
                        switch (tipoEmp)
                        {
                            case "1":
                                while (uint.TryParse(CInterfaz.PedirDato("Legajo"), out leg) == false)
                                {
                                    CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                                }
                                if (empresa.legajoUnicoRegistrado(leg) == false)
                                {
                                    ape = CInterfaz.PedirDato("Apellido");
                                    nom = CInterfaz.PedirDato("Nombre");
                                    string oficio = CInterfaz.PedirDato("Oficio");

                                    cat = CInterfaz.PedirDato("\nA-Oficial\nB-Medio-Oficiales\nC-Aprendiz").ToUpper();
                                    switch (cat)
                                    {
                                        case "A":
                                            cat = "Oficial";
                                            if (empresa.crear(leg, ape, nom, oficio, cat) == true)
                                            {
                                                CInterfaz.MostrarInfo("Registro Obrero exitoso.");
                                            }
                                            else
                                            {
                                                CInterfaz.MostrarInfo("Error al crear Obrero.");
                                            }
                                            break;
                                        case "B":
                                            cat = "Medio-Oficiales";
                                            if (empresa.crear(leg, ape, nom, oficio, cat) == true)
                                            {
                                                CInterfaz.MostrarInfo("Registro Obrero exitoso.");
                                            }
                                            else
                                            {
                                                CInterfaz.MostrarInfo("Error al crear Obrero.");
                                            }
                                            break;
                                        case "C":
                                            cat = "Aprendiz";
                                            if (empresa.crear(leg, ape, nom, oficio, cat) == true)
                                            {
                                                CInterfaz.MostrarInfo("Registro obrero exitoso.");
                                            }
                                            else
                                            {
                                                CInterfaz.MostrarInfo("Legajo existente.");
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo("Legajo existente.");
                                }

                                break;

                            case "2":
                                while(uint.TryParse(CInterfaz.PedirDato("Legajo"),out leg) == false)
                                {
                                    CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                                }
                                if (empresa.legajoUnicoRegistrado(leg) == false)
                                {
                                    ape = CInterfaz.PedirDato("Apellido");
                                    nom = CInterfaz.PedirDato("Nombre");
                                    string titu = CInterfaz.PedirDato("Título");
                                    while(ulong.TryParse(CInterfaz.PedirDato("Matrícula"),out matri) == false)
                                    {
                                        CInterfaz.MostrarInfo("El dato incorrecto. \nVuelva a intentar.");
                                    }
                                    string conse = CInterfaz.PedirDato("Consejo profesional");
                                    while(uint.TryParse(CInterfaz.PedirDato("Porcentaje: "), out porcentajeRef) == false)
                                    {
                                        CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                                    }
                                    if (empresa.crear(leg, ape, nom, titu, matri, conse, porcentajeRef) == true)
                                    {
                                        CInterfaz.MostrarInfo("Registro Profesional exitoso.");
                                    }
                                    else
                                    {
                                        CInterfaz.MostrarInfo("Error al crear profesional.");
                                    }
                                }
                                else
                                {
                                    CInterfaz.MostrarInfo("Legajo existente.");
                                }
                                break;
                        }
                        break;

                    case 'Q':
                        while(float.TryParse(CInterfaz.PedirDato("Ingreso el monto: "), out monto) == false)
                        {
                            CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                        }
                        CEmpleado.SetMontoSindicato(monto);
                        //Empresa.asignarMonto(monto);
                        break;

                    case 'J':
                        while(ulong.TryParse(CInterfaz.PedirDato("Canon Profesional: "), out canonMatricula)== false)
                        {
                            CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                        }
                        CProfesional.SetCanonUniversal(canonMatricula);
                        //CProfesional.SetMontoFijo(montoProf);
                        break;

                    case 'P':
                        Console.WriteLine("Monto Sindicato: " + CEmpleado.GetMontoSindicato().ToString());
                        Console.WriteLine("Canon Profesional: " + CProfesional.GetCanonUniversal().ToString());
                        Console.ReadLine();
                        break;

                    case 'E':
                        Console.Write(empresa.datosEmpleados());
                        Console.ReadLine();
                        break;

                    case 'R':
                        cod = CInterfaz.PedirDato("Codigo");
                        if (empresa.obraYaRegistrada(cod) == false)
                        {
                            string dire = CInterfaz.PedirDato("Dirección");
                            while (uint.TryParse(CInterfaz.PedirDato("Legajo del profesional a asignar"), out leg) == false)
                            {
                                CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                            }
                            if (empresa.crear(cod, dire, leg) == true)
                            {
                                CInterfaz.MostrarInfo("Registrado con éxito.");
                            }
                            else
                            {
                                CInterfaz.MostrarInfo("Error al registrar.");
                            }
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Código de obra ya registrado.");
                        }
                      
                        break;

                    case 'Y':
                        cod = CInterfaz.PedirDato("Código de obra");
                        while (uint.TryParse(CInterfaz.PedirDato("Legajo Obrero a designar"), out leg) == false)
                        {
                            CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                        }
                        if (empresa.asignar(cod, leg) == true)
                        {
                           CInterfaz.MostrarInfo("Asignado correctamente");
                        }
                        else
                        {
                          CInterfaz.MostrarInfo("Obrero ya asignado.");
                        }
            
                        break;
                    case 'S':
                        break;

                    case 'U':
                        cod = CInterfaz.PedirDato("Código de obra");
                        Console.WriteLine(empresa.datosObras(cod));
                        Console.ReadLine();
                        break;

                    case 'T':
                        cod = CInterfaz.PedirDato("Código de obra");
                        while(uint.TryParse(CInterfaz.PedirDato("Legajo del profesional"),out leg)==false)
                        {
                            CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                        }
                        if(empresa.modificar(cod, leg) == true)
                        {
                            CInterfaz.MostrarInfo("Profesional modificado");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Error al modificar profesional");
                        }

                        break;


                    case 'I':
                        while(uint.TryParse(CInterfaz.PedirDato("Legajo del profesional que desee eliminar."),out leg)==false)
                        {
                            CInterfaz.MostrarInfo("Dato incorrecto. \nVuelva a intentar.");
                        }
                        if (empresa.eliminar(leg) == true)
                        {
                            CInterfaz.MostrarInfo("Eliminado correctamente.");
                        }
                        else
                        {
                            CInterfaz.MostrarInfo("Profesional supervisando obra.");
                        }

                        break;

                }
            } while (opcion != 'S');
        }
    }
}
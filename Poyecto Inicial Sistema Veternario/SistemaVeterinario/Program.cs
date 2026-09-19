using System;
using System.Collections.Generic;
using SistemaVeterinario.logica;

namespace SistemaVeterinario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClinicaVeterinaria objClinica = new ClinicaVeterinaria();

            Propietario objDueno1 = objClinica.registrarPropietario("P01", "Ana Lopez", "5555-1234", "Zona 10, Guatemala");
            Propietario objDueno2 = objClinica.registrarPropietario("P02", "Carlos Perez", "5555-5678", "Zona 7, Guatemala");

            objClinica.registrarMascota("M01", "Firulais", "Perro", "Labrador", 3, 28.5, objDueno1);
            objClinica.registrarMascota("M02", "Michi", "Gato", "Siames", 2, 4.2, objDueno2);

            objClinica.registrarInsumo("I01", "Vacuna Antirrabica", 45.00, 10);
            objClinica.registrarInsumo("I02", "Antibiotico Amoxicilina", 60.00, 3);
            objClinica.registrarInsumo("I03", "Desparasitante", 30.00, 15);

            int intContadorCitas = 1;
            int intContadorFacturas = 1;
            List<Factura> lstFacturas = new List<Factura>();

            bool blnContinuar = true;

            while (blnContinuar)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=======================================================");
                Console.WriteLine("            Sistema de Gestion Veterinario");
                Console.WriteLine("=======================================================");
                Console.ResetColor();
                Console.WriteLine(" 1. Propietarios y Mascotas");
                Console.WriteLine(" 2. Gestion de Citas");
                Console.WriteLine(" 3. Atender Consulta");
                Console.WriteLine(" 4. Inventario");
                Console.WriteLine(" 5. Salir");
                Console.Write("\n Seleccione una opcion: ");

                string strOpcion = Console.ReadLine()?.Trim();

                switch (strOpcion)
                {
                    case "1":
                        menuPropietariosYMascotas(objClinica);
                        break;

                    case "2":
                        menuCitas(objClinica, ref intContadorCitas);
                        break;

                    case "3":
                        atenderConsulta(objClinica, lstFacturas, ref intContadorFacturas);
                        break;

                    case "4":
                        menuInventario(objClinica);
                        break;

                    case "5":
                        blnContinuar = false;
                        Console.WriteLine("\nGracias por utilizar el sistema. ¡Hasta pronto!");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion no valida. Por favor ingrese un numero del 1 al 5.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void menuPropietariosYMascotas(ClinicaVeterinaria objClinica)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------- Propietarios y Mascotas --------");
            Console.ResetColor();
            Console.WriteLine(" 1. Registrar propietario");
            Console.WriteLine(" 2. Registrar mascota");
            Console.WriteLine(" 3. Ver mascotas registradas");
            Console.WriteLine(" 4. Volver al menu principal");
            Console.Write("\n Seleccione una opcion: ");
            string strOpcion = Console.ReadLine()?.Trim();

            switch (strOpcion)
            {
                case "1":
                    Console.Write("Id del propietario: ");
                    string strIdProp = Console.ReadLine()?.Trim();
                    Console.Write("Nombre completo: ");
                    string strNombreProp = Console.ReadLine()?.Trim();
                    Console.Write("Telefono: ");
                    string strTelProp = Console.ReadLine()?.Trim();
                    Console.Write("Direccion: ");
                    string strDirProp = Console.ReadLine()?.Trim();
                    objClinica.registrarPropietario(strIdProp, strNombreProp, strTelProp, strDirProp);
                    Console.WriteLine("Propietario registrado exitosamente.");
                    break;

                case "2":
                    Console.Write("Id del propietario existente: ");
                    string strIdBusqueda = Console.ReadLine()?.Trim();
                    Propietario objPropietario = objClinica.buscarPropietario(strIdBusqueda);

                    if (objPropietario == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El propietario no existe. Registrelo primero (Regla RN-01).");
                        Console.ResetColor();
                        return;
                    }

                    Console.Write("Id de la mascota: ");
                    string strIdMascota = Console.ReadLine()?.Trim();
                    Console.Write("Nombre de la mascota: ");
                    string strNombreMascota = Console.ReadLine()?.Trim();
                    Console.Write("Especie: ");
                    string strEspecie = Console.ReadLine()?.Trim();
                    Console.Write("Raza: ");
                    string strRaza = Console.ReadLine()?.Trim();
                    Console.Write("Edad (anios): ");
                    int.TryParse(Console.ReadLine(), out int intEdad);
                    Console.Write("Peso (kg): ");
                    double.TryParse(Console.ReadLine(), out double dblPeso);

                    objClinica.registrarMascota(strIdMascota, strNombreMascota, strEspecie, strRaza, intEdad, dblPeso, objPropietario);
                    Console.WriteLine("Mascota registrada exitosamente.");
                    break;

                case "3":
                    objClinica.mostrarMascotas();
                    break;

                case "4":
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion no valida.");
                    Console.ResetColor();
                    break;
            }
        }

        static void menuCitas(ClinicaVeterinaria objClinica, ref int intContadorCitas)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------------- Gestor de citas --------------");
            Console.ResetColor();
            Console.WriteLine(" 1. Agendar cita");
            Console.WriteLine(" 2. Reprogramar cita");
            Console.WriteLine(" 3. Cancelar cita");
            Console.WriteLine(" 4. Ver citas");
            Console.WriteLine(" 5. Volver al menu principal");
            Console.Write("\n Seleccione una opcion: ");
            string strOpcion = Console.ReadLine()?.Trim();

            switch (strOpcion)
            {
                case "1":
                    Console.Write("Id de la mascota: ");
                    string strIdMascota = Console.ReadLine()?.Trim();
                    Mascota objMascota = objClinica.buscarMascota(strIdMascota);

                    if (objMascota == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La mascota no existe. Registrela primero (Regla RN-02).");
                        Console.ResetColor();
                        return;
                    }

                    Console.Write("Fecha (dd/mm/aaaa): ");
                    string strFecha = Console.ReadLine()?.Trim();
                    Console.Write("Hora: ");
                    string strHora = Console.ReadLine()?.Trim();
                    Console.Write("Motivo de la consulta: ");
                    string strMotivo = Console.ReadLine()?.Trim();
                    Console.Write("Veterinario asignado: ");
                    string strVeterinario = Console.ReadLine()?.Trim();

                    string strIdCita = "C" + intContadorCitas.ToString("D2");
                    intContadorCitas++;
                    objClinica.agendarCita(strIdCita, strFecha, strHora, strMotivo, objMascota, strVeterinario);
                    Console.WriteLine($"Cita agendada exitosamente con id {strIdCita}.");
                    break;

                case "2":
                    Console.Write("Id de la cita a reprogramar: ");
                    Cita objCitaReprog = objClinica.buscarCita(Console.ReadLine()?.Trim());
                    if (objCitaReprog == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La cita no existe.");
                        Console.ResetColor();
                        return;
                    }
                    Console.Write("Nueva fecha: ");
                    string strNuevaFecha = Console.ReadLine()?.Trim();
                    Console.Write("Nueva hora: ");
                    string strNuevaHora = Console.ReadLine()?.Trim();
                    objCitaReprog.reprogramar(strNuevaFecha, strNuevaHora);
                    Console.WriteLine("Cita reprogramada exitosamente.");
                    break;

                case "3":
                    Console.Write("Id de la cita a cancelar: ");
                    Cita objCitaCancelar = objClinica.buscarCita(Console.ReadLine()?.Trim());
                    if (objCitaCancelar == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La cita no existe.");
                        Console.ResetColor();
                        return;
                    }
                    objCitaCancelar.cancelar();
                    Console.WriteLine("Cita cancelada exitosamente.");
                    break;

                case "4":
                    objClinica.mostrarCitas();
                    break;

                case "5":
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion no valida.");
                    Console.ResetColor();
                    break;
            }
        }

        static void atenderConsulta(ClinicaVeterinaria objClinica, List<Factura> lstFacturas, ref int intContadorFacturas)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---------------- ATENDER CONSULTA ----------------");
            Console.ResetColor();

            objClinica.mostrarCitas();
            Console.Write("Id de la cita a atender: ");
            Cita objCita = objClinica.buscarCita(Console.ReadLine()?.Trim());

            if (objCita == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: La cita no existe.");
                Console.ResetColor();
                return;
            }

            Console.Write("Diagnostico: ");
            string strDiagnostico = Console.ReadLine()?.Trim();
            Console.Write("Tratamiento indicado: ");
            string strTratamiento = Console.ReadLine()?.Trim();

            Console.Write("¿Se aplico alguna vacuna? (S/N): ");
            string strVacuna = "";
            if ((Console.ReadLine()?.Trim().ToUpper()) == "S")
            {
                Console.Write("Nombre de la vacuna: ");
                strVacuna = Console.ReadLine()?.Trim();
            }

            objCita.atender(strDiagnostico, strTratamiento, strVacuna);

            Console.Write("¿El tratamiento requiere medicamento/insumo? (S/N): ");
            if ((Console.ReadLine()?.Trim().ToUpper()) == "S")
            {
                objClinica.mostrarInventario();
                Console.Write("Codigo del insumo: ");
                Insumo objInsumo = objClinica.buscarInsumo(Console.ReadLine()?.Trim());

                if (objInsumo == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El insumo no existe en el inventario.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("Cantidad requerida: ");
                    int.TryParse(Console.ReadLine(), out int intCantidad);
                    objClinica.aplicarInsumoATratamiento(objCita, objInsumo, intCantidad);
                }
            }

            objCita.finalizar();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Consulta finalizada.");
            Console.ResetColor();

            string strNumFactura = "F" + intContadorFacturas.ToString("D3");
            intContadorFacturas++;
            Factura objFactura = objClinica.generarFactura(strNumFactura, objCita.strFecha, 75.00, objCita);

            if (objFactura != null)
            {
                lstFacturas.Add(objFactura);
                objFactura.mostrarFactura();
            }
        }

        static void menuInventario(ClinicaVeterinaria objClinica)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------ INVENTARIO ------------------");
            Console.ResetColor();
            Console.WriteLine(" 1. Registrar nuevo insumo");
            Console.WriteLine(" 2. Actualizar stock");
            Console.WriteLine(" 3. Ver inventario");
            Console.WriteLine(" 4. Volver al menu principal");
            Console.Write("\n Seleccione una opcion: ");
            string strOpcion = Console.ReadLine()?.Trim();

            switch (strOpcion)
            {
                case "1":
                    Console.Write("Codigo del insumo: ");
                    string strCodigo = Console.ReadLine()?.Trim();
                    Console.Write("Nombre: ");
                    string strNombre = Console.ReadLine()?.Trim();
                    Console.Write("Precio unitario: ");
                    double.TryParse(Console.ReadLine(), out double dblPrecio);
                    Console.Write("Stock inicial: ");
                    int.TryParse(Console.ReadLine(), out int intStockInicial);
                    objClinica.registrarInsumo(strCodigo, strNombre, dblPrecio, intStockInicial);
                    Console.WriteLine("Insumo registrado exitosamente.");
                    break;

                case "2":
                    Console.Write("Codigo del insumo: ");
                    Insumo objInsumo = objClinica.buscarInsumo(Console.ReadLine()?.Trim());
                    if (objInsumo == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El insumo no existe. Registrelo primero.");
                        Console.ResetColor();
                        return;
                    }
                    Console.Write("Cantidad a ingresar: ");
                    int.TryParse(Console.ReadLine(), out int intCantidad);
                    objInsumo.reabastecer(intCantidad);
                    Console.WriteLine("Stock actualizado exitosamente.");
                    break;

                case "3":
                    objClinica.mostrarInventario();
                    break;

                case "4":
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion no valida.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}

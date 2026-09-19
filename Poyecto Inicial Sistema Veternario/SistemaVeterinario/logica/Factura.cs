namespace SistemaVeterinario.logica
{
    public class Factura
    {
        public string strNumero { get; set; }
        public string strFecha { get; set; }
        public double dblCostoConsulta { get; set; }
        public Cita objCita { get; set; }

        // Constructor
        public Factura(string strNumero, string strFecha, double dblCostoConsulta, Cita objCita)
        {
            this.strNumero = strNumero;
            this.strFecha = strFecha;
            this.dblCostoConsulta = dblCostoConsulta;
            this.objCita = objCita;
        }

        public double calcularTotal()
        {
            double dblTotal = dblCostoConsulta;
            if (objCita != null && objCita.objInsumoUtilizado != null)
            {
                dblTotal += objCita.objInsumoUtilizado.dblPrecioUnitario * objCita.intCantidadInsumo;
            }
            return dblTotal;
        }

        public void mostrarFactura()
        {
            Console.WriteLine("\n================= Factura =================");
            Console.WriteLine($" No. Factura: {strNumero}    Fecha: {strFecha}");
            if (objCita != null)
            {
                Console.WriteLine($" Mascota: {objCita.objMascota?.strNombre}  Veterinario: {objCita.strVeterinario}");
                Console.WriteLine($" Diagnostico: {objCita.strDiagnostico}");
                Console.WriteLine($" Costo consulta:   Q{dblCostoConsulta,8:F2}");
                if (objCita.objInsumoUtilizado != null)
                {
                    double dblSubInsumo = objCita.objInsumoUtilizado.dblPrecioUnitario * objCita.intCantidadInsumo;
                    Console.WriteLine($" Insumo ({objCita.objInsumoUtilizado.strNombre} x{objCita.intCantidadInsumo}): Q{dblSubInsumo,8:F2}");
                }
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($" Total:    Q{calcularTotal(),8:F2}");
            Console.WriteLine("=============================================\n");
        }
    }
}

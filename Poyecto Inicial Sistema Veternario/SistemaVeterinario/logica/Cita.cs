namespace SistemaVeterinario.logica
{
    public class Cita
    {
        public string strId { get; set; }
        public string strFecha { get; set; }
        public string strHora { get; set; }
        public string strMotivo { get; set; }
        public string strVeterinario { get; set; }
        public string strEstado { get; set; }
        public string strDiagnostico { get; set; }
        public string strTratamiento { get; set; }
        public string strVacunaAplicada { get; set; }
        public Mascota objMascota { get; set; }
        public Insumo objInsumoUtilizado { get; set; }
        public int intCantidadInsumo { get; set; }

        public Cita(string strId, string strFecha, string strHora, string strMotivo,
                     Mascota objMascota, string strVeterinario)
        {
            this.strId = strId;
            this.strFecha = strFecha;
            this.strHora = strHora;
            this.strMotivo = strMotivo;
            this.objMascota = objMascota;
            this.strVeterinario = strVeterinario;
            this.strEstado = "Programada";
            this.strDiagnostico = "";
            this.strTratamiento = "";
            this.strVacunaAplicada = "";
            this.objInsumoUtilizado = null;
            this.intCantidadInsumo = 0;
        }

        public void reprogramar(string strNuevaFecha, string strNuevaHora)
        {
            this.strFecha = strNuevaFecha;
            this.strHora = strNuevaHora;
            this.strEstado = "Reprogramada";
        }

        public void cancelar()
        {
            this.strEstado = "Cancelada";
        }

        public void atender(string strDiagnostico, string strTratamiento, string strVacuna)
        {
            this.strEstado = "En Atencion";
            this.strDiagnostico = strDiagnostico;
            this.strTratamiento = strTratamiento;
            this.strVacunaAplicada = strVacuna;
        }

        public bool usarInsumo(Insumo objInsumo, int intCantidad)
        {
            this.objInsumoUtilizado = objInsumo;
            this.intCantidadInsumo = intCantidad;
            return objInsumo != null && objInsumo.descontarStock(intCantidad);
        }

        public void finalizar()
        {
            this.strEstado = "Atendida";
        }

        public void mostrarCita()
        {
            string strNombreMascota = objMascota != null ? objMascota.strNombre : "N/D";
            Console.WriteLine($"[{strId}] {strFecha} {strHora} - Mascota: {strNombreMascota} - Vet: {strVeterinario} - Estado: {strEstado}");
        }
    }
}

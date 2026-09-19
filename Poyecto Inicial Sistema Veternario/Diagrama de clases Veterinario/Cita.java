public class Cita {
    private String id;
    private String fecha;
    private String hora;
    private String motivo;
    private String estado;
    private String diagnostico;
    private String tratamiento;
    private String vacunaAplicada;
    private Mascota mascota;
    private Veterinario veterinario;
    private Insumo insumoUtilizado;
    private int cantidadInsumo;

    public Cita() {
        this.id = "";
        this.fecha = "";
        this.hora = "";
        this.motivo = "";
        this.estado = "Programada";
        this.diagnostico = "";
        this.tratamiento = "";
        this.vacunaAplicada = "";
        this.mascota = null;
        this.veterinario = null;
        this.insumoUtilizado = null;
        this.cantidadInsumo = 0;
    }

    public Cita(String id, String fecha, String hora, String motivo, Mascota mascota, Veterinario veterinario) {
        this.id = id;
        this.fecha = fecha;
        this.hora = hora;
        this.motivo = motivo;
        this.estado = "Programada";
        this.diagnostico = "";
        this.tratamiento = "";
        this.vacunaAplicada = "";
        this.mascota = mascota;
        this.veterinario = veterinario;
        this.insumoUtilizado = null;
        this.cantidadInsumo = 0;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public String getHora() {
        return hora;
    }

    public void setHora(String hora) {
        this.hora = hora;
    }

    public String getMotivo() {
        return motivo;
    }

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }

    public String getDiagnostico() {
        return diagnostico;
    }

    public String getTratamiento() {
        return tratamiento;
    }

    public Mascota getMascota() {
        return mascota;
    }

    public Veterinario getVeterinario() {
        return veterinario;
    }

    public Insumo getInsumoUtilizado() {
        return insumoUtilizado;
    }

    public int getCantidadInsumo() {
        return cantidadInsumo;
    }

    public void reprogramar(String nuevaFecha, String nuevaHora) {
        this.fecha = nuevaFecha;
        this.hora = nuevaHora;
        this.estado = "Reprogramada";
    }

    public void cancelar() {
        this.estado = "Cancelada";
    }

    public void atender(String diagnostico, String tratamiento, String vacuna) {
        this.estado = "En Atencion";
        this.diagnostico = diagnostico;
        this.tratamiento = tratamiento;
        this.vacunaAplicada = vacuna;
    }

    public boolean usarInsumo(Insumo insumo, int cantidad) {
        this.insumoUtilizado = insumo;
        this.cantidadInsumo = cantidad;
        return insumo != null && insumo.descontarStock(cantidad);
    }

    public void finalizar() {
        this.estado = "Atendida";
    }

    @Override
    public String toString() {
        String nombreMascota = (mascota != null) ? mascota.getNombre() : "N/D";
        return "Cita [" + id + "] " + fecha + " " + hora + " - Mascota: " + nombreMascota + " - Estado: " + estado;
    }
}

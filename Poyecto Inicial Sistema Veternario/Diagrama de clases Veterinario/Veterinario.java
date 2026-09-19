public class Veterinario extends Persona {
    private String numeroColegiado;
    private String especialidad;

    /**
     * Constructor por defecto.
     */
    public Veterinario() {
        super();
        this.numeroColegiado = "";
        this.especialidad = "General";
    }

    public Veterinario(String id, String nombre, String apellido, String numeroColegiado) {
        super(id, nombre, apellido);
        this.numeroColegiado = numeroColegiado;
        this.especialidad = "General";
    }

    public Veterinario(String id, String nombre, String apellido, String telefono, String email,
                        String numeroColegiado, String especialidad) {
        super(id, nombre, apellido, telefono, email);
        this.numeroColegiado = numeroColegiado;
        this.especialidad = especialidad;
    }

    public String getNumeroColegiado() {
        return numeroColegiado;
    }

    public void setNumeroColegiado(String numeroColegiado) {
        this.numeroColegiado = numeroColegiado;
    }

    public String getEspecialidad() {
        return especialidad;
    }

    public void setEspecialidad(String especialidad) {
        this.especialidad = especialidad;
    }

    @Override
    public void mostrarInformacion() {
        super.mostrarInformacion();
        System.out.println("Colegiado: " + numeroColegiado);
        System.out.println("Especialidad: " + especialidad);
    }

    @Override
    public String toString() {
        return "Veterinario [nombre=" + getNombreCompleto() + ", colegiado=" + numeroColegiado + "]";
    }
}

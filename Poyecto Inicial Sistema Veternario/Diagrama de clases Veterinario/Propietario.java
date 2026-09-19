public class Propietario extends Persona {
    private String direccion;

    public Propietario() {
        super();
        this.direccion = "";
    }

    public Propietario(String id, String nombre, String apellido, String direccion) {
        super(id, nombre, apellido);
        this.direccion = direccion;
    }

    public Propietario(String id, String nombre, String apellido, String telefono, String email, String direccion) {
        super(id, nombre, apellido, telefono, email);
        this.direccion = direccion;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    @Override
    public void mostrarInformacion() {
        super.mostrarInformacion();
        System.out.println("Direccion: " + direccion);
    }

    @Override
    public String toString() {
        return "Propietario [nombre=" + getNombreCompleto() + ", direccion=" + direccion + "]";
    }
}

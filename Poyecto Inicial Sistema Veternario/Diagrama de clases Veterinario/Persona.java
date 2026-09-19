public abstract class Persona {
    private String id;
    private String nombre;
    private String apellido;
    private String telefono;
    private String email;

    public Persona() {
        this.id = "";
        this.nombre = "";
        this.apellido = "";
        this.telefono = "";
        this.email = "";
    }

    public Persona(String id, String nombre, String apellido) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = "";
        this.email = "";
    }

    public Persona(String id, String nombre, String apellido, String telefono, String email) {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.email = email;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellido() {
        return apellido;
    }

    public void setApellido(String apellido) {
        this.apellido = apellido;
    }

    public String getNombreCompleto() {
        return this.nombre + " " + this.apellido;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void mostrarInformacion() {
        System.out.println("ID: " + id);
        System.out.println("Nombre: " + getNombreCompleto());
        System.out.println("Telefono: " + telefono);
        System.out.println("Email: " + email);
    }

    @Override
    public String toString() {
        return "Persona [id=" + id + ", nombreCompleto=" + getNombreCompleto() + "]";
    }
}

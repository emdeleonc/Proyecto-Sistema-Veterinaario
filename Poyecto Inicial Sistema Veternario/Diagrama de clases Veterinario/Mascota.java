public class Mascota {
    private String id;
    private String nombre;
    private String especie;
    private String raza;
    private int edad;
    private double peso;
    private Propietario propietario;

    public Mascota() {
        this.id = "";
        this.nombre = "";
        this.especie = "";
        this.raza = "";
        this.edad = 0;
        this.peso = 0.0;
        this.propietario = null;
    }

    public Mascota(String id, String nombre, String especie, String raza, int edad, double peso, Propietario propietario) {
        this.id = id;
        this.nombre = nombre;
        this.especie = especie;
        this.raza = raza;
        this.edad = Math.max(0, edad);
        this.peso = Math.max(0.0, peso);
        this.propietario = propietario;
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

    public String getEspecie() {
        return especie;
    }

    public void setEspecie(String especie) {
        this.especie = especie;
    }

    public String getRaza() {
        return raza;
    }

    public void setRaza(String raza) {
        this.raza = raza;
    }

    public int getEdad() {
        return edad;
    }

    public void setEdad(int edad) {
        this.edad = Math.max(0, edad);
    }

    public double getPeso() {
        return peso;
    }

    public void setPeso(double peso) {
        this.peso = Math.max(0.0, peso);
    }

    public Propietario getPropietario() {
        return propietario;
    }

    public void setPropietario(Propietario propietario) {
        this.propietario = propietario;
    }

    public boolean tienePropietarioValido() {
        return propietario != null;
    }

    @Override
    public String toString() {
        String nombreDueno = (propietario != null) ? propietario.getNombreCompleto() : "Sin propietario";
        return "Mascota [" + id + "] " + nombre + " (" + especie + " - " + raza + "), Dueno: " + nombreDueno;
    }
}

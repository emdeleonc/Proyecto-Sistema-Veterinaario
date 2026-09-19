public class Insumo {
    private String codigo;
    private String nombre;
    private double precioUnitario;
    private int stock;

    public Insumo() {
        this.codigo = "";
        this.nombre = "";
        this.precioUnitario = 0.0;
        this.stock = 0;
    }

    public Insumo(String codigo, String nombre, double precioUnitario, int stock) {
        this.codigo = codigo;
        this.nombre = nombre;
        this.precioUnitario = Math.max(0.0, precioUnitario);
        this.stock = Math.max(0, stock);
    }

    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public double getPrecioUnitario() {
        return precioUnitario;
    }

    public void setPrecioUnitario(double precioUnitario) {
        this.precioUnitario = Math.max(0.0, precioUnitario);
    }

    public int getStock() {
        return stock;
    }

    public void setStock(int stock) {
        this.stock = Math.max(0, stock);
    }

    public boolean hayStock(int cantidad) {
        return cantidad > 0 && this.stock >= cantidad;
    }

    public boolean descontarStock(int cantidad) {
        if (!hayStock(cantidad)) {
            return false;
        }
        this.stock -= cantidad;
        return true;
    }

    public void reabastecer(int cantidad) {
        if (cantidad > 0) {
            this.stock += cantidad;
        }
    }

    @Override
    public String toString() {
        return "[" + codigo + "] " + nombre + " - Q" + String.format("%.2f", precioUnitario) + " (Stock: " + stock + ")";
    }
}

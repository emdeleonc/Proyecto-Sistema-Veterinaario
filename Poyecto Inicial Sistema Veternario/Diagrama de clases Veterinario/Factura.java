public class Factura {
    private String numero;
    private String fecha;
    private double costoConsulta;
    private Cita cita;

    public Factura() {
        this.numero = "";
        this.fecha = "";
        this.costoConsulta = 0.0;
        this.cita = null;
    }

    public Factura(String numero, String fecha, double costoConsulta, Cita cita) {
        this.numero = numero;
        this.fecha = fecha;
        this.costoConsulta = Math.max(0.0, costoConsulta);
        this.cita = cita;
    }

    public String getNumero() {
        return numero;
    }

    public String getFecha() {
        return fecha;
    }

    public Cita getCita() {
        return cita;
    }

    public double calcularTotal() {
        double total = costoConsulta;
        if (cita != null && cita.getInsumoUtilizado() != null) {
            total += cita.getInsumoUtilizado().getPrecioUnitario() * cita.getCantidadInsumo();
        }
        return total;
    }

    @Override
    public String toString() {
        return "Factura [" + numero + "] Fecha: " + fecha + " - Total: Q" + String.format("%.2f", calcularTotal());
    }
}

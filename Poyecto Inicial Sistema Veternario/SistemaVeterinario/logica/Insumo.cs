namespace SistemaVeterinario.logica
{
    public class Insumo
    {
        public string strCodigo { get; set; }
        public string strNombre { get; set; }
        public double dblPrecioUnitario { get; set; }
        public int intStock { get; set; }


        public Insumo(string strCodigo, string strNombre, double dblPrecioUnitario, int intStock)
        {
            this.strCodigo = strCodigo;
            this.strNombre = strNombre;
            this.dblPrecioUnitario = dblPrecioUnitario;
            this.intStock = intStock;
        }

        public bool hayStock(int intCantidad)
        {
            return intCantidad > 0 && this.intStock >= intCantidad;
        }

        public bool descontarStock(int intCantidad)
        {
            if (!hayStock(intCantidad)) return false;
            this.intStock -= intCantidad;
            return true;
        }

        public void reabastecer(int intCantidad)
        {
            if (intCantidad > 0) this.intStock += intCantidad;
        }

        public void mostrarInsumo()
        {
            Console.WriteLine($"[{strCodigo}] {strNombre} - Q{dblPrecioUnitario:F2} | Stock: {intStock}");
        }
    }
}

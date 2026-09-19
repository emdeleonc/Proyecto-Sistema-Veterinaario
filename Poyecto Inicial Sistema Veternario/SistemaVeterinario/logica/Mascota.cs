namespace SistemaVeterinario.logica
{

    public class Mascota
    {
        public string strId { get; set; }
        public string strNombre { get; set; }
        public string strEspecie { get; set; }
        public string strRaza { get; set; }
        public int intEdad { get; set; }
        public double dblPeso { get; set; }
        public Propietario objPropietario { get; set; }

        public Mascota(string strId, string strNombre, string strEspecie, string strRaza,
                        int intEdad, double dblPeso, Propietario objPropietario)
        {
            this.strId = strId;
            this.strNombre = strNombre;
            this.strEspecie = strEspecie;
            this.strRaza = strRaza;
            this.intEdad = intEdad;
            this.dblPeso = dblPeso;
            this.objPropietario = objPropietario;
        }

        public bool tienePropietarioValido()
        {
            return objPropietario != null;
        }

        public void mostrarMascota()
        {
            string strDueno = objPropietario != null ? objPropietario.strNombre : "Sin propietario";
            Console.WriteLine($"[{strId}] {strNombre} - {strEspecie} ({strRaza}) - Dueño: {strDueno}");
        }
    }
}

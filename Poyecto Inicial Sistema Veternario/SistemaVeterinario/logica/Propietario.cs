using System.Collections.Generic;

namespace SistemaVeterinario.logica
{
    public class Propietario
    {
        public string strId { get; set; }
        public string strNombre { get; set; }
        public string strTelefono { get; set; }
        public string strDireccion { get; set; }
        public List<Mascota> lstMascotas { get; set; }

        public Propietario(string strId, string strNombre, string strTelefono, string strDireccion)
        {
            this.strId = strId;
            this.strNombre = strNombre;
            this.strTelefono = strTelefono;
            this.strDireccion = strDireccion;
            this.lstMascotas = new List<Mascota>();
        }

        public void agregarMascota(Mascota objMascota)
        {
            lstMascotas.Add(objMascota);
        }

        public void mostrarPropietario()
        {
            Console.WriteLine($"[{strId}] {strNombre} - Tel: {strTelefono} - Mascotas: {lstMascotas.Count}");
        }
    }
}

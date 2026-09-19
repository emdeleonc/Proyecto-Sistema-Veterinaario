using System.Collections.Generic;

namespace SistemaVeterinario.logica
{
    public class ClinicaVeterinaria
    {
        public List<Propietario> lstPropietarios { get; set; }
        public List<Mascota> lstMascotas { get; set; }
        public List<Cita> lstCitas { get; set; }
        public List<Insumo> lstInsumos { get; set; }

        public ClinicaVeterinaria()
        {
            this.lstPropietarios = new List<Propietario>();
            this.lstMascotas = new List<Mascota>();
            this.lstCitas = new List<Cita>();
            this.lstInsumos = new List<Insumo>();
        }

        public Propietario buscarPropietario(string strId)
        {
            return lstPropietarios.Find(p => p.strId.ToUpper() == strId.ToUpper());
        }

        public Propietario registrarPropietario(string strId, string strNombre, string strTelefono, string strDireccion)
        {
            var objPropietario = new Propietario(strId, strNombre, strTelefono, strDireccion);
            lstPropietarios.Add(objPropietario);
            return objPropietario;
        }

        public Mascota registrarMascota(string strId, string strNombre, string strEspecie, string strRaza,
                                         int intEdad, double dblPeso, Propietario objPropietario)
        {
            if (objPropietario == null)
            {
                Console.WriteLine("Error: No se puede registrar la mascota sin un propietario (Regla RN-01).");
                return null;
            }

            var objMascota = new Mascota(strId, strNombre, strEspecie, strRaza, intEdad, dblPeso, objPropietario);
            lstMascotas.Add(objMascota);
            objPropietario.agregarMascota(objMascota);
            return objMascota;
        }

        public Mascota buscarMascota(string strId)
        {
            return lstMascotas.Find(m => m.strId.ToUpper() == strId.ToUpper());
        }

        public Cita agendarCita(string strId, string strFecha, string strHora, string strMotivo,
                                 Mascota objMascota, string strVeterinario)
        {
            if (objMascota == null)
            {
                Console.WriteLine("Error: No se puede agendar la cita porque la mascota no existe (Regla RN-02).");
                return null;
            }

            var objCita = new Cita(strId, strFecha, strHora, strMotivo, objMascota, strVeterinario);
            lstCitas.Add(objCita);
            return objCita;
        }

        public Cita buscarCita(string strId)
        {
            return lstCitas.Find(c => c.strId.ToUpper() == strId.ToUpper());
        }

        public Insumo buscarInsumo(string strCodigo)
        {
            return lstInsumos.Find(i => i.strCodigo.ToUpper() == strCodigo.ToUpper());
        }
        public Insumo registrarInsumo(string strCodigo, string strNombre, double dblPrecio, int intStock)
        {
            var objInsumo = new Insumo(strCodigo, strNombre, dblPrecio, intStock);
            lstInsumos.Add(objInsumo);
            return objInsumo;
        }

        public void aplicarInsumoATratamiento(Cita objCita, Insumo objInsumo, int intCantidad)
        {
            bool blnDescontado = objCita.usarInsumo(objInsumo, intCantidad);
            if (!blnDescontado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" >>> NOTIFICACION AL ADMINISTRADOR: Stock insuficiente de '{objInsumo.strNombre}'. Favor reponer. <<<");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Insumo '{objInsumo.strNombre}' descontado del inventario ({intCantidad} unidad(es)).");
            }
        }

        public Factura generarFactura(string strNumero, string strFecha, double dblCostoConsulta, Cita objCita)
        {
            if (objCita == null || objCita.strEstado != "Atendida")
            {
                Console.WriteLine("Error: Solo se puede facturar una consulta ya finalizada (Regla RN-05).");
                return null;
            }

            return new Factura(strNumero, strFecha, dblCostoConsulta, objCita);
        }

        public void mostrarMascotas()
        {
            Console.WriteLine("\n---------------- Mascotas registradas ----------------");
            if (lstMascotas.Count == 0)
            {
                Console.WriteLine(" No hay mascotas registradas todavia.");
            }
            foreach (var objMascota in lstMascotas)
            {
                objMascota.mostrarMascota();
            }
            Console.WriteLine("-------------------------------------------------------\n");
        }

        public void mostrarCitas()
        {
            Console.WriteLine("\n------------------- Registro de citas -------------------");
            if (lstCitas.Count == 0)
            {
                Console.WriteLine(" No hay citas registradas todavia.");
            }
            foreach (var objCita in lstCitas)
            {
                objCita.mostrarCita();
            }
            Console.WriteLine("-----------------------------------------------\n");
        }

        public void mostrarInventario()
        {
            Console.WriteLine("\n---------------- Inventario ----------------");
            if (lstInsumos.Count == 0)
            {
                Console.WriteLine(" No hay insumos registrados todavia.");
            }
            foreach (var objInsumo in lstInsumos)
            {
                objInsumo.mostrarInsumo();
            }
            Console.WriteLine("---------------------------------------------\n");
        }
    }
}

using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Nomina
    {
        private readonly RepositorioTecnico datosTecnico;
        private readonly RepositorioServicio datosServicio;
        private readonly RepositorioFactura datosFactura;
        public Nomina()
        {
            datosTecnico = new RepositorioTecnico();
            datosServicio = new RepositorioServicio();
            datosFactura = new RepositorioFactura();
        }
        public void GenerarNomina(Tecnico tecnico,DateTime fechaInicio, DateTime fechaFinal)
        {
            List<Factura> facturas = datosFactura.ObtenerFacturas().Where(f => f.fecha >= fechaInicio && f.fecha <= fechaFinal)
                 .ToList();
            if(facturas.Count == 0)
            {
                throw new Exception("No se encontraron facturas en el periodo especificado.");
            }
            foreach (var factura in facturas)
            {
                foreach (var detalle in factura.DetalleFactura)
                {
                    if (detalle.Servicio.TecnicoId == tecnico.Id)
                    {
                        decimal pago = detalle.Servicio.precio;
                        Console.WriteLine($"Pago para {tecnico.nombre} por servicio {detalle.Servicio.nombre}: {pago}");
                    }
                }
            }

        }
    }
}

using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaFactura
    {
        private readonly RepositorioFactura datosFactura;
        public LogicaFactura()
        {
            datosFactura = new RepositorioFactura();
        }
        public void AñadirFactura(Factura factura)
        {
            try
            {
                ValidarFactura(factura);
                datosFactura.AgregarFactura(factura);
            }catch(Exception ex)
            {
                throw new Exception("Error al añadir la factura: " + ex.Message);
            }

        }
        private void ValidarFactura(Factura factura)
        {
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula.");
            }
            if (factura.Cliente == null)
            {
                throw new ArgumentException("El cliente de la factura no puede ser vacio.", nameof(factura.Cliente));
            }
            if (factura.Vehiculo==null)
            {
                throw new ArgumentException("El vehiculo de la factura no puede ser vacio.", nameof(factura.Vehiculo));
            }
            if (factura.total < 0)
            {
                throw new ArgumentException("El total de la factura no puede ser negativo.", nameof(factura.total));
            }
        }
        public List<Factura> ObtenerFacturas()
        {
            try
            {
                return datosFactura.ObtenerFacturas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas: " + ex.Message);
            }
        }
        public Factura ObtenerFacturaPorId(int id)
        {
            try
            {
                return datosFactura.ObtenerFacturaPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura por ID: " + ex.Message);
            }
        }
        public void ActualizarFactura(Factura factura)
        {
            try
            {
                ValidarFactura(factura);
                datosFactura.ActualizarFactura(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la factura: " + ex.Message);
            }
        }
        public void EliminarFactura(int id)
        {
            try
            {
                datosFactura.EliminarFactura(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la factura: " + ex.Message);
            }
        }
        public List<Factura> ObtenerFacturasPorCliente(string nombre)
        {
            try
            {
                return datosFactura.ObtenerFacturas().Where(f => f.Cliente.nombre.Contains(nombre)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas por cliente: " + ex.Message);
            }
        }
        public List<Factura> ObtenerFacturasPorVehiculo(int vehiculoId)
        {
            try
            {
                return datosFactura.ObtenerFacturas().Where(f => f.vehiculo_id == vehiculoId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las facturas por vehículo: " + ex.Message);
            }
        }

    }
}

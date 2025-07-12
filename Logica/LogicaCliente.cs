using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaCliente
    {
        private readonly RepositorioCliente datosCliente;
        public LogicaCliente()
        {
            datosCliente = new RepositorioCliente();
        }
        public void AñadirCliente(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);
                datosCliente.AgregarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir el cliente: " + ex.Message);
            }
        }
        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(cliente.nombre))
            {
                throw new ArgumentException("El nombre del cliente no puede estar vacío.", nameof(cliente.nombre));
            }
            if (string.IsNullOrWhiteSpace(cliente.telefono))
            {
                throw new ArgumentException("El teléfono del cliente no puede estar vacío.", nameof(cliente.telefono));
            }
        }
        public List<Cliente> ObtenerClientes()
        {
            try
            {
                return datosCliente.ObtenerClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes: " + ex.Message);
            }
        }
        public Cliente ObtenerClientePorId(int id)
        {
            try
            {
                return datosCliente.ObtenerClientePorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por ID: " + ex.Message);
            }
        }
        public void ActualizarCliente(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);
                datosCliente.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente: " + ex.Message);
            }
        }
        public void EliminarCliente(int id)
        {
            try
            {
                datosCliente.EliminarCliente(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente: " + ex.Message);
            }
        }
        public List<Cliente> BuscarClientesPorNombre(string nombre)
        {
            try
            {
                return datosCliente.BuscarClientesPorNombre(nombre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes por nombre: " + ex.Message);
            }
        }
        
    }
}

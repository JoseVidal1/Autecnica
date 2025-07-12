using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioCliente
    {
        public List<Cliente> ObtenerClientes()
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Cliente
                             .Where(c => c.estado == "Activo")
                             .ToList();
            }
        }
        public Cliente ObtenerClientePorId(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Cliente
                             .FirstOrDefault(c => c.id == id && c.estado == "Activo");
            }
        }
        public void AgregarCliente(Cliente cliente)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
            }
        }
        public void ActualizarCliente(Cliente cliente)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void EliminarCliente(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                var cliente = context.Cliente.Find(id);
                if (cliente != null)
                {
                    cliente.estado = "Inactivo";
                    context.Entry(cliente).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public List<Cliente> BuscarClientesPorNombre(string nombre)
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Cliente
                             .Where(c => c.nombre.Contains(nombre) && c.estado == "Activo")
                             .ToList();
            }
        }
    }
}

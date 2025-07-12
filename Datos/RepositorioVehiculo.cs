using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioVehiculo
    {
        public List<Vehiculo> ObtenerVehiculos()
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Vehiculo
                              .Where(v => v.estado == "Activo")
                              .ToList();
            }
        }
        public Vehiculo ObtenerVehiculoPorId(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Vehiculo
                              .FirstOrDefault(v => v.id == id && v.estado == "Activo");
            }
        }
        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Vehiculo.Add(vehiculo);
                context.SaveChanges();
            }
        }
        public void ActualizarVehiculo(Vehiculo vehiculo)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Entry(vehiculo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void EliminarVehiculo(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                var vehiculo = context.Vehiculo.Find(id);
                if (vehiculo != null)
                {
                    vehiculo.estado = "Inactivo";
                    context.Entry(vehiculo).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}

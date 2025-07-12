using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioServicio
    {
        public List<Servicio> ObtenerServicios()
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Servicio
                              .Where(s => s.estado == "Activo")
                              .ToList();
            }
        }
        public Servicio ObtenerServicioPorId(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Servicio
                              .FirstOrDefault(s => s.id == id && s.estado == "Activo");
            }
        }
        public void AgregarServicio(Servicio servicio)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Servicio.Add(servicio);
                context.SaveChanges();
            }
        }
        public void ActualizarServicio(Servicio servicio)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Entry(servicio).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void EliminarServicio(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                var servicio = context.Servicio.Find(id);
                if (servicio != null)
                {
                    servicio.estado = "Inactivo";
                    context.Entry(servicio).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}

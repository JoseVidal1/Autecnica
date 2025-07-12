using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioTecnico
    {
        public List<Tecnico> ObtenerTecnicos()
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Tecnico
                              .Where(t => t.estado == "Activo")
                              .ToList();
            }
        }
        public Tecnico ObtenerTecnicoPorId(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Tecnico
                              .FirstOrDefault(t => t.id == id && t.estado == "Activo");
            }
        }
        public void AgregarTecnico(Tecnico tecnico)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Tecnico.Add(tecnico);
                context.SaveChanges();
            }
        }
        public void ActualizarTecnico(Tecnico tecnico)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Entry(tecnico).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void EliminarTecnico(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                var tecnico = context.Tecnico.Find(id);
                if (tecnico != null)
                {
                    tecnico.estado = "Inactivo";
                    context.Entry(tecnico).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}

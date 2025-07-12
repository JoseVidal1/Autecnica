using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioFactura
    {
        public List<Factura> ObtenerFacturas()
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Factura.ToList();
            }
        }
        public Factura ObtenerFacturaPorId(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                return context.Factura.Find(id);
            }
        }
        public void AgregarFactura(Factura factura)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Factura.Add(factura);
                context.SaveChanges();
            }
        }
        public void ActualizarFactura(Factura factura)
        {
            using (var context = new TallerMecanicoEntities())
            {
                context.Entry(factura).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void EliminarFactura(int id)
        {
            using (var context = new TallerMecanicoEntities())
            {
                
            }
        }
    }
}

using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaServicio
    {
        private readonly RepositorioServicio datosServicio;
        public LogicaServicio()
        {
            datosServicio = new RepositorioServicio();
        }
        public void AñadirServicio(Servicio servicio)
        {
            try
            {
                ValidarServicio(servicio);
                datosServicio.AgregarServicio(servicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir el servicio: " + ex.Message);
            }
        }
        private void ValidarServicio(Servicio servicio)
        {
            if (servicio == null)
            {
                throw new ArgumentNullException(nameof(servicio), "El servicio no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(servicio.nombre))
            {
                throw new ArgumentException("El nombre del servicio no puede estar vacío.", nameof(servicio.nombre));
            }
            if(string.IsNullOrWhiteSpace(servicio.descripcion))
            {
                throw new ArgumentException("La descripción del servicio no puede estar vacía.", nameof(servicio.descripcion));
            }
            if(servicio.garantia_dias < 0)
            {
                throw new ArgumentException("La garantía del servicio no puede ser negativa.", nameof(servicio.garantia_dias));
            }
        }
        public List<Servicio> ObtenerServicios()
        {
            try
            {
                return datosServicio.ObtenerServicios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los servicios: " + ex.Message);
            }
        }
        public Servicio ObtenerServicioPorId(int id)
        {
            try
            {
                return datosServicio.ObtenerServicioPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el servicio por ID: " + ex.Message);
            }
        }
        public void ActualizarServicio(Servicio servicio)
        {
            try
            {
                ValidarServicio(servicio);
                datosServicio.ActualizarServicio(servicio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el servicio: " + ex.Message);
            }
        }
        public void EliminarServicio(int id)
        {
            try
            {
                datosServicio.EliminarServicio(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el servicio: " + ex.Message);
            }
        }
        
        
        
    }
}

using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaTecnico
    {
        private readonly RepositorioTecnico datosTecnico;
        public LogicaTecnico()
        {
            datosTecnico = new RepositorioTecnico();
        }
        public void AñadirTecnico(Tecnico tecnico)
        {
            try
            {
                ValidarTecnico(tecnico);
                datosTecnico.AgregarTecnico(tecnico);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir el técnico: " + ex.Message);
            }
        }
        private void ValidarTecnico(Tecnico tecnico)
        {
            if (tecnico == null)
            {
                throw new ArgumentNullException(nameof(tecnico), "El técnico no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(tecnico.nombre))
            {
                throw new ArgumentException("El nombre del técnico no puede estar vacío.", nameof(tecnico.nombre));
            }
            if (string.IsNullOrWhiteSpace(tecnico.especialidad))
            {
                throw new ArgumentException("La especialidad del técnico no puede estar vacío.", nameof(tecnico.especialidad));
            }
        }
        public List<Tecnico> ObtenerTecnicos()
        {
            try
            {
                return datosTecnico.ObtenerTecnicos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los técnicos: " + ex.Message);
            }
        }
        public Tecnico ObtenerTecnicoPorId(int id)
        {
            try
            {
                return datosTecnico.ObtenerTecnicoPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el técnico por ID: " + ex.Message);
            }
        }
    }
}

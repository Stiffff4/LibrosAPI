using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IData
{
    public interface IDataLibro
    {
        Task<List<Libro>> ObtenerLibros();
        Task<Libro> ObtenerLibroId(int id);
        Task<bool> AgregarLibro(Libro libro);
        Task<bool> ActualizarLibro(Libro libro);
        Task<bool> EliminarLibro(int id);
    }
}

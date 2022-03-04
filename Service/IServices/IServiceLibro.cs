using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IServiceLibro
    {
        Task<IResponse> ObtenerLibros();
        Task<IResponse> ObtenerLibroId(int id);
        Task<IResponse> AgregarLibro(Libro libro);
        Task<IResponse> ActualizarLibro(Libro libro);
        Task<IResponse> EliminarLibro(int id);
    }
}

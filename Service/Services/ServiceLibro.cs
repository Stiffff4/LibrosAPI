using DataAccess.IData;
using DataAccess.Models;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ServiceLibro: IServiceLibro
    {
        private readonly IDataLibro data;
        private readonly IResponse response;
        public ServiceLibro(IDataLibro data, IResponse response)
        {
            this.data = data;
            this.response = response;
        }
        public async Task<IResponse> ObtenerLibros()
        {
            try
            {
                List<Libro> libros = await data.ObtenerLibros();

                if (libros.Count < 1)
                {
                    response.IsError = true;
                    response.SinDatos();
                    return response;
                }

                response.Encontrado(libros);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }

            return response;
        }
        public async Task<IResponse> ObtenerLibroId(int id)
        {
            try
            {
                if (id < 1)
                {
                    response.IsError = true;
                    response.CodigoInvalido();
                    return response;
                }

                var libro = await data.ObtenerLibroId(id);

                if (libro == null)
                {
                    response.IsError = true;
                    response.NoEncontrado(id);
                    return response;
                }

                response.Encontrado(libro);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }

            return response;
        }
        public async Task<IResponse> AgregarLibro(Libro libro)
        {
            try
            {
                var resultado = await data.AgregarLibro(libro);

                if (resultado == false)
                {
                    response.SinExito();
                    return response;
                }

                response.Code = HttpStatusCode.Created;
                response.Message = "El libro ha sido agregado satisfactoriamente";
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }

            return response;
        }
        public async Task<IResponse> ActualizarLibro(Libro libro)
        {
            try
            {
                if (libro.Id < 1)
                {
                    response.CodigoInvalido();
                    return response;
                }

                var resultado = await data.ActualizarLibro(libro);

                if (resultado == false)
                {
                    response.SinExito();
                    return response;
                }

                response.Code = HttpStatusCode.OK;
                response.Message = $"El libro con el código {libro.Id} ha sido actualizado satisfactoriamente.";
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }

            return response;
        }
        public async Task<IResponse> EliminarLibro(int id)
        {
            try
            {
                if (id < 1)
                {
                    response.IsError = true;
                    response.CodigoInvalido();
                    return response;
                }

                var resultado = await data.EliminarLibro(id);

                if (resultado == false)
                {
                    response.IsError = true;
                    response.NoEncontrado(id);
                    return response;
                }

                response.Code = HttpStatusCode.OK;
                response.Message = $"Libro con el código {id} eliminado satisfactoriamente.";
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }

            return response;
        }
    }
}

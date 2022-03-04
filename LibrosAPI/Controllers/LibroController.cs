
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LibrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IServiceLibro service;
        private readonly IResponse response;
        public LibroController(IServiceLibro service, IResponse response)
        {
            this.service = service;
            this.response = response;
        }

        [HttpGet, Route("ObtenerLibros")]
        public async Task<IActionResult> ObtenerLibros()
        {
            var resultado = await service.ObtenerLibros();

            return new ObjectResult(resultado) { StatusCode = (int)resultado.Code };
        }

        [HttpGet, Route("ObtenerLibro/{id}")]
        public async Task<IActionResult> ObtenerLibroId(int id)
        {
            var resultado = await service.ObtenerLibroId(id);

            return new ObjectResult(resultado) { StatusCode = (int)resultado.Code};
        }

        [HttpPost, Route("AgregarLibro")]
        public async Task<IActionResult> AgregarLibro(Libro libro)
        {
            var resultado = await service.AgregarLibro(libro);

            return new ObjectResult(resultado) { StatusCode = (int)resultado.Code };
        }

        [HttpPut, Route("ActualizarLibro")]
        public async Task<IActionResult> ActualizarLibro(Libro libro)
        {
            var resultado = await service.ActualizarLibro(libro);

            return new ObjectResult(resultado) { StatusCode = (int)resultado.Code };
        }

        [HttpDelete, Route("EliminarLibro/{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            var resultado = await service.EliminarLibro(id);

            return new ObjectResult(resultado) { StatusCode = (int)resultado.Code };
        }
    }
}

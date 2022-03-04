using Service.IServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Service.Services
{
    public class Response : IResponse
    {
        public object Entity { get; set; }
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public void CodigoInvalido()
        {
            IsError = true;
            Code = HttpStatusCode.BadRequest;
            Message = "El código no es válido.";
        }

        public void NoEncontrado(int id)
        {
            IsError = true;
            Code = HttpStatusCode.NotFound;
            Message = $"No hay ningún libro con el código {id}.";
        }

        public void Encontrado(object entity)
        {
            Entity = entity;
            Code = HttpStatusCode.OK;
        }

        public void SinDatos()
        {
            IsError = true;
            Code = HttpStatusCode.NotFound;
            Message = "No hay datos";
        }

        public void SinExito()
        {
            IsError = true;
            Code = HttpStatusCode.BadRequest;
            Message = "No se pudo completar la solicitud";
        }
    }
}

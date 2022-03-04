using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Service.IServices
{
    public interface IResponse
    {
       object Entity { get; set; }
       HttpStatusCode Code { get; set; }
       string Message { get; set; }
       bool IsError { get; set; }
       void CodigoInvalido();
       void NoEncontrado(int id);
       void Encontrado(object entity);
       void SinDatos();
       void SinExito();
    }
}

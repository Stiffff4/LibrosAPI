using DataAccess.DataContext;
using DataAccess.IData;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class DataLibro: IDataLibro
    {
        private readonly DBContext context;
        public DataLibro(DBContext context)
        {
            this.context = context;
        }
        public async Task<List<Libro>> ObtenerLibros()
        {
            try
            {
                return await context.Libros.ToListAsync();
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
        public async Task<Libro> ObtenerLibroId(int id)
        {
            try
            {
                return await context.Libros.FindAsync(id);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
        public async Task<bool> AgregarLibro(Libro libro)
        {
            try
            {
                await context.Libros.AddAsync(libro);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
        public async Task<bool> ActualizarLibro(Libro libro)
        {
            try
            {
                context.Libros.Update(libro);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
                //throw e.GetBaseException();
            }
        }
        public async Task<bool> EliminarLibro(int id)
        {
            try
            {
                var libro = context.Libros.Find(id);
                context.Libros.Remove(libro);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }
    }
}

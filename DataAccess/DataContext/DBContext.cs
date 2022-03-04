using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options)
        {
            
        }

        public DbSet<Libro> Libros { get; set; }
    }
}

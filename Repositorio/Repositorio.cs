//using Datos;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Datos.Context;

namespace Repositorio
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        protected ApplicationDbContext _context { get; set; }

        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> TraerTodo()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Buscar(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T BuscarPrimero(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T BuscarPorId(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public T BuscarPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T BuscarPorId(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Adicionar(T Entidad)
        {
            if (_context.Entry<T>(Entidad).State != EntityState.Detached)
                _context.Entry<T>(Entidad).State = EntityState.Added;
            else
                _context.Set<T>().Add(Entidad);
        }

        public void Modificar(T Entidad)
        {
            if (_context.Entry<T>(Entidad).State != EntityState.Detached)
                _context.Set<T>().Attach(Entidad);
            _context.Entry<T>(Entidad).State = EntityState.Modified;

        }

        public void Eliminar(T Entidad)
        {
            if (_context.Entry<T>(Entidad).State != EntityState.Detached)
                _context.Set<T>().Attach(Entidad);
            _context.Entry<T>(Entidad).State = EntityState.Deleted;
        }

        public int Grabar()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            return;
        }

        public System.Data.Common.DbConnection ObtenerContexto()
        {
            return _context.Database.GetDbConnection();
        }

    }
}

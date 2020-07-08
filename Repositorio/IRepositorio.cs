using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> TraerTodo();
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate);
        T BuscarPrimero(Expression<Func<T, bool>> predicate);
        T BuscarPorId(int id);
        T BuscarPorId(string id);

        void Adicionar(T Entidad);
        void Modificar(T Entidad);
        void Eliminar(T Entidad);

        int Grabar();
    }
}
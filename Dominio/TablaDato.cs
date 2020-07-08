using Repositorio;
using System;
using System.Collections.Generic;
using datos = Datos;
using ent = Datos.Entidades.Models;
using System.Linq.Expressions;
using Datos.Context;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace Dominio
{
    public class TablaDato
    {
        private Repositorio<ent.Tabladato> _repositorio = new Repositorio<ent.Tabladato>(new ApplicationDbContext());

        public void Adicionar(ent.Tabladato entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Tabladato entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Tabladato entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Tabladato> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Tabladato BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Tabladato BuscarPrimero(Expression<Func<ent.Tabladato, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Tabladato> Buscar(Expression<Func<ent.Tabladato, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}

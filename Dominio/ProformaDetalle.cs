using Repositorio;
using System;
using System.Collections.Generic;
using datos = Datos;
using ent = Datos.Entidades.Models;
using dto = Datos.Entidades.DTO;
using System.Linq.Expressions;
using Datos.Context;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace Dominio
{
    public class ProformaDetalle
    {
        private Repositorio<ent.Proformadetalle> _repositorio = new Repositorio<ent.Proformadetalle>(new ApplicationDbContext());
        public void Adicionar(ent.Proformadetalle entidad)
        {
            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Proformadetalle entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Proformadetalle entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Proformadetalle> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Proformadetalle BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Proformadetalle BuscarPrimero(Expression<Func<ent.Proformadetalle, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Proformadetalle> Buscar(Expression<Func<ent.Proformadetalle, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}

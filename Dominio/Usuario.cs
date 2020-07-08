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
    public class Usuario
    {
        public bool EditarRol(string IdUsuario, string IdRol)
        {
            List<ent.Comprobante> comprobantes = new List<ent.Comprobante>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ActualizaRol";
            cmd.Parameters.Add("@IdUsuario", System.Data.SqlDbType.NVarChar, 450).Value = IdUsuario;
            cmd.Parameters.Add("@IdRol", System.Data.SqlDbType.NVarChar, 450).Value = IdRol;
            int resultado = cmd.ExecuteNonQuery();

            conn.Close();
            if (resultado != -1)
                return true;
            else
                return false;
        }

        public bool InsertarUsuario( string NombreUsuario, string NombrePersona, string Empresa_id, string RoleId)
        {
            List<ent.Comprobante> comprobantes = new List<ent.Comprobante>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_InsertaUsuario";
            cmd.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.NVarChar, 256).Value = NombreUsuario;
            cmd.Parameters.Add("@NombrePersona", System.Data.SqlDbType.VarChar, 100).Value = NombrePersona;
            cmd.Parameters.Add("@Empresa_id", System.Data.SqlDbType.VarChar, 11).Value = Empresa_id;
            cmd.Parameters.Add("@RoleId", System.Data.SqlDbType.NVarChar, 450).Value = RoleId;
            int resultado = cmd.ExecuteNonQuery();
            
            conn.Close();
            if (resultado != -1)
                return true;
            else
                return false;
        }

        public List<dto.UsuarioGrilla> BuscarUsuarios(dto.UsuarioGrillaRequest request)
        {
            List<dto.UsuarioGrilla> listaUsuarios = new List<dto.UsuarioGrilla>();
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ObtenerUsuarios";
            cmd.Parameters.Add("@NombrePersona", System.Data.SqlDbType.VarChar, 100).Value = request.NombrePersona;
            cmd.Parameters.Add("@NombreUsuario", System.Data.SqlDbType.NVarChar, 256).Value = request.NombreUsuario;
            cmd.Parameters.Add("@Empresa_id", System.Data.SqlDbType.VarChar, 11).Value = request.Empresa_id;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new dto.UsuarioGrilla
                    {
                        IdUsuario = reader["IdUsuario"].ToString(),
                        NombrePersona = reader["NombrePersona"].ToString(),
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        IdRol = reader["IdRol"].ToString(),
                        NombreRol = reader["NombreRol"].ToString(),
                        Empresa_id = reader["Empresa_id"].ToString(),
                    };
                    listaUsuarios.Add(item);
                }
            }
            conn.Close();
            return listaUsuarios;
        }

        private Repositorio<ent.Usuario> _repositorio = new Repositorio<ent.Usuario>(new ApplicationDbContext());
        public void Adicionar(ent.Usuario entidad)
        {

            _repositorio.Adicionar(entidad);
            _repositorio.Grabar();
        }

        public void Modificar(ent.Usuario entidad)
        {
            _repositorio.Modificar(entidad);
            _repositorio.Grabar();
        }

        public void Eliminar(ent.Usuario entidad)
        {
            _repositorio.Eliminar(entidad);
            _repositorio.Grabar();
        }

        public IEnumerable<ent.Usuario> TraerTodo()
        {
            return _repositorio.TraerTodo().ToList();
        }

        public ent.Usuario BuscarPorId(string id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public ent.Usuario BuscarPrimero(Expression<Func<ent.Usuario, bool>> predicate)
        {
            return _repositorio.BuscarPrimero(predicate);
        }

        public IEnumerable<ent.Usuario> Buscar(Expression<Func<ent.Usuario, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }
    }
}

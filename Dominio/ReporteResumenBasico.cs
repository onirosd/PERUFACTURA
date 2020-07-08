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
    public class ReporteResumenBasico
    {
        private Repositorio<ent.Configuracion> _repositorio = new Repositorio<ent.Configuracion>(new ApplicationDbContext());
        public dto.ReporteResumenBasico ObtenerReporteResumenBasico(string empresaId)
        {
            SqlConnection conn = (SqlConnection)_repositorio.ObtenerContexto();
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "USP_ReporteResumenBasico";
            cmd.Parameters.Add("@EmpresaId", System.Data.SqlDbType.VarChar, 11).Value = empresaId;
            dto.ReporteResumenBasico objReporteResumenBasico = new dto.ReporteResumenBasico();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    objReporteResumenBasico.Clientes = (int)reader["Clientes"];
                    objReporteResumenBasico.Comprobantes = (int)reader["Comprobantes"];
                    objReporteResumenBasico.Ganado = reader["Ganado"] != DBNull.Value ? (decimal?)reader["Ganado"] : 0;
                    objReporteResumenBasico.Productos = (int)reader["Productos"];
                    objReporteResumenBasico.Servicios = (int)reader["Servicios"];
                    objReporteResumenBasico.Vendido = reader["Vendido"] != DBNull.Value ? (decimal?)reader["Vendido"] : 0;
                }
            }
            conn.Close();
            return objReporteResumenBasico;
        }
    }
}

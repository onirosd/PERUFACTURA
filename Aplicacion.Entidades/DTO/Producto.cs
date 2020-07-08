using Aplicacion.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class ProductoObtenerRequest
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal Stock { get; set; }
        public string Empresa_id { get; set; }
    }

    public class ProductoServicioRequest
    {
        public string Nombre { get; set; }
        public string EmpresaId { get; set; }
    }

    public class ProductoGuardarMasivoRequest {
        public List<Producto> Productos { get; set; }
    }
}

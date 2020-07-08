using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class ReporteResumenBasico
    {
        public decimal? Vendido { get; set; }
        public decimal? Ganado { get; set; }
        public int Comprobantes { get; set; }
        public int Clientes { get; set; }
        public int Productos { get; set; }
        public int Servicios { get; set; }
    }
}

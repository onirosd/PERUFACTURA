using System;
using System.Collections.Generic;

namespace Datos.Entidades.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Comprobante = new HashSet<Comprobante>();
        }

        public int Id { get; set; }
        public string Ruc { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public string EmpresaId { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string NroDocumento { get; set; }
        public string Correo1 { get; set; }
        public string Correo2 { get; set; }
        public string Correo3 { get; set; }
        public string Correo4 { get; set; }
        public string Correo5 { get; set; }

        public virtual ICollection<Comprobante> Comprobante { get; set; }
    }
}

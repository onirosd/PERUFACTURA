using System;

namespace Ayuda
{
    public class ConstantesErrores
    {
        public const string NoEliminar = "Este <b>registro</b> no puede ser eliminado.";
        public const string NoControlado = "Error no controlado, por favor comuníquese con el administrador del sistema.";
    }
    public class ConstantesAplicacion
    {
        public const int TipoProducto = 1;
        public const int TipoServicio = 2;
        public const int CantidadProdSinStock = 10;
    }
    public class Mensajes
    {
        public const string Guardado = "Los datos se guardaron correctamente.";
        public const string ClienteDuplicado = "El cliente ya existe.";
    }
    public class MensajesTablaDato
    {
        public const string Moneda = "moneda";
    }

    public class EstadosProforma {
        public const byte creado = 1;
        public const byte cerrado = 2;
    }
}

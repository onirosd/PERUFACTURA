using System;
using System.Collections.Generic;
using System.Text;
using ent = Aplicacion.Entidades.Models;
//using dato = Datos.Entidades;
//using AutoMapper;
using dom = Dominio;
using System.Security.Cryptography;

namespace Aplicacion
{
    public class Seguridad
    {
        public bool Login(ent.Usuario request)
        {
            string testString = request.Contrasena;
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(testString);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            var Login = new dom.Usuario().BuscarPrimero(c => c.Usuario1 == request.Usuario1
            && c.EmpresaId == request.EmpresaId && c.Contrasena == hashedString);
            return true;
        }
    }
}

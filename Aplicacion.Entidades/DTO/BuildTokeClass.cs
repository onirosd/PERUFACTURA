using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades.DTO
{
    public class BuildTokenClass
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        //public IList<string> role { get; set; }
        //public string empresa { get; set; }
        public string userId { get; set; }
        //public ErrorClass Error { get; set; }
    }
}

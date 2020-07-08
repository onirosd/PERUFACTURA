using System;
using AutoMapper;

namespace Mapeo
{
    public sealed class MapperInitializer
    {
        public static void ConfigurarMapeos()
        {
            Mapper.Initialize(map =>
            {
                map.AddProfile<Mapeos>();
            });
        }
    }
}

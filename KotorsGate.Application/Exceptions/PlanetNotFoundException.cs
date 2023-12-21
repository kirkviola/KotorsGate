using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Application.Exceptions
{
    public class PlanetNotFoundException : Exception
    {
        public PlanetNotFoundException(int id): base($"No planet found with given Id: {id}") { }
    }
}

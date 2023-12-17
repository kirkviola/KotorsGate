using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Application.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string username) : base($"Invalid password given for user: {username}") { }
    }
}

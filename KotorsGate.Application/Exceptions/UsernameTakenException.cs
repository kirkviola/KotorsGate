using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Application.Exceptions
{
    public class UsernameTakenException : Exception
    {
        public UsernameTakenException(string username) : base($"Username taken: {username}") { }
    }
}

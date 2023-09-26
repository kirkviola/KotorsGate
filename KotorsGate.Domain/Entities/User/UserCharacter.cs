using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.User
{
    public class UserCharacter
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CharacterId { get; set; }

        public UserCharacter() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Location
{
    public class BattlefieldSquare
    {
        public int Id { get; set; }
        public int BattlefieldId { get; set; }

        public BattlefieldSquare() { }
    }
}

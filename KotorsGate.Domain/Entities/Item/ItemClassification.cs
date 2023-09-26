using KotorsGate.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Domain.Entities.Item
{
    public class ItemClassification
    {
        public int Id { get; set; }
        public ItemType Name { get; set; }

        public ItemClassification() { }
    }
}

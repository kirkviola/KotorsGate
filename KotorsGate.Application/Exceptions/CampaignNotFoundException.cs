using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Application.Exceptions
{
    public class CampaignNotFoundException : Exception
    {
        public CampaignNotFoundException(int id): base($"Campaign not found with given id: {id}") { }
    }
}

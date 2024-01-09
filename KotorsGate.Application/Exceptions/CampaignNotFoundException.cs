namespace KotorsGate.Application.Exceptions
{
    public class CampaignNotFoundException : Exception
    {
        public CampaignNotFoundException(int id): base($"Campaign not found with given id: {id}") { }
    }
}

namespace KotorsGate.Application.Exceptions
{
    public class CampaignWithNameExistsException : Exception
    {
        public CampaignWithNameExistsException(string name): base($"Campaign with name {name} already exists.") { }
    }
}

namespace KotorsGate.Application.Security.Models
{
    public record UserAuth(
        // Add any other relevant fields as needed
        int Id,
        string Username,
        IEnumerable<string> Permissions
    );
}

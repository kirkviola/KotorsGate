namespace KotorsGate.Application.Interfaces
{
    public interface ISecurityService
    {
        public int? UserId { get; set; }
        public void SetCurrentUser(int id);
        public Task<bool> HasPermissionAsync(string permission);
    }
}

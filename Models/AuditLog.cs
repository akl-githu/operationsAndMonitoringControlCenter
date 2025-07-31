namespace controlCenter.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
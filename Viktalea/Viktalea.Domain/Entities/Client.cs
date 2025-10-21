namespace Viktalea.Domain.Entities
{
    public class Client: BaseDomainModel
    {
        public string Ruc { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
    }
}

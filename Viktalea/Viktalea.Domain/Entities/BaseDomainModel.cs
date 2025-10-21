namespace Viktalea.Domain.Entities
{
    public class BaseDomainModel
    {
        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

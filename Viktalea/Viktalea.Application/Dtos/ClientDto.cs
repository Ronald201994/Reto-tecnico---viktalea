namespace Viktalea.Application.Dtos
{
    public record ClientDto(
        int Id,
        string Ruc,
        string BusinessName,
        string ContactPhone,
        string ContactEmail,
        string Address);
}

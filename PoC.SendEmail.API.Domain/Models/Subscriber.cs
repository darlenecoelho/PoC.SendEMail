namespace PoC.SendEmail.API.Domain.Models;
public class Subscriber
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public DateTime DateCreated { get; set; }
}

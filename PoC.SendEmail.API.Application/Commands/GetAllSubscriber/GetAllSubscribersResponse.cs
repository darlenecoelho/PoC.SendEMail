namespace PoC.SendEmail.API.Application.Commands.GetAllSubscriber;

public class GetAllSubscribersResponse
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public DateTime DateCreated { get; set; }
}

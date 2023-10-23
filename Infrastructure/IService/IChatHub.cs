namespace Infrastructure.IService;

public interface IChatHub
{
    Task SendMessage(string user, string message);
}

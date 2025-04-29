using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class WebinarHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    // Signaling messages for WebRTC
    public async Task SendOffer(string toUser, object offer)
    {
        await Clients.User(toUser).SendAsync("ReceiveOffer", Context.UserIdentifier, offer);
    }

    public async Task SendAnswer(string toUser, object answer)
    {
        await Clients.User(toUser).SendAsync("ReceiveAnswer", Context.UserIdentifier, answer);
    }

    public async Task SendIceCandidate(string toUser, object candidate)
    {
        await Clients.User(toUser).SendAsync("ReceiveIceCandidate", Context.UserIdentifier, candidate);
    }
}

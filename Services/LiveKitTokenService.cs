using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

public class LiveKitTokenService
{
    private const string ApiKey = "devkey"; 
    private const string ApiSecret = "hopemadridwillwincopadelreyfinalthisyear";

    public string GenerateToken(string identity, string roomName, bool isHost)
    {
        var videoGrant = new Dictionary<string, object>
        {
            { "roomJoin", true },
            { "room", roomName },
            { "canPublish", isHost },         // ✅ Host can publish audio/video
            { "canPublishData", true },        // ✅ Everyone can send messages
            { "canSubscribe", true }           // ✅ Everyone can view streams
        };

        var payload = new JwtPayload
        {
            { "jti", Guid.NewGuid().ToString() }, 
            { "iss", ApiKey },                   
            { "sub", identity },                 
            { "exp", new DateTimeOffset(DateTime.UtcNow.AddHours(2)).ToUnixTimeSeconds() }, // ✅ Token valid for 2 hours
            { "video", videoGrant }              
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(new JwtHeader(creds), payload);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

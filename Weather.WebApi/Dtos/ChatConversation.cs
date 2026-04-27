using Microsoft.Extensions.AI;

namespace Weather.WebApi.Dtos;

public class ChatConversation
{
    public List<ChatMessageDto> Messages { get; set; } = [];

    public ChatMessage[] GetChatMessages()
    {
        return [.. Messages.Select(m => m.ToChatMessage())];
    }
}

public class ChatMessageDto
{
    public string Role { get; set; } = "user";
    public string Content { get; set; } = "";

    public ChatMessage ToChatMessage()
    {
        return new ChatMessage(GetRole(Role), Content);
    }

    private static ChatRole GetRole(string? role)
    {
        return role?.Trim().ToLowerInvariant() switch
        {
            "system" => ChatRole.System,
            "assistant" => ChatRole.Assistant,
            "tool" => ChatRole.Tool,
            "function" => ChatRole.Tool,
            _ => ChatRole.User,
        };
    }
}

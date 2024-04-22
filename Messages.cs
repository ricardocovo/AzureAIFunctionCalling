using Azure.AI.OpenAI;

public class DisplayMessage
{
    public DisplayMessage(ChatRole role, string message)
    {
        Role = role;
        Message = message;
    }
    public string? Message { get; set; }
    public ChatRole Role { get; set; }
}
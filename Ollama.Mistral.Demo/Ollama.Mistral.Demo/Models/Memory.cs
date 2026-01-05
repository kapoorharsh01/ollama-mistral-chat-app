namespace Ollama.Mistral.Demo.Models
{
    public class ChatMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public static class ChatMemory
    {
        public static List<ChatMessage> Messages = new List<ChatMessage>();
    }

    public class askRequestDto { 
        public string Message { get; set; }
    }
}

namespace HeroChatClient.Models
{
    class ChatMessage
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Message => $"{Name}: {Text}";
    }
}

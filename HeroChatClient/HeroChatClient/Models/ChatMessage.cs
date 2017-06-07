using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;

namespace mis321_pa4_api.Model
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool Dead { get; set; }
    }
}
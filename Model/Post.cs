using System;

namespace mis321_pa4_api.Model
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Dead { get; set; }
    }
}
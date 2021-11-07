using mis321_pa4_api.Controllers;
using System;

namespace mis321_pa4_api.Model
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Dead { get; set; }
        public override string ToString()
        {
            return $"{this.Id} - {new UserController().Get(this.UserId).Username}: \"{this.Text}\" ~ {this.Date.ToString("D")} at {this.Date.ToString("t")}";
        }
        public string ToDeleteString()
        {
            return $"{this.Id} - \"{this.Text}\" ~ {this.Date.ToString("D")} at {this.Date.ToString("t")}";
        }
    }
}
namespace mis321_pa4_api.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public int UserOneId { get; set; }
        public int UserTwoId { get; set; }
        public bool Dead { get; set; }
    }
}
using mis321_pa4_api.Interfaces;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class AddMessage : IAddMessage
    {
        public void Add(Message m)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO chats(messageId, chatId, userId, date, text, dead) VALUES(@id, @chatId, @userId, @date, @text, @dead)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", m.Id);
            cmd.Parameters.AddWithValue("@chatId", m.ChatId);
            cmd.Parameters.AddWithValue("@userId", m.UserId);
            cmd.Parameters.AddWithValue("@date", m.Date);
            cmd.Parameters.AddWithValue("@text", m.Text);
            cmd.Parameters.AddWithValue("@dead", m.Dead);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
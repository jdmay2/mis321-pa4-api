using mis321_pa4_api.Interfaces;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class EditMessage : IEditMessage
    {
        public void Edit(Message m)
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE messages SET chatId=@chatId, userId=@userId, date=@date, text=@text, dead=@dead WHERE messageId=@id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@chatId", m.ChatId);
            cmd.Parameters.AddWithValue("@userId", m.UserId);
            cmd.Parameters.AddWithValue("@date", m.Date);
            cmd.Parameters.AddWithValue("@text", m.Text);
            cmd.Parameters.AddWithValue("@dead", m.Dead);
            cmd.Parameters.AddWithValue("@id", m.Id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
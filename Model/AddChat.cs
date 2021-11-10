using mis321_pa4_api.Interfaces;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class AddChat : IAddChat
    {
        public void Add(Chat c)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO chats(chatId, userOneId, userTwoId, dead) VALUES(@id, @oneId, @twoId, @dead)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@oneId", c.UserOneId);
            cmd.Parameters.AddWithValue("@twoId", c.UserTwoId);
            cmd.Parameters.AddWithValue("@dead", c.Dead);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
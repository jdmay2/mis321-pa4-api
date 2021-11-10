using mis321_pa4_api.Interfaces;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class EditChat : IEditChat
    {
        public void Edit(Chat c)
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE chats SET userOneId=@userOneId, userTwoId=@userTwoId, dead=@dead WHERE chatId=@id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@userOneId", c.UserOneId);
            cmd.Parameters.AddWithValue("@userTwoId", c.UserTwoId);
            cmd.Parameters.AddWithValue("@dead", c.Dead);
            cmd.Parameters.AddWithValue("@id", c.Id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
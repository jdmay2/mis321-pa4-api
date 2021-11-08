using mis321_pa4_api.Interfaces;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class AddPost : IAddPost
    {
        public void Add(Post p)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO posts(postId, userId, subPostId, text, date, dead) VALUES(@postId, @userId, @subId, @text, @date, @dead)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@postId", p.Id);
            cmd.Parameters.AddWithValue("@userId", p.UserId);
            cmd.Parameters.AddWithValue("@subId", p.SubId);
            cmd.Parameters.AddWithValue("@text", p.Text);
            cmd.Parameters.AddWithValue("@date", p.Date);
            cmd.Parameters.AddWithValue("@dead", p.Dead);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
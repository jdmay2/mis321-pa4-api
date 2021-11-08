using mis321_pa4_api.Interfaces;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class EditPost : IEditPost
    {
        public void Edit(Post p)
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE posts SET text=@text WHERE postId=@id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@text", p.Text);
            cmd.Parameters.AddWithValue("@id", p.Id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
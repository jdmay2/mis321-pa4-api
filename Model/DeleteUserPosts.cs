using mis321_pa4_api.Interfaces;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class DeleteUserPosts : IDeleteAllPosts
    {
        public void DeletePosts(int id)
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE posts SET dead=1 WHERE userId=@id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
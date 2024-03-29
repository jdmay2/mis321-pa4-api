using mis321_pa4_api.Interfaces;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class ReadPostData : IGetAllPosts, IGetPost
    {
        public List<Post> GetPosts()
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM posts WHERE dead=0";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Post> posts = new List<Post>();
            while (rdr.Read())
            {
                Post p = new Post()
                {
                    Id = rdr.GetInt32(0),
                    UserId = rdr.GetInt32(1),
                    SubId = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2),
                    Text = rdr.GetString(3),
                    Date = rdr.GetDateTime(4),
                    Dead = rdr.GetBoolean(5),
                };
                posts.Add(p);
            }
            return posts;
        }
        public Post GetPost(int id)
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM posts WHERE postId=@postId AND dead=0";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@postId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Post()
            {
                Id = rdr.GetInt32(0),
                UserId = rdr.GetInt32(1),
                SubId = rdr.IsDBNull(2) ? 0 : rdr.GetInt32(2),
                Text = rdr.GetString(3),
                Date = rdr.GetDateTime(4),
                Dead = rdr.GetBoolean(5),
            };
        }
    }
}
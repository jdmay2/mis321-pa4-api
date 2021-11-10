using mis321_pa4_api.Interfaces;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class ReadChatData : IGetAllChats, IGetChat
    {
        public List<Chat> GetChats()
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM chats WHERE dead=0";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Chat> chats = new List<Chat>();
            while (rdr.Read())
            {
                Chat c = new Chat()
                {
                    Id = rdr.GetInt32(0),
                    UserOneId = rdr.GetInt32(1),
                    UserTwoId = rdr.GetInt32(2),
                    Dead = rdr.GetBoolean(3)
                };
                chats.Add(c);
            };
            return chats;
        }
        public Chat GetChat(int id)
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM chats WHERE chatId=@chatId AND dead=0";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@chatId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Chat()
            {
                Id = rdr.GetInt32(0),
                UserOneId = rdr.GetInt32(1),
                UserTwoId = rdr.GetInt32(2),
                Dead = rdr.GetBoolean(3),
            };
        }
    }
}
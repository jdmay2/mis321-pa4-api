using mis321_pa4_api.Interfaces;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace mis321_pa4_api.Model
{
    public class ReadMessageData : IGetAllMessages, IGetMessage
    {
        public List<Message> GetMessages()
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM messages WHERE dead=0";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Message> messages = new List<Message>();
            while (rdr.Read())
            {
                Message m = new Message()
                {
                    Id = rdr.GetInt32(0),
                    ChatId = rdr.GetInt32(1),
                    UserId = rdr.GetInt32(2),
                    Date = rdr.GetDateTime(3),
                    Text = rdr.GetString(4),
                    Dead = rdr.GetBoolean(5),
                };
                messages.Add(m);
            };
            return messages;
        }
        public Message GetMessage(int id)
        {
            ConnectionString connection = new ConnectionString();
            string cs = connection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM messages WHERE messageId=@messageId AND dead=0";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@messageId", id);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Message()
            {
                Id = rdr.GetInt32("messageId"),
                ChatId = rdr.GetInt32("chatId"),
                UserId = rdr.GetInt32("userId"),
                Date = rdr.GetDateTime("date"),
                Text = rdr.GetString("text"),
                Dead = rdr.GetBoolean("dead"),
            };
        }
    }
}
using System;

namespace mis321_pa4_api
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("server");
            string database = Environment.GetEnvironmentVariable("database");
            string port = Environment.GetEnvironmentVariable("port");
            string userName = Environment.GetEnvironmentVariable("username");
            string password = Environment.GetEnvironmentVariable("password");
            cs = $@"server = {server};user={userName};database={database};port={port};password={password};";
        }
    }
}
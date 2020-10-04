using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using RestApi.Database;

namespace RestApi.Database
{
    public class CreatorSql
    {
        private string connectionString;
        private MySqlConnection connection;

        public CreatorSql() {
            var _ConnectConfig = new ConnectConfig();
            this.connectionString = _ConnectConfig.connectionString();


            this.connection = new MySqlConnection(this.connectionString);
        }

        


        //public string select(string table, string tablePrefix, object columns)
        //{
        //    string sql = "SELECT";

        //    for (const property in columns) {

        //        columns[property].name;
        //    }
        //    column[0].name;
        //    return table;
        //}

        public string request(string sql)
        {
            string data = "[";
            this.connection.Open();

            var command = new MySqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                if (i == 0)
                {
                    data += reader.GetString(0);
                }
                else {
                    data +="," + reader.GetString(0);
                }
                i++;
            }

            data += "]";

            return data;
        }

    }
}

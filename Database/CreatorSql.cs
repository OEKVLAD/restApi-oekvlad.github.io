using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using RestApi.Database;
using System.Text.Json;

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

        public string request2(string sql)
        {
            this.connection.Open();
            
            var command = new MySqlCommand(sql, connection);
            var reader = command.ExecuteReader();

            string list= "";
            List<string> list1 = new List<string>();
            int i = 0;
            string lastModule = "";
            while (reader.Read())
            {
                
                if (i==0 || lastModule == reader.GetString(1))
                {
                    list1.Add(reader.GetString(0));


                }
                else
                {
                    list +="{\"block\":" + JsonSerializer.Serialize(list1) + "},";
                    list1 = new List<string>();
                    list1.Add(reader.GetString(0));
                }
                lastModule = reader.GetString(1);
                i++;
            }
            list += "{\"block\":" + JsonSerializer.Serialize(list1) + "}";

            var json = "["+list+"]";
            return json;
        }

    }
}

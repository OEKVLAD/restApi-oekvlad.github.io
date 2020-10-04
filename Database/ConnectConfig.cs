using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Database
{
    public class ConnectConfig
    {
        public int x, y;

        private string server;
        private string dataBase;
        private string user;
        private string password;

      
        public ConnectConfig()
        {
            this.server = "mysql3.webio.pl";
            this.dataBase = "20534_vladysalvomelchenko";
            this.user = "20534_vladyslavo";
            this.password = "BjB4Es43X4v*p+";
        
        }

        public string connectionString() {
            return  "server=" + this.server + ";"+
                    "userid=" + this.user + ";"+
                    "password=" + this.password + ";"+
                    "database=" + this.dataBase + ";";
        }
    }
}

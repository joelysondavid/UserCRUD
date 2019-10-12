using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CriacaoUsuarios.Persistence
{
    public class DBConnection
    {
        private static volatile SqlConnection instance;

        private DBConnection() {}

        public static SqlConnection DB_Connection
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlConnection(@"Data Source=BIBLI43\SQLEXPRESS; Initial Catalog=Usuarios; Trusted_Connection=True;");
                }
                return instance;
            }
        }
    }
}
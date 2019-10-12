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
                    // não esquecer de alterar o Data Source para a conexão de SQLServer Usada na máquida em que está sendo testada
                    instance = new SqlConnection(@"Data Source=JDKS-PC\SQLEXPRESS; Initial Catalog=Usuarios; Trusted_Connection=True;");
                }
                return instance;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace GivingDataDemo.Infrastructure.Repositories
{
    public class BaseRepository
    {
        public IDbConnection GivingDataDemoDbConnection => 
            new SqlConnection(ConfigurationManager.ConnectionStrings["GivingDataDemoConnectionString"].ConnectionString);
    }
}

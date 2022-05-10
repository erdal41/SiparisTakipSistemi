using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakipSistemi.Sistem
{
    class SqlHelper
    {
        SqlConnection SiparisTakipEntities;
        public SqlHelper(string connectionString)
        {
            SiparisTakipEntities = new SqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (SiparisTakipEntities.State == System.Data.ConnectionState.Closed)
                    SiparisTakipEntities.Open();
                return true;
            }
        }
    }
}

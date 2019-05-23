using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_2.DataAccess.SQL_Server
{
    public class SqlContext
    {
        public string ConnString => sqlUnitOfWork.ConnString;
        SqlUnitOfWork sqlUnitOfWork;
        public SqlContext(SqlUnitOfWork sqlUnitOfWork)
        {
            this.sqlUnitOfWork = sqlUnitOfWork;
        }

        public void AddCommandToTransaction(SqlCommand cmd)
        {
            sqlUnitOfWork.EnqueueCommand(cmd);
        }
    }
}

using ADO_NET_2.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_2.DataAccess.SQL_Server
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        public string ConnString { get; set; }
        Queue<SqlCommand> commands = new Queue<SqlCommand>();
        SqlContext context;

        public SqlUnitOfWork(string connectionString)
        {
            ConnString = connectionString;

            context = new SqlContext(this);
        }

        public void EnqueueCommand(SqlCommand cmd)
        {
            commands.Enqueue(cmd);
        }

        public IUserRepository userRepository => new SqlUserRepository(context);

        public void SaveChanges()
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlTransaction tr = conn.BeginTransaction();

                try
                {
                    while (commands.Count > 0)
                    {
                        SqlCommand cmd = commands.Dequeue();
                        cmd.Connection = conn;
                        cmd.Transaction = tr;
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                catch
                {
                    commands = new Queue<SqlCommand>();
                    tr.Rollback();
                }

            }
        }
    }
}

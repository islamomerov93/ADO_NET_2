using ADO_NET_2.Domain.Abstractions;
using ADO_NET_2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO_NET_2.DataAccess.SQL_Server
{
    public class SqlUserRepository : IUserRepository
    {
        SqlContext context;
        public SqlUserRepository(SqlContext context)
        {
            this.context = context;
        }
        public void Add(User user)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string cmdtext = "insert into Users values(@Name,@Surname,@Age,@IsAdmin)";
                using (SqlCommand cmd = new SqlCommand(cmdtext,conn))
                {
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Surname", user.Surname);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                    context.AddCommandToTransaction(cmd);
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string cmdtext = "delete from Users where id = " + id;
                using (SqlCommand cmd = new SqlCommand(cmdtext, conn))
                {
                    context.AddCommandToTransaction(cmd);
                }
            }
        }
        List<User> users;
        public List<User> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string cmdtext = "insert into Users values(@Name,@Surname,@Age,@IsAdmin)";
                using (SqlCommand cmd = new SqlCommand(cmdtext, conn))
                {
                    
                }
                return users;
            }
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

using ADO_NET_2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_2.Domain.Abstractions
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(int id);
        void Update(User user);
        List<User> Get();
        User Get(int id);
    }
}

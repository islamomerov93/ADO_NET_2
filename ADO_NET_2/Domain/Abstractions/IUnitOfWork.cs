using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_2.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        IUserRepository userRepository { get; }
    }
}

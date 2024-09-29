using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Data
{
    public interface IAccountRepository
    {
        List<Account>? GetAll();
        bool Save(Account oAccount);
        Account GetById(int id);
        bool Delete(int id);
    }
}

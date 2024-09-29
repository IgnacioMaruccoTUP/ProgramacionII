using BancoApp.Data;
using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Services
{
    public class AccountManager
    {
        //clase intermediaria
        private IAccountRepository _repositorio;

        public AccountManager()
        {
            _repositorio = new AccountRepositoryADO();
        }

        public List<Account> GetAccounts()
        {
            return _repositorio.GetAll();
        }

        public bool SaveAccount(Account account)
        {
            return _repositorio.Save(account);
        }
    }
}

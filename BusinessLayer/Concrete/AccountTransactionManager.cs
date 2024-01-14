using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AccountTransactionManager : IAccountTransactionService
    {
        private readonly IAccountTransactionDal _accountTransactionDal;

        public AccountTransactionManager(IAccountTransactionDal accountTransactionDal)
        {
            _accountTransactionDal = accountTransactionDal;
        }

        public void TDelete(AccountTransaction t)
        {
            _accountTransactionDal.Delete(t);
        }

        public List<AccountTransaction> TGetAll()
        {
           return _accountTransactionDal.GetAll();
        }

        public AccountTransaction TGetById(int id)
        {
            return _accountTransactionDal.GetById(id);
        }

        public void TInsert(AccountTransaction t)
        {
            _accountTransactionDal.Insert(t);
        }

        public void TUpdate(AccountTransaction t)
        {
            _accountTransactionDal.Update(t);
        }
    }
}

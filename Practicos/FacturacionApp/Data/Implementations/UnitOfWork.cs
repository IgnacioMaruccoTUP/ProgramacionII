using FacturacionApp.Data.Contracts;
using FacturacionApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacturacionApp.Data.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        private IBillRepository _billRepositoryADO;
        private IArticleRepository _articleRepositoryADO;
        private IPaymentTypeRepository _paymentTypeRepositoryADO;

        public UnitOfWork()
        {
            _connection = DataHelper.GetInstance().GetConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public IBillRepository BillRepositoryADO
        {
            get
            {
                if (_billRepositoryADO == null)
                    _billRepositoryADO = new BillRepositoryADO(_connection, _transaction);
                return _billRepositoryADO;
            }
        }
        public IArticleRepository ArticleRepositoryADO
        {
            get
            {
                if (_articleRepositoryADO == null)
                    _articleRepositoryADO = new ArticleRepositoryADO(_connection, _transaction);
                return _articleRepositoryADO;
            }
        }

        public IPaymentTypeRepository PaymentTypeRepositoryADO
        {
            get
            {
                if (_paymentTypeRepositoryADO == null)
                    _paymentTypeRepositoryADO = new PaymentTypeRepositoryADO(_connection, _transaction);
                return _paymentTypeRepositoryADO;
            }
        }

        public void SaveChanges()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception("Error al guardar cambios en la base de datos.", ex);
            }
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}

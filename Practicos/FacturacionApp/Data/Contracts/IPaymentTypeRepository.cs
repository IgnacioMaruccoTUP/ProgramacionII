using FacturacionApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Data.Contracts
{
    public interface IPaymentTypeRepository
    {
        List<PaymentType> GetAll();
    }
}

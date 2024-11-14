using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Implementations
{
    public class FormaPagoRepositoty : IFormaPagoRepositoty
    {
        private CineDbContext _db_prograContext;

        public FormaPagoRepositoty(CineDbContext prograContext)
        {
            _db_prograContext = prograContext;
        }
        public async Task<List<FormasPago>> RecuperarFormasPago()
        {
            return await _db_prograContext.FormasPagos.ToListAsync();
        }
    }
}

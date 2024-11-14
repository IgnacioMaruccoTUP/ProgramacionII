using CIneData.Models;
using CIneData.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Contracts
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAll();
        Task<bool> Verify(SolicitudLogin login);
        Task<Cliente> GetByEmail(string email);

        Task<bool> Create(Cliente cliente);
    }
}

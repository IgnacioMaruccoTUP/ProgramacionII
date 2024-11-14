using CIneData.Models;
using CIneData.Models.DTOs;
using CIneData.Repositories.Contracts;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        CineDbContext _context;
        public ClienteRepository(CineDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetAll()
        {
            var lst = await _context.Clientes.ToListAsync();
            return lst;
        }

        public async Task<bool> Create(Cliente cliente)
        {
            var pass = cliente.Pass;
            var passHasheada = Argon2.Hash(pass);
            cliente.Pass = passHasheada;
            var res = await _context.Clientes.AddAsync(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Email == email);
            return cliente;
        }
        public async Task<bool> Verify(SolicitudLogin login)
        {
            bool isVerified = false;
            var ingresante = await _context.Clientes.Where(c => c.Email == login.Email).FirstOrDefaultAsync();
            if (ingresante != null)
            {
                isVerified = Argon2.Verify(ingresante.Pass, login.Password);
            }
            return isVerified;
        }
    }
}

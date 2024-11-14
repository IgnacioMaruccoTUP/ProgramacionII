using CIneData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Contracts
{
    public interface IPeliculaRepository
    {
        Task<List<Pelicula>> RecuperarTodasPeliculas();

        Task<List<Pelicula>> GetPelisCartelera();
    }
}

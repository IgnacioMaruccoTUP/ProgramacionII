using ModeloParcialWebApi.Models;
using ModeloParcialWebApi.Repositories.Utils;
using System.Data;

namespace ModeloParcialWebApi.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private CineDbContext _context;

        public PeliculaRepository(CineDbContext context)
        {
            _context = context;
        }

        public bool Create(Pelicula oPelicula)
        {
            //Implementado por EF Core
            _context.Peliculas.Add(oPelicula);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var helper = DataHelper.GetInstance();
            List<ParameterSQL> lst = new List<ParameterSQL>();
            lst.Add(new ParameterSQL("@id", id));
            lst.Add(new ParameterSQL("@motivo", "S/M"));
            return helper.ExecuteSPDML("SP_REGISTRAR_BAJA_PELICULA", lst) > 0;

        }

        public List<Pelicula> GetByGenero(int genero)
        {
            List<Pelicula> lst = new List<Pelicula>();
            var helper = DataHelper.GetInstance();
            List<ParameterSQL> lstParams = new List<ParameterSQL>();
            lstParams.Add(new ParameterSQL("@genero", genero));


            DataTable t =  helper.ExecuteSPQuery("SP_CONSULTAR_PELICULAS", lstParams);

            foreach(DataRow row in t.Rows)
            {
                var pelicula = new Pelicula();
                pelicula.Id = Int32.Parse(row["id"].ToString());
                pelicula.Titulo = row["titulo"].ToString();
                pelicula.Director = row["director"].ToString();
                pelicula.Anio = Int32.Parse(row["anio"].ToString());
                pelicula.Estreno = Boolean.Parse(row["estreno"].ToString());
                pelicula.IdGenero = Int32.Parse(row["id_genero"].ToString());
                pelicula.GeneroNavigation = new Genero()
                {
                    Id = Int32.Parse(row["id_genero"].ToString()),
                    Nombre = row["nombre"].ToString()
                };

                lst.Add(pelicula);
            }

            return lst;
        }

        public List<Pelicula> GetAllByYears(int anio1, int anio2)
        {
            return _context.Peliculas.Where(x => x.Anio >= anio1 && x.Anio <= anio2).ToList();
        }

        public bool Update(int id)
        {
            var peliculaActualizada = _context.Peliculas.Find(id);
            if (peliculaActualizada != null)
            {
                peliculaActualizada.Estreno = false;
                return _context.SaveChanges() > 0;
            }
            return false;
        }



    }
}

using TurnoApi.Models;

namespace TurnoApi.Services
{
    public interface ITurnoService
    {
        Task<List<TTurno>> GetAll();
        Task<bool> Save(TTurno turno);
        Task<bool> Update(TTurno turno , int id);
        Task<bool> Delete(int id,string motivo);

        //Permite recuperar los turnos cancelados en los ultimos x dias
        Task<List<TTurno>> GetTurnosCancelados(int dias);

        ////Permite validar si un cliente reservo un turno para la fecha ingresada por parametro
        Task<bool> ValidarTurno(string cliente, DateTime fecha);
    }
}

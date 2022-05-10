using ProEventos.Application.Dtos;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<EventoDTO> AddEventos(EventoDTO model);
        Task<EventoDTO> UpdateEventos(int eventoId, EventoDTO model);
        Task<bool> DeleteEventos(int eventoId);

        Task<EventoDTO[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDTO[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
